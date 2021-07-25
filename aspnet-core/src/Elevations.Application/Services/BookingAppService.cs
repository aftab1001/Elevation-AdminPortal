﻿namespace Elevations.Services
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Net;
    using System.Threading.Tasks;

    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.Domain.Repositories;

    using Elevations.EntityFrameworkCore.HotelDto;
    using Elevations.Services.Dto;

    using Microsoft.EntityFrameworkCore;

    using Stripe;

    public class BookingAppService :
        AsyncCrudAppService<Booking, BookingDto, int, PagedResultRequestDto, UpdateBookingDto, BookingDto>,
        IBookingService
    {
        private readonly string apiKey  = "pk_test_6pRNASCoBOKtIshFeQd4XMUh";
        private readonly IRepository<Apartments> apartmentRepository;

        private readonly IRepository<Booking> bookingRepository;

        private readonly IRepository<PaymentDetails> paymentDetailRepository;

        private readonly IRepository<Rooms> roomsRepository;

        public BookingAppService(
            IRepository<Booking> bookingRepository,
            IRepository<Booking, int> repository,
            IRepository<Rooms> roomsRepository,
            IRepository<Apartments> apartmentRepository,
            IRepository<PaymentDetails> paymentDetailRepository)
            : base(repository)
        {
            this.bookingRepository = bookingRepository;
            this.roomsRepository = roomsRepository;
            this.apartmentRepository = apartmentRepository;
            this.paymentDetailRepository = paymentDetailRepository;
        }

        public override async Task<BookingDto> CreateAsync(UpdateBookingDto input)
        {
            string itemName = string.Empty;

            if (input.ItemType == ItemType.Rooms)
            {
                itemName = (await roomsRepository.FirstOrDefaultAsync(x => x.Id == input.ItemId))?.Name;
            }

            if (input.ItemType == ItemType.Apartment)
            {
                itemName = (await apartmentRepository.FirstOrDefaultAsync(x => x.Id == input.ItemId))?.Name;
            }

            if (string.IsNullOrEmpty(itemName))
            {
                throw new Exception(
                    "Unable to find ItemName based on item type.Please contact Elevations Hotel Administrator");
            }

            CheckUpdatePermission();

            PaymentDetails pDetails =
                await paymentDetailRepository.FirstOrDefaultAsync(x => x.TransactionId == input.PaymentReferenceId);

            Booking Booking = new()
                                  {
                                      PaymentReference = pDetails, FromDate = input.FromDate, ToDate = input.ToDate,
                                      FirstName = input.FirstName, LastName = input.LastName, Email = input.Email,
                                      ContactNumber = input.ContactNumber, SpecialRequest = input.SpecialRequest,
                                      ItemId = input.ItemId, BookingType = input.BookingType, Price = input.Price,
                                      ItemType = input.ItemType, AdminComments = input.AdminComments,
                                      BookingStatus = input.BookingStatus, RoomName = itemName
                                  };
            int insertedId = await Repository.InsertAndGetIdAsync(Booking);
            input.Id = insertedId;
            return MapToEntityDto(Booking);
        }

        public override Task<PagedResultDto<BookingDto>> GetAllAsync(PagedResultRequestDto input)
        {
            return Task.FromResult(GetBookingDetail());
        }

        [AbpAllowAnonymous]
        public async Task<PagedResultDto<BookingDto>> GetAllBookings()
        {
            return await Task.FromResult(GetBookingDetail());
        }

        public async Task<List<BookingDetailsDto>> GetBookingByType(ItemType bookingType)
        {
            List<BookingDetailsDto> bookingDetailList = new();
            if (bookingType == ItemType.Rooms)
            {
                List<Rooms> roomsDetail = await roomsRepository.GetAllListAsync();

                foreach (Rooms item in roomsDetail)
                {
                    BookingDetailsDto bookingDetail = ObjectMapper.Map<BookingDetailsDto>(item);
                    bookingDetailList.Add(bookingDetail);
                }
            }

            if (bookingType == ItemType.Apartment)
            {
                List<Apartments> apartmentDetail = await apartmentRepository.GetAllListAsync();
                foreach (Apartments item in apartmentDetail)
                {
                    BookingDetailsDto bookingDetail = ObjectMapper.Map<BookingDetailsDto>(item);
                    bookingDetailList.Add(bookingDetail);
                }
            }

            return bookingDetailList;
        }

        public async Task<string> GetBookingStatus(
            int itemId,
            BookingType bookingType,
            DateTime fromDate,
            DateTime toDate)
        {
            Booking bookingDetail = await bookingRepository.GetAll().FirstOrDefaultAsync(
                                        x => x.ItemId == itemId && x.BookingType == bookingType
                                                                && x.FromDate == fromDate && x.ToDate == toDate);
            return bookingDetail.BookingStatus.ToString();
        }

        public async Task<PayModelResponse> ProcessBooking(PayModel payModel)
        {
            try
            {
                StripeConfiguration.ApiKey = apiKey;


                //TokenCreateOptions options = new()
                //                                 {
                //                                     Card = new TokenCardOptions
                //                                                {
                //                                                    Number = payModel.CardNumber,
                //                                                    ExpMonth = payModel.Month, ExpYear = payModel.Year,
                //                                                    Cvc = payModel.CVC
                //                                                }
                //                                 };

                //TokenService serviceToken = new();
                //Token stripeToken = await serviceToken.CreateAsync(options);

                ChargeCreateOptions chargeOptions = new()
                                                        {
                                                            Amount = payModel.Amount, Currency = "usd",
                                                            Description = "Hotel Payment", Source = payModel.PaymentData.Token
                                                        };

                ChargeService chargeService = new();
                Charge charge = await chargeService.CreateAsync(chargeOptions);

                if (charge.Paid)
                {
                    return new PayModelResponse
                               {
                                   Code = HttpStatusCode.OK, Status = "Success", StripeReferenceId = charge.Id
                               };
                }
            }
            catch (Exception ex)
            {
                return new PayModelResponse { Code = HttpStatusCode.InternalServerError, Status = ex.Message };
            }

            return new PayModelResponse();
        }

        public async Task<Booking> RevokeBooking(int Id, string comments)
        {
            Booking bookingDetail = await bookingRepository.GetAll().FirstOrDefaultAsync(
                                        x => x.AdminComments == comments && x.Id == Id);
            if (bookingDetail == null)
            {
                throw new Exception("No Booking Found");
            }

            bookingDetail.BookingStatus = BookingStatus.Revoked;

            return bookingDetail;
        }

        public override async Task<BookingDto> UpdateAsync(BookingDto input)
        {
            Task<PaymentDetails> paymentDetails =
                paymentDetailRepository.FirstOrDefaultAsync(x => x.TransactionId == input.PaymentReferenceId);
            CheckUpdatePermission();

            Booking Booking = new()
                                  {
                                      PaymentReference = paymentDetails.Result, FromDate = input.FromDate,
                                      ToDate = input.ToDate, FirstName = input.FirstName, LastName = input.LastName,
                                      Email = input.Email, ContactNumber = input.ContactNumber,
                                      SpecialRequest = input.SpecialRequest, ItemId = input.ItemId,
                                      BookingType = input.BookingType, Price = input.Price, Id = input.Id,
                                      ItemType = input.ItemType, AdminComments = input.AdminComments,
                                      BookingStatus = input.BookingStatus, RoomName = input.RoomName
                                  };

            await Repository.UpdateAsync(Booking);

            return MapToEntityDto(Booking);
        }

        protected override async Task<Booking> GetEntityByIdAsync(int id)
        {
            return await Repository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }

        private PagedResultDto<BookingDto> GetBookingDetail()
        {
            List<Booking> BookingsList = bookingRepository.GetAllListAsync().Result;

            List<BookingDto> bookingDtoList = new();

            foreach (Booking item in BookingsList)
            {
                BookingDto bookingDto = new()
                                            {
                                                RoomName = item.RoomName, FromDate = item.FromDate,
                                                ToDate = item.ToDate, GuestName = item.FirstName + " " + item.LastName,
                                                ContactNumber = item.ContactNumber, Email = item.Email,
                                                SpecialRequest = item.SpecialRequest, Price = item.Price,
                                                BookingStatus = item.BookingStatus, ItemId = item.ItemId, Id = item.Id,
                                                ItemType = item.ItemType, AdminComments = item.AdminComments,
                                                BookingType = item.BookingType
                                            };

                bookingDtoList.Add(bookingDto);
            }

            return new PagedResultDto<BookingDto>(
                BookingsList.Count,
                new ReadOnlyCollection<BookingDto>(bookingDtoList));
        }
    }
}
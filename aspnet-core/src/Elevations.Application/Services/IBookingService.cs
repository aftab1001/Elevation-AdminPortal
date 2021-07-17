namespace Elevations.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Abp.Application.Services;
    using Abp.Application.Services.Dto;

    using Elevations.EntityFrameworkCore.HotelDto;
    using Elevations.Services.Dto;

    public interface IBookingService : IAsyncCrudAppService<BookingDto, int, PagedResultRequestDto,
        UpdateBookingDto, BookingDto>
    {
        public Task<PagedResultDto<BookingDto>> GetAllBookings();

        Task<List<BookingDetailsDto>> GetBookingByType(ItemType bookingType);

        Task<string> GetBookingStatus(int itemId, BookingType bookingType, DateTime fromDate, DateTime toDate);

        Task<PayModelResponse> ProcessBooking(PayModel payModel);

        Task<Booking> RevokeBooking(int Id, string comments);
    }
}
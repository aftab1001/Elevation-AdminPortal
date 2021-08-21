namespace Elevations.Services
{
    using System;
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;

    using Abp.Application.Services;
    using Abp.Application.Services.Dto;
    using Abp.Authorization;
    using Abp.Domain.Repositories;

    using Elevations.EntityFrameworkCore.HotelDto;
    using Elevations.Roles.Dto;
    using Elevations.Services.Dto;

    //[AbpAuthorize(PermissionNames.Pages_Reservation)]
    [AbpAllowAnonymous]
    public class ReservationAppService : AsyncCrudAppService<Reservation, ReservationDto, int, PagedResultRequestDto,
                                             UpdateReservationDto, ReservationDto>
                                       
        

    {
        public ReservationAppService(IRepository<Reservation, int> repository)
            : base(repository)
        {
        }

        public async Task<bool> BookTable(ReservationDto input)
        {
            try
            {
                CheckUpdatePermission();

                MailAddress fromAddress = new MailAddress("elevationshotel@gmail.com", "Elevations Hotel");
                MailAddress toAddress = new MailAddress(input.Email, $"Dear {input.Name}");
                const string fromPassword = "ABC123ssi";
                const string subject = "Table Booking";
                const string body = "You table has been booked SuccessFully";

                SmtpClient smtp = new SmtpClient
                                      {
                    Host = "smtp.gmail.com", Port = 587, EnableSsl = true,
                                          DeliveryMethod = SmtpDeliveryMethod.Network, UseDefaultCredentials = false,
                                          Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                                      };
                using MailMessage message = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = body };
                smtp.Send(message);
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }
    }
}
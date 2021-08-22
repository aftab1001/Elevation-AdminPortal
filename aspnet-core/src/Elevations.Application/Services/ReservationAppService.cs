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

                MailAddress fromAddress = new("elevationshotel@gmail.com", "Elevations Hotel");
                MailAddress toAddress = new(input.Email, $"Dear {input.Name}");
                MailAddress toAddress1 = new(input.Email, "julesguichy1@gmail.com");
                const string fromPassword = "ABC123ssi";
                const string subject = "Table Booking";

                const string body = "Request Received. You will get confirm from our representative";

                string msgBodyForOwner =
                    $"A table booking request has been received from {input.Name} and the email address is {input.Email} .Total number of person are {input.NumberOfGuest}. The message from the custom is {input.Message}";

                SmtpClient smtp = new()
                                      {
                                          Host = "smtp.gmail.com", Port = 587, EnableSsl = true,
                                          DeliveryMethod = SmtpDeliveryMethod.Network, UseDefaultCredentials = false,
                                          Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                                      };

                using MailMessage message = new(fromAddress, toAddress) { Subject = subject, Body = body };

                using MailMessage message1 = new(fromAddress, toAddress1) { Subject = subject, Body = msgBodyForOwner };
                smtp.Send(message);
                smtp.Send(message1);
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }
    }
}
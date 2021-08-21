namespace Elevations.Services
{
    using System.Threading.Tasks;

    using Abp.Application.Services;
    using Abp.Application.Services.Dto;

    using Elevations.Services.Dto;

    public interface IReservationService: IAsyncCrudAppService<ReservationDto, int, PagedResultRequestDto,
            UpdateReservationDto, ReservationDto>
        {
            public Task<bool> BookTable(ReservationDto input);
        }

    }
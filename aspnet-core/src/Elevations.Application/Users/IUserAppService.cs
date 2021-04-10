namespace Elevations.Users
{
    using System.Threading.Tasks;

    using Abp.Application.Services;
    using Abp.Application.Services.Dto;

    using Elevations.Roles.Dto;
    using Elevations.Users.Dto;

    public interface
        IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task Activate(EntityDto<long> user);

        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);

        Task DeActivate(EntityDto<long> user);

        Task<ListResultDto<RoleDto>> GetRoles();
    }
}
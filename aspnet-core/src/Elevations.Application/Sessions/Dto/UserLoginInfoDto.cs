namespace Elevations.Sessions.Dto
{
    using Abp.Application.Services.Dto;
    using Abp.AutoMapper;

    using Elevations.Authorization.Users;

    [AutoMapFrom(typeof(User))]
    public class UserLoginInfoDto : EntityDto<long>
    {
        public string EmailAddress { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }
    }
}
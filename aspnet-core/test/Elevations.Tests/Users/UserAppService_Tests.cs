namespace Elevations.Tests.Users
{
    using System.Threading.Tasks;

    using Abp.Application.Services.Dto;

    using Elevations.Authorization.Users;
    using Elevations.Users;
    using Elevations.Users.Dto;

    using Microsoft.EntityFrameworkCore;

    using Shouldly;

    using Xunit;

    public class UserAppService_Tests : ElevationsTestBase
    {
        private readonly IUserAppService _userAppService;

        public UserAppService_Tests()
        {
            _userAppService = Resolve<IUserAppService>();
        }

        [Fact]
        public async Task CreateUser_Test()
        {
            // Act
            await _userAppService.CreateAsync(
                new CreateUserDto
                    {
                        EmailAddress = "john@volosoft.com", IsActive = true, Name = "John", Surname = "Nash",
                        Password = "123qwe", UserName = "john.nash"
                    });

            await UsingDbContextAsync(
                async context =>
                    {
                        User johnNashUser = await context.Users.FirstOrDefaultAsync(u => u.UserName == "john.nash");
                        johnNashUser.ShouldNotBeNull();
                    });
        }

        [Fact]
        public async Task GetUsers_Test()
        {
            // Act
            PagedResultDto<UserDto> output = await _userAppService.GetAllAsync(
                                                 new PagedUserResultRequestDto { MaxResultCount = 20, SkipCount = 0 });

            // Assert
            output.Items.Count.ShouldBeGreaterThan(0);
        }
    }
}
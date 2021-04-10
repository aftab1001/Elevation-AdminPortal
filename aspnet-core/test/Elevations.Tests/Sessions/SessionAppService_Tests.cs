namespace Elevations.Tests.Sessions
{
    using System.Threading.Tasks;

    using Elevations.Authorization.Users;
    using Elevations.MultiTenancy;
    using Elevations.Sessions;
    using Elevations.Sessions.Dto;

    using Shouldly;

    using Xunit;

    public class SessionAppService_Tests : ElevationsTestBase
    {
        private readonly ISessionAppService _sessionAppService;

        public SessionAppService_Tests()
        {
            _sessionAppService = Resolve<ISessionAppService>();
        }

        [Fact]
        public async Task Should_Get_Current_User_And_Tenant_When_Logged_In_As_Tenant()
        {
            // Act
            GetCurrentLoginInformationsOutput output = await _sessionAppService.GetCurrentLoginInformations();

            // Assert
            User currentUser = await GetCurrentUserAsync();
            Tenant currentTenant = await GetCurrentTenantAsync();

            output.User.ShouldNotBe(null);
            output.User.Name.ShouldBe(currentUser.Name);

            output.Tenant.ShouldNotBe(null);
            output.Tenant.Name.ShouldBe(currentTenant.Name);
        }

        [MultiTenantFact]
        public async Task Should_Get_Current_User_When_Logged_In_As_Host()
        {
            // Arrange
            LoginAsHostAdmin();

            // Act
            GetCurrentLoginInformationsOutput output = await _sessionAppService.GetCurrentLoginInformations();

            // Assert
            User currentUser = await GetCurrentUserAsync();
            output.User.ShouldNotBe(null);
            output.User.Name.ShouldBe(currentUser.Name);
            output.User.Surname.ShouldBe(currentUser.Surname);

            output.Tenant.ShouldBe(null);
        }
    }
}
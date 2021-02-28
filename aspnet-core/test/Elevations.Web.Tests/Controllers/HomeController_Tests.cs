using System.Threading.Tasks;
using Elevations.Models.TokenAuth;
using Elevations.Web.Controllers;
using Shouldly;
using Xunit;

namespace Elevations.Web.Tests.Controllers
{
    public class HomeController_Tests: ElevationsWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
using System.Threading.Tasks;
using Bloggs.Models.TokenAuth;
using Bloggs.Web.Controllers;
using Shouldly;
using Xunit;

namespace Bloggs.Web.Tests.Controllers
{
    public class HomeController_Tests: BloggsWebTestBase
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
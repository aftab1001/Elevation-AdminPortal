namespace Elevations.Web.Host.Controllers
{
    using Abp.Web.Security.AntiForgery;

    using Elevations.Controllers;

    using Microsoft.AspNetCore.Antiforgery;

    public class AntiForgeryController : ElevationsControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        private readonly IAbpAntiForgeryManager _antiForgeryManager;

        public AntiForgeryController(IAntiforgery antiforgery, IAbpAntiForgeryManager antiForgeryManager)
        {
            _antiforgery = antiforgery;
            _antiForgeryManager = antiForgeryManager;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }

        public void SetCookie()
        {
            _antiForgeryManager.SetCookie(HttpContext);
        }
    }
}
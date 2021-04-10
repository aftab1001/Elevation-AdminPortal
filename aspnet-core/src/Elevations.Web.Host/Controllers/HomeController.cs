namespace Elevations.Web.Host.Controllers
{
    using System.Threading.Tasks;

    using Abp;
    using Abp.Extensions;
    using Abp.Notifications;
    using Abp.Timing;

    using Elevations.Controllers;

    using Microsoft.AspNetCore.Mvc;

    public class HomeController : ElevationsControllerBase
    {
        private readonly INotificationPublisher _notificationPublisher;

        public HomeController(INotificationPublisher notificationPublisher)
        {
            _notificationPublisher = notificationPublisher;
        }

        public IActionResult Index()
        {
            return Redirect("/swagger");
        }

        /// <summary>
        ///     This is a demo code to demonstrate sending notification to default tenant admin and host admin uers.
        ///     Don't use this code in production !!!
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<ActionResult> TestNotification(string message = "")
        {
            if (message.IsNullOrEmpty())
            {
                message = "This is a test notification, created at " + Clock.Now;
            }

            UserIdentifier defaultTenantAdmin = new UserIdentifier(1, 2);
            UserIdentifier hostAdmin = new UserIdentifier(null, 1);

            await _notificationPublisher.PublishAsync(
                "App.SimpleMessage",
                new MessageNotificationData(message),
                severity: NotificationSeverity.Info,
                userIds: new[] { defaultTenantAdmin, hostAdmin });

            return Content("Sent notification: " + message);
        }
    }
}
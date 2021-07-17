namespace Elevations.Services.Dto
{
    using System.Net;

    public class PayModelResponse
    {
        public string Status { get; set; }

        public HttpStatusCode Code { get; set; }

        public string StripeReferenceId { get; set; }
    }
}
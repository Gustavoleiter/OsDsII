using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OsDsII.api.Http;
using System.Net;

namespace OsDsII.api.Exceptions
{
    public class BaseException : Exception
    {
        private HttpErrorResponse HttpResponse { get; set; }
        private HttpStatusCode StatusCode { get; set; }

        public BaseException(
            string errorCode,
            string message,
            HttpStatusCode httpStatusCode,
            int statusCode,
            DateTimeOffset timestamp,
            Exception? ex) : base(message, ex)
        {
            StatusCode = httpStatusCode;
            HttpResponse = new HttpErrorResponse(errorCode,
                message, statusCode, timestamp);
        }

        public IActionResult GetResponse()
        {
            return new ContentResult
            {
                StatusCode = ((int)StatusCode),
                Content = JsonConvert.SerializeObject(
                    HttpResponse,
                    new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    }
                    )
            };
        }
    }
}

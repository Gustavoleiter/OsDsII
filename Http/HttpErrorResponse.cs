using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace OsDsII.api.Http
{
    public class HttpResponseApi<T> where T : class
    {
        public T Data { get; private set; }
        public string Message { get; private set; }
        public int StatusCode { get; private set; }
        public DateTimeOffset Timestamp { get; private set; }

        private HttpResponseApi(T data, string message, HttpStatusCode statusCode)
        {
            Data = data;
            Message = message;
            StatusCode = (int)statusCode;
            Timestamp = DateTimeOffset.UtcNow;
        }

        public  static  IActionResult Ok(T data) 
        {
            var htpResponse = new HttpResponseApi<T>(data, "ok", HttpStatusCode.OK);
            return new ObjectResult(htpResponse) { StatusCode = htpResponse.StatusCode, };
        }
        public static IActionResult Created(T data)
        {
            var htpResponse = new HttpResponseApi<T>(data, "Created successfully", HttpStatusCode.Created);
            return new ObjectResult(htpResponse) { StatusCode = htpResponse.StatusCode, };
        }
        public static IActionResult NoContent()
        {
            var htpResponse = new HttpResponseApi<T>(null, "Done", HttpStatusCode.NoContent);
            return new ObjectResult(htpResponse) { StatusCode = htpResponse.StatusCode, };
        }


    }
}

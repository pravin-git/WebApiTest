using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace WebApiAuth.Filter
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            var log = context.Exception.InnerException;
            //log it

            //Handler every exception type differently
            //if (context.Exception is ArgumentNullException)
            //{
            //    var result = new HttpResponseMessage(HttpStatusCode.BadRequest)
            //    {
            //        Content = new StringContent(context.Exception.Message),
            //        ReasonPhrase = "ArgumentNullException"
            //    };

            //    context.Result = new ArgumentNullResult(context.Request, result);
            //}


            //Or handle it once for all types of exception
            var result = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("Something went wrong!!! We are on it."),
                ReasonPhrase = "Something went wrong!!! We are on it."
            };

            context.Result = new InternalServerErrorResult(context.Request, result);
        }
    }

    public class InternalServerErrorResult : IHttpActionResult
    {
        private HttpRequestMessage _request;
        private HttpResponseMessage _httpResponseMessage;


        public InternalServerErrorResult(HttpRequestMessage request, HttpResponseMessage httpResponseMessage)
        {
            _request = request;
            _httpResponseMessage = httpResponseMessage;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_httpResponseMessage);
        }
    }
}
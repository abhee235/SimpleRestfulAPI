using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace TeamScaleTest.Handler
{
    internal class CustomErrorResult : IHttpActionResult
    {
        StringBuilder builder = new StringBuilder();
        private HttpStatusCode httpStatusCode;
        private string message;
        private HttpRequestMessage request;
        private object _requestMessage;

        public CustomErrorResult(HttpRequestMessage request, HttpStatusCode httpStatusCode, string message)
        {
            this.request = request;
            this.httpStatusCode = httpStatusCode;
            this.message = message;
          
            builder.Append(System.DateTime.Now + " " + "-");
            builder.Append(httpStatusCode + " " + "-");
            builder.Append(message);

            File.AppendAllText(@"E:\Log.txt", builder.ToString());

        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(request.CreateErrorResponse(
                httpStatusCode, message));
        }
    }
}
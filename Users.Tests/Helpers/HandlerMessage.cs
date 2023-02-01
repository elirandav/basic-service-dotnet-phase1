using Moq.Protected;
using Moq;
using Newtonsoft.Json;
using System.Net;

namespace Users.Tests.Helpers
{
    public static class HandlerMessage
    {
        public static Mock<HttpMessageHandler> Intercept(String urlToIntercept, object mockResponse)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(JsonConvert.SerializeObject(mockResponse))
            };

            response.Content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var handler = new Mock<HttpMessageHandler>();
            handler.
                Protected().
                Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.Is<HttpRequestMessage>(rm => rm.RequestUri.AbsoluteUri.Equals(urlToIntercept)),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            return handler;
        }
    }
}

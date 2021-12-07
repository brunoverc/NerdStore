using NSE.WebApp.MVC.Extensions;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services.Handlers
{
    public class HttpClientAuthorizationDelegationHandler : DelegatingHandler
    {
        private readonly IUser _user;

        public HttpClientAuthorizationDelegationHandler(IUser user)
        {
            _user = user;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var authorizationHeader = _user.ObterHttpContext().Request.Headers["Authorization"];

            if(!string.IsNullOrEmpty(authorizationHeader))
            {
                request.Headers.Add(name: "Authorization", new List<string>() { authorizationHeader });
            }

            var token = _user.ObterUserToken();

            if(token != null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue(scheme: "Bearer", parameter: token);
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}

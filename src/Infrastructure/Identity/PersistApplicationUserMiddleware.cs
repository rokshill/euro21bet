using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Euro21bet.Application.Common.Interfaces.Identity;
using Euro21bet.Application.Common.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Euro21bet.Infrastructure.Identity
{
    public class PersistApplicationUserMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ClaimsTypesSettings _claimsTypesSettings;

        public PersistApplicationUserMiddleware(RequestDelegate next, IOptions<ClaimsTypesSettings> claimsTypesSettings)
        {
            _next = next;
            _claimsTypesSettings = claimsTypesSettings.Value;
        }

        public async Task InvokeAsync(HttpContext httpContext, IUserService userService, ICurrentIdentitySetter currentIdentitySetter)
        {
            if (httpContext.User.Identity is {IsAuthenticated: true} && httpContext.User.Claims.Any())
            {
                var claims = httpContext.User.Claims.ToList();

                dynamic userInfo = await FetchUserInfoAsync(httpContext);

                var email = userInfo.email.ToString();
                var name = userInfo.name.ToString();
                var nickname = userInfo.nickname.ToString();
                var picture = userInfo.picture.ToString();
                var permissions = claims.GetClaims(_claimsTypesSettings.Permissions).ToList();
                
                await userService.EnsureUserExists(email, nickname, name, picture, permissions);
                currentIdentitySetter.SetIdentity(email, nickname, name, permissions);
            }

            await _next.Invoke(httpContext);
        }

        private async Task<object> FetchUserInfoAsync(HttpContext httpContext)
        {
            if (!httpContext.User.Identity.IsAuthenticated)
                return null;

            var userInfoUrl = httpContext.User.Claims.First(c => c.Type == "aud" && c.Value.Contains("userinfo")).Value;

            var request = new HttpRequestMessage(HttpMethod.Get, userInfoUrl);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await httpContext.GetTokenAsync("access_token"));


            var httpClient = new HttpClient();
            var response = await httpClient.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseStr = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject(responseStr);
            }

            return null;
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace NSE.WebAPI.Core.Identity
{
    public class CustomAuthorize
    {
        public static bool ValidateClaimsUser(HttpContext context, string claimName, string claimValue)
        {
            return context.User.Identity.IsAuthenticated &&
                context.User.Claims.Any(c => c.Type == claimName && c.Value.Contains(claimValue));
        }
    }

    public class ClaimsAuthorizeAttribute : TypeFilterAttribute
    {
        public ClaimsAuthorizeAttribute(string claimName, string claimValue): base(type: typeof(RequirementClaimFilter))
        {
            Arguments = new object[] { new Claim(type: claimName, claimValue) };
        }
    }

    public class RequirementClaimFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;

        public RequirementClaimFilter(Claim claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new StatusCodeResult(statusCode: 401);
                return;
            }

            if(!CustomAuthorize.ValidateClaimsUser(context.HttpContext, claimName: _claim.Type, , _claim.Value))
            {
                context.Result = new StatusCodeResult(statusCode: 403);
            }
        }

    }


}

using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WeatherApi.Policies.AcceptedDomains.Requirements;

namespace WeatherApi.Policies.AcceptedDomains.Handlers
{
    public class AcceptedDomainsHandler : AuthorizationHandler<AcceptedDomainsRequirement>
    {
        private readonly string[] domains = { "@vdh.be", "@tom.be" };
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AcceptedDomainsRequirement requirement)
        {
            if(context.User.HasClaim(c => c.Type == ClaimTypes.Email))
            {
                //var email = context.User.Claims.Where(c => c.Type == ClaimTypes.Email).Select(c => c.Value.ToString().ToLower()).FirstOrDefault();

                //if (email != null)
                //    foreach (var domain in domains)
                //        if (email.EndsWith(domain))
                //            context.Succeed(requirement);

                var email = context.User.Claims.Where(c => c.Type == ClaimTypes.Email).Select(c => c.Value.ToString().ToLower()).First();

                foreach (var domain in domains)
                    if (email.EndsWith(domain))
                        context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi.Shared.Policies.AcceptedDomains.Requirements
{
    public class AcceptedDomainsRequirement: IAuthorizationRequirement
    {}
}

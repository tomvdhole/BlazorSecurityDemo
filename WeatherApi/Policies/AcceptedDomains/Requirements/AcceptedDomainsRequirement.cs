using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi.Policies.AcceptedDomains.Requirements
{
    public class AcceptedDomainsRequirement: IAuthorizationRequirement
    {}
}

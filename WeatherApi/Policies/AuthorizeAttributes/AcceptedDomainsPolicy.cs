using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi.Policies.AuthorizeAttributes
{
    public class AcceptedDomainsPolicy: AuthorizeAttribute
    {
        public AcceptedDomainsPolicy()
        {
            Policy = Constants.Policies.AcceptedDomains;
        }
    }
}

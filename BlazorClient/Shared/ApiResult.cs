using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorClient.Shared
{
    public class ApiResult<T>
    {
        public string StatusCode { get; set; }
        public string Error { get; set; }
        public T Content { get; set; }
    }
}

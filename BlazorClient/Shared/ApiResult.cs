using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorClient.Shared
{
    public class ApiResult<T>
    {
        public int StatusCode { get; set; }
        public string Error { get; set; }
        public T Content { get; set; }
    }
}

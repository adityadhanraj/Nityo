using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nityo.Mocks
{
    internal interface IMyHttpClient
    {
        Task<HttpResponseMessage> GetAsync(string url);
    }
}

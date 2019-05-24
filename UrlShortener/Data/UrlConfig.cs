using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener.Data
{
    public class UrlConfig
    {
        public string UrlPrefix { get; set; }
        public int DaysUntilExpire { get; set; }
    }
}

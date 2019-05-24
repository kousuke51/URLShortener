using Queries.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Data;
using UrlShortener.Interfaces;
using UrlShortener.Models;

namespace UrlShortener.Repository
{
    public class UrlInfoRepository : Repository<UrlInfo>, IUrlInfoRepository
    {
        public UrlInfoRepository(UrlInfoContext context)
            : base(context)
        {
        }

        public UrlInfoContext UrlInfoContext
        {
            get { return Context as UrlInfoContext; }
        }
    }
}

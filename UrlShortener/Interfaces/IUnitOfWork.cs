using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUrlInfoRepository UrlInfo { get; }
        int Complete();
    }
}

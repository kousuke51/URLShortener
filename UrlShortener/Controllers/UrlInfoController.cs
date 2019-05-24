using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using UrlShortener.Data;
using UrlShortener.Models;
using UrlShortener.Utility;

namespace UrlShortener.Controllers
{
    public class UrlInfoController : Controller
    {
        private readonly UrlInfoContext _context;
        private readonly IOptions<UrlConfig> _config;
        private ILogger _logger;

        public UrlInfoController(UrlInfoContext context, IOptions<UrlConfig> config, ILogger<UrlInfoController> logger)
        {
            _context = context;
            this._config = config;
            this._logger = logger;
        }

        // GET: UrlInfo
        [HttpGet]
        public IActionResult Index()
        {
            return View(new UrlInfo());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([Bind("LongUrl")] UrlInfo urlInfo)
        {
            if (ModelState.IsValid)
            {
                UrlHelper.GenerateShortUrl(ref urlInfo, _config.Value.UrlPrefix, _context, _config.Value.DaysUntilExpire, _logger);
            }
            return View(urlInfo);
        }

        //(TO DO) We can use Authorize to check for Admin functionality if we implemented security like ASP.NET Identity 
        //[Authorize]  
        [HttpGet]
        public IActionResult URLListing()
        {
            var model = UrlHelper.GetUrlListing(_context, _logger);
            return View(model);
        }
    }
}

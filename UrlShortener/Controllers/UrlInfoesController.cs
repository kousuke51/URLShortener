using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Data;
using UrlShortener.Models;

namespace UrlShortener.Controllers
{
    public class UrlInfoesController : Controller
    {
        private readonly UrlInfoContext _context;

        public UrlInfoesController(UrlInfoContext context)
        {
            _context = context;
        }

        // GET: UrlInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.UrlInfo.ToListAsync());
        }

        // GET: UrlInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urlInfo = await _context.UrlInfo
                .FirstOrDefaultAsync(m => m.UrlInfoId == id);
            if (urlInfo == null)
            {
                return NotFound();
            }

            return View(urlInfo);
        }

        // GET: UrlInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UrlInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UrlInfoId,ShortUrl,LongUrl,Suffix,CreatedDate,UpdatedDate,ExpirationDate")] UrlInfo urlInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(urlInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(urlInfo);
        }

        // GET: UrlInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urlInfo = await _context.UrlInfo.FindAsync(id);
            if (urlInfo == null)
            {
                return NotFound();
            }
            return View(urlInfo);
        }

        // POST: UrlInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UrlInfoId,ShortUrl,LongUrl,Suffix,CreatedDate,UpdatedDate,ExpirationDate")] UrlInfo urlInfo)
        {
            if (id != urlInfo.UrlInfoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(urlInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UrlInfoExists(urlInfo.UrlInfoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(urlInfo);
        }

        // GET: UrlInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urlInfo = await _context.UrlInfo
                .FirstOrDefaultAsync(m => m.UrlInfoId == id);
            if (urlInfo == null)
            {
                return NotFound();
            }

            return View(urlInfo);
        }

        // POST: UrlInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var urlInfo = await _context.UrlInfo.FindAsync(id);
            _context.UrlInfo.Remove(urlInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UrlInfoExists(int id)
        {
            return _context.UrlInfo.Any(e => e.UrlInfoId == id);
        }
    }
}

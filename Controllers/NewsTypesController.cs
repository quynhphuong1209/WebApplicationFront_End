using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationFront_End.Models;

namespace WebApplicationFront_End.Controllers
{
    public class NewsTypesController : Controller
    {
        private readonly QuynhPhuongContext _context;

        public NewsTypesController(QuynhPhuongContext context)
        {
            _context = context;
        }

        // GET: NewsTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.NewsTypes.ToListAsync());
        }

        // GET: NewsTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsType = await _context.NewsTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newsType == null)
            {
                return NotFound();
            }

            return View(newsType);
        }

        // GET: NewsTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NewsTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Sort,DateCreated,IsShow,IsDeleted")] NewsType newsType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newsType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newsType);
        }

        // GET: NewsTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsType = await _context.NewsTypes.FindAsync(id);
            if (newsType == null)
            {
                return NotFound();
            }
            return View(newsType);
        }

        // POST: NewsTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Sort,DateCreated,IsShow,IsDeleted")] NewsType newsType)
        {
            if (id != newsType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newsType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsTypeExists(newsType.Id))
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
            return View(newsType);
        }

        // GET: NewsTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsType = await _context.NewsTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newsType == null)
            {
                return NotFound();
            }

            return View(newsType);
        }

        // POST: NewsTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newsType = await _context.NewsTypes.FindAsync(id);
            if (newsType != null)
            {
                _context.NewsTypes.Remove(newsType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsTypeExists(int id)
        {
            return _context.NewsTypes.Any(e => e.Id == id);
        }
    }
}

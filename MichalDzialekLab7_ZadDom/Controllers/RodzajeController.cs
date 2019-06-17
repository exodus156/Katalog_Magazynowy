using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MichalDzialekLab7_ZadDom.Models;
using MichalDzialekLab7_ZadDom.Services;

namespace MichalDzialekLab7_ZadDom.Controllers
{
    public class RodzajeController : Controller
    {
        private readonly KatalogContext _context;
        private readonly IKatalogService _katalogService;

        public RodzajeController(KatalogContext context, IKatalogService katalogService)
        {
            _context = context;
            _katalogService = katalogService;
        }

        public async Task<IActionResult> Description(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var description = _katalogService.RodzajDTO(id);

            return View(description);
        }

        // GET: Rodzaje
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rodzaje.ToListAsync());
        }

        // GET: Rodzaje/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rodzaj = await _context.Rodzaje
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rodzaj == null)
            {
                return NotFound();
            }

            return View(rodzaj);
        }

        // GET: Rodzaje/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rodzaje/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description")] Rodzaj rodzaj)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rodzaj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rodzaj);
        }

        // GET: Rodzaje/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rodzaj = await _context.Rodzaje.FindAsync(id);
            if (rodzaj == null)
            {
                return NotFound();
            }
            return View(rodzaj);
        }

        // POST: Rodzaje/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description")] Rodzaj rodzaj)
        {
            if (id != rodzaj.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rodzaj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RodzajExists(rodzaj.ID))
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
            return View(rodzaj);
        }

        // GET: Rodzaje/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rodzaj = await _context.Rodzaje
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rodzaj == null)
            {
                return NotFound();
            }

            return View(rodzaj);
        }

        // POST: Rodzaje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rodzaj = await _context.Rodzaje.FindAsync(id);
            _context.Rodzaje.Remove(rodzaj);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RodzajExists(int id)
        {
            return _context.Rodzaje.Any(e => e.ID == id);
        }
    }
}

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
    public class TypyController : Controller
    {
        private readonly KatalogContext _context;
        private readonly IKatalogService _katalogService;

        public TypyController(KatalogContext context, IKatalogService katalogService)
        {
            _context = context;
            _katalogService = katalogService;
        }

        // GET: Typy
        public async Task<IActionResult> Index()
        {
            return View(await _context.Typy.ToListAsync());
        }

        public async Task<IActionResult> Description(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var description = _katalogService.TypDTO(id);

            return View(description);
        }

        // GET: Typy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typ = await _context.Typy
                .FirstOrDefaultAsync(m => m.ID == id);
            if (typ == null)
            {
                return NotFound();
            }

            return View(typ);
        }

        // GET: Typy/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Typy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description")] Typ typ)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typ);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typ);
        }

        // GET: Typy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typ = await _context.Typy.FindAsync(id);
            if (typ == null)
            {
                return NotFound();
            }
            return View(typ);
        }

        // POST: Typy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description")] Typ typ)
        {
            if (id != typ.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typ);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypExists(typ.ID))
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
            return View(typ);
        }

        // GET: Typy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typ = await _context.Typy
                .FirstOrDefaultAsync(m => m.ID == id);
            if (typ == null)
            {
                return NotFound();
            }

            return View(typ);
        }

        // POST: Typy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typ = await _context.Typy.FindAsync(id);
            _context.Typy.Remove(typ);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypExists(int id)
        {
            return _context.Typy.Any(e => e.ID == id);
        }
    }
}

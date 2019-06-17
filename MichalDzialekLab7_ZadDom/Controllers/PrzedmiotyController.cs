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
    public class PrzedmiotyController : Controller
    {
        private readonly KatalogContext _context;
        private readonly IKatalogService _katalogService;

        public PrzedmiotyController(KatalogContext context, IKatalogService katalogService)
        {
            _context = context;
            _katalogService = katalogService;
        }

        // GET: Przedmioty
        public async Task<IActionResult> Index()
        {
            var katalogContext = _context.Przedmioty.Include(p => p.Kategoria).Include(p => p.Rodzaj).Include(p => p.Typ);
            return View(await katalogContext.ToListAsync());
        }

        public async Task<IActionResult> Description(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var description = _katalogService.PrzedmiotDTO(id);

            return View(description);
        }

        // GET: Przedmioty/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var przedmiot = await _context.Przedmioty
                .Include(p => p.Kategoria)
                .Include(p => p.Rodzaj)
                .Include(p => p.Typ)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (przedmiot == null)
            {
                return NotFound();
            }

            return View(przedmiot);
        }

        // GET: Przedmioty/Create
        public IActionResult Create()
        {
            ViewData["KategoriaID"] = new SelectList(_context.Kategorie, "ID", "Name");
            ViewData["RodzajID"] = new SelectList(_context.Rodzaje, "ID", "Name");
            ViewData["TypID"] = new SelectList(_context.Typy, "ID", "Name");
            return View();
        }

        // POST: Przedmioty/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nazwa,KategoriaID,TypID,RodzajID,Ilosc,Price,SerialNumber,CreationDate,Description")] Przedmiot przedmiot)
        {
            if (ModelState.IsValid)
            {
                DateTime dateTime = DateTime.Now;
                przedmiot.CreationDate = dateTime;
                _context.Add(przedmiot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategoriaID"] = new SelectList(_context.Kategorie, "ID", "Name", przedmiot.KategoriaID);
            ViewData["RodzajID"] = new SelectList(_context.Rodzaje, "ID", "Name", przedmiot.RodzajID);
            ViewData["TypID"] = new SelectList(_context.Typy, "ID", "Name", przedmiot.TypID);
            return View(przedmiot);
        }

        // GET: Przedmioty/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var przedmiot = await _context.Przedmioty.FindAsync(id);
            if (przedmiot == null)
            {
                return NotFound();
            }
            ViewData["KategoriaID"] = new SelectList(_context.Kategorie, "ID", "Name", przedmiot.KategoriaID);
            ViewData["RodzajID"] = new SelectList(_context.Rodzaje, "ID", "Name", przedmiot.RodzajID);
            ViewData["TypID"] = new SelectList(_context.Typy, "ID", "Name", przedmiot.TypID);
            return View(przedmiot);
        }

        // POST: Przedmioty/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nazwa,KategoriaID,TypID,RodzajID,Ilosc,Price,SerialNumber,CreationDate,Description")] Przedmiot przedmiot)
        {
            if (id != przedmiot.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(przedmiot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrzedmiotExists(przedmiot.ID))
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
            ViewData["KategoriaID"] = new SelectList(_context.Kategorie, "ID", "Name", przedmiot.KategoriaID);
            ViewData["RodzajID"] = new SelectList(_context.Rodzaje, "ID", "Name", przedmiot.RodzajID);
            ViewData["TypID"] = new SelectList(_context.Typy, "ID", "Name", przedmiot.TypID);
            return View(przedmiot);
        }

        // GET: Przedmioty/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var przedmiot = await _context.Przedmioty
                .Include(p => p.Kategoria)
                .Include(p => p.Rodzaj)
                .Include(p => p.Typ)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (przedmiot == null)
            {
                return NotFound();
            }

            return View(przedmiot);
        }

        // POST: Przedmioty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var przedmiot = await _context.Przedmioty.FindAsync(id);
            _context.Przedmioty.Remove(przedmiot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrzedmiotExists(int id)
        {
            return _context.Przedmioty.Any(e => e.ID == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Organi.Za.Organizaciju.Data;

namespace Organi.Za.Organizaciju.Controllers
{
    public class PotrebnaOpremaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PotrebnaOpremaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PotrebnaOpremas
        public async Task<IActionResult> Index(int? id)
        {
            var usluga = _context.Usluge.Find(id);

            if (usluga == null) return NotFound();

            var potrebnaOprema = await _context.PotrebnaOprema
                .Include(p => p.Usluga)
                .Include(p => p.Oprema)
                .Where(m => m.UslugaId == id).ToListAsync();

            if (potrebnaOprema == null) return NotFound();

            ViewData["UslugaId"] = id;
            ViewData["NazivUsluge"] = usluga.Naziv;

            return View(potrebnaOprema);

        }

        // GET: PotrebnaOpremas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var potrebnaOprema = await _context.PotrebnaOprema
                .Include(p => p.Oprema)
                .Include(p => p.Usluga)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (potrebnaOprema == null)
            {
                return NotFound();
            }

            return View(potrebnaOprema);
        }

        // GET: PotrebnaOpremas/Create
        public IActionResult Create(int id)
        {
            var usluga = _context.Usluge.FirstOrDefault(x => x.Id == id);

            if (usluga == null) return NotFound("Nazalost ne mozemo pronaci takvu uslugu");

            ViewData["NazivUsluge"] = usluga?.Naziv;
            ViewData["UslugaId"] = usluga?.Id;

            ViewData["OpremaId"] = new SelectList(_context.Opreme, "Id", "Naziv");
            return View();
        }

        // POST: PotrebnaOpremas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UslugaId,OpremaId,Kolicina")] PotrebnaOprema potrebnaOprema)
        {
            if (ModelState.IsValid)
            {
                potrebnaOprema.Id = 0;

                _context.Add(potrebnaOprema);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new {id = potrebnaOprema.UslugaId });
            }
            ViewData["OpremaId"] = new SelectList(_context.Opreme, "Id", "Naziv", potrebnaOprema.OpremaId);
            ViewData["UslugaId"] = new SelectList(_context.Usluge, "Id", "Naziv", potrebnaOprema.UslugaId);
            return View(potrebnaOprema);
        }

        // GET: PotrebnaOpremas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var potrebnaOprema = await _context.PotrebnaOprema.FindAsync(id);
            if (potrebnaOprema == null)
            {
                return NotFound();
            }
            ViewData["OpremaId"] = new SelectList(_context.Opreme, "Id", "Naziv", potrebnaOprema.OpremaId);
            ViewData["UslugaId"] = new SelectList(_context.Usluge, "Id", "Naziv", potrebnaOprema.UslugaId);
            return View(potrebnaOprema);
        }

        // POST: PotrebnaOpremas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UslugaId,OpremaId,Kolicina")] PotrebnaOprema potrebnaOprema)
        {
            if (id != potrebnaOprema.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(potrebnaOprema);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PotrebnaOpremaExists(potrebnaOprema.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = potrebnaOprema.UslugaId });
            }
            ViewData["OpremaId"] = new SelectList(_context.Opreme, "Id", "Naziv", potrebnaOprema.OpremaId);
            ViewData["UslugaId"] = new SelectList(_context.Usluge, "Id", "Naziv", potrebnaOprema.UslugaId);
            return View(potrebnaOprema);
        }

        // GET: PotrebnaOpremas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var potrebnaOprema = await _context.PotrebnaOprema
                .Include(p => p.Oprema)
                .Include(p => p.Usluga)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (potrebnaOprema == null)
            {
                return NotFound();
            }

            return View(potrebnaOprema);
        }

        // POST: PotrebnaOpremas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var potrebnaOprema = await _context.PotrebnaOprema.FindAsync(id);
            _context.PotrebnaOprema.Remove(potrebnaOprema);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = potrebnaOprema.UslugaId });
        }

        private bool PotrebnaOpremaExists(int id)
        {
            return _context.PotrebnaOprema.Any(e => e.Id == id);
        }
    }
}

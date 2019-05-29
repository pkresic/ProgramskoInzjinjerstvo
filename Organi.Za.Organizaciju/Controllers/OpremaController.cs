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
    public class OpremaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OpremaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Oprema
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Opreme.Include(o => o.ReferentiBroj).Include(o => o.Skladiste);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Oprema/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oprema = await _context.Opreme
                .Include(o => o.ReferentiBroj)
                .Include(o => o.Skladiste)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oprema == null)
            {
                return NotFound();
            }

            return View(oprema);
        }

        // GET: Oprema/Create
        public IActionResult Create()
        {
            ViewData["ReferentiBrojId"] = new SelectList(_context.ReferentiBrojevi, "Id", "Naziv");
            ViewData["SkladisteId"] = new SelectList(_context.Skladista, "Id", "Naziv");
            return View();
        }

        // POST: Oprema/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,Opis,InvertarniBroj,NabavnaCijena,TrenutnaCijena,VrijemeAmortizacije,Kolicina,SkladisteId,DostupnoOd,DostupnoDo,ReferentiBrojId")] Oprema oprema)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oprema);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReferentiBrojId"] = new SelectList(_context.ReferentiBrojevi, "Id", "Naziv", oprema.ReferentiBrojId);
            ViewData["SkladisteId"] = new SelectList(_context.Skladista, "Id", "Naziv", oprema.SkladisteId);
            return View(oprema);
        }

        // GET: Oprema/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oprema = await _context.Opreme.FindAsync(id);
            if (oprema == null)
            {
                return NotFound();
            }
            ViewData["ReferentiBrojId"] = new SelectList(_context.ReferentiBrojevi, "Id", "Naziv", oprema.ReferentiBrojId);
            ViewData["SkladisteId"] = new SelectList(_context.Skladista, "Id", "Naziv", oprema.SkladisteId);
            return View(oprema);
        }

        // POST: Oprema/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,Opis,InvertarniBroj,NabavnaCijena,TrenutnaCijena,VrijemeAmortizacije,Kolicina,SkladisteId,DostupnoOd,DostupnoDo,ReferentiBrojId")] Oprema oprema)
        {
            if (id != oprema.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oprema);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpremaExists(oprema.Id))
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
            ViewData["ReferentiBrojId"] = new SelectList(_context.ReferentiBrojevi, "Id", "Naziv", oprema.ReferentiBrojId);
            ViewData["SkladisteId"] = new SelectList(_context.Skladista, "Id", "Naziv", oprema.SkladisteId);
            return View(oprema);
        }

        // GET: Oprema/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oprema = await _context.Opreme
                .Include(o => o.ReferentiBroj)
                .Include(o => o.Skladiste)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oprema == null)
            {
                return NotFound();
            }

            return View(oprema);
        }

        // POST: Oprema/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oprema = await _context.Opreme.FindAsync(id);
            _context.Opreme.Remove(oprema);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OpremaExists(int id)
        {
            return _context.Opreme.Any(e => e.Id == id);
        }
    }
}

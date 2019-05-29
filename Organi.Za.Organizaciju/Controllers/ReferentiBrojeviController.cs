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
    public class ReferentiBrojeviController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReferentiBrojeviController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReferentiBrojevi
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ReferentiBrojevi.Include(r => r.ReferentiTip);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ReferentiBrojevi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referentiBroj = await _context.ReferentiBrojevi
                .Include(r => r.ReferentiTip)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (referentiBroj == null)
            {
                return NotFound();
            }

            return View(referentiBroj);
        }

        // GET: ReferentiBrojevi/Create
        public IActionResult Create()
        {
            ViewData["ReferentiTipId"] = new SelectList(_context.TipReferentogBroja, "Id", "Naziv");
            return View();
        }

        // POST: ReferentiBrojevi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,Opis,TrenutnaVrijednost,ReferentiTipId")] ReferentiBroj referentiBroj)
        {
            if (ModelState.IsValid)
            {
                _context.Add(referentiBroj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReferentiTipId"] = new SelectList(_context.TipReferentogBroja, "Id", "Naziv", referentiBroj.ReferentiTipId);
            return View(referentiBroj);
        }

        // GET: ReferentiBrojevi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referentiBroj = await _context.ReferentiBrojevi.FindAsync(id);
            if (referentiBroj == null)
            {
                return NotFound();
            }
            ViewData["ReferentiTipId"] = new SelectList(_context.TipReferentogBroja, "Id", "Naziv", referentiBroj.ReferentiTipId);
            return View(referentiBroj);
        }

        // POST: ReferentiBrojevi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,Opis,TrenutnaVrijednost,ReferentiTipId")] ReferentiBroj referentiBroj)
        {
            if (id != referentiBroj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(referentiBroj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReferentiBrojExists(referentiBroj.Id))
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
            ViewData["ReferentiTipId"] = new SelectList(_context.TipReferentogBroja, "Id", "Naziv", referentiBroj.ReferentiTipId);
            return View(referentiBroj);
        }

        // GET: ReferentiBrojevi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referentiBroj = await _context.ReferentiBrojevi
                .Include(r => r.ReferentiTip)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (referentiBroj == null)
            {
                return NotFound();
            }

            return View(referentiBroj);
        }

        // POST: ReferentiBrojevi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var referentiBroj = await _context.ReferentiBrojevi.FindAsync(id);
            _context.ReferentiBrojevi.Remove(referentiBroj);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReferentiBrojExists(int id)
        {
            return _context.ReferentiBrojevi.Any(e => e.Id == id);
        }
    }
}

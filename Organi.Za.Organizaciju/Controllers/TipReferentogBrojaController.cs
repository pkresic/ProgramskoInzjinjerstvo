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
    public class TipReferentogBrojaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipReferentogBrojaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipReferentogBrojas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipReferentogBroja.ToListAsync());
        }

        // GET: TipReferentogBrojas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipReferentogBroja = await _context.TipReferentogBroja
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipReferentogBroja == null)
            {
                return NotFound();
            }

            return View(tipReferentogBroja);
        }

        // GET: TipReferentogBrojas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipReferentogBrojas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,Opis")] TipReferentogBroja tipReferentogBroja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipReferentogBroja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipReferentogBroja);
        }

        // GET: TipReferentogBrojas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipReferentogBroja = await _context.TipReferentogBroja.FindAsync(id);
            if (tipReferentogBroja == null)
            {
                return NotFound();
            }
            return View(tipReferentogBroja);
        }

        // POST: TipReferentogBrojas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,Opis")] TipReferentogBroja tipReferentogBroja)
        {
            if (id != tipReferentogBroja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipReferentogBroja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipReferentogBrojaExists(tipReferentogBroja.Id))
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
            return View(tipReferentogBroja);
        }

        // GET: TipReferentogBrojas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipReferentogBroja = await _context.TipReferentogBroja
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipReferentogBroja == null)
            {
                return NotFound();
            }

            return View(tipReferentogBroja);
        }

        // POST: TipReferentogBrojas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipReferentogBroja = await _context.TipReferentogBroja.FindAsync(id);
            _context.TipReferentogBroja.Remove(tipReferentogBroja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipReferentogBrojaExists(int id)
        {
            return _context.TipReferentogBroja.Any(e => e.Id == id);
        }
    }
}

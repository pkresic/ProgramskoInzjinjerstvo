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
    public class DodijeljenaOpremaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DodijeljenaOpremaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DodijeljenaOprema
        public async Task<IActionResult> Index(int? id)
        {
            var posao = _context.SklopljeniPoslovi.Find(id);

            if (posao == null) return NotFound();

            var dodijeljanOprema = await _context.DodijeljenaOprema
                .Include(x => x.Oprema)
                .Include(x => x.Posao)
                .Where(x => x.PosaoId == id).ToListAsync();

            ViewData["PosaoId"] = id;
            ViewData["NazivPosla"] = posao.Naziv;

            return View(dodijeljanOprema);
        }

        // GET: DodijeljenaOprema/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dodijeljenaOprema = await _context.DodijeljenaOprema
                .Include(d => d.Oprema)
                .Include(d => d.Posao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dodijeljenaOprema == null)
            {
                return NotFound();
            }

            return View(dodijeljenaOprema);
        }

        // GET: DodijeljenaOprema/Create
        public IActionResult Create(int id)
        {
            var posao = _context.SklopljeniPoslovi.FirstOrDefault(x => x.Id == id);

            if (posao == null) return NotFound("Nazalost ne mozemo pronaci takav posao");

            ViewData["NazivPosla"] = posao?.Naziv;
            ViewData["PosaoId"] = posao?.Id;

            ViewData["OpremaId"] = new SelectList(_context.Opreme, "Id", "Naziv");
            return View();
        }

        // POST: DodijeljenaOprema/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OpremaId,BrojOpreme,PosaoId")] DodijeljenaOprema dodijeljenaOprema)
        {
            if (ModelState.IsValid)
            {
                dodijeljenaOprema.Id = 0;

                var opremaPoDogadjaju = await _context.DodijeljenaOprema.Include(x => x.Posao).Where(x => x.OpremaId == dodijeljenaOprema.OpremaId).ToListAsync();
                var selektiraniPosao = await _context.SklopljeniPoslovi.FindAsync(dodijeljenaOprema.PosaoId);

                ViewData["OpremaId"] = new SelectList(_context.Opreme, "Id", "Naziv", dodijeljenaOprema.OpremaId);
                ViewData["NazivPosla"] = selektiraniPosao?.Naziv;
                ViewData["PosaoId"] = selektiraniPosao?.Id;

                if (opremaPoDogadjaju != null)
                {
                    foreach (var item in opremaPoDogadjaju)
                    {

                        if (item.Posao.VrijemeRadaOd == selektiraniPosao?.VrijemeRadaOd && item.Posao.VrijemeRadaDo == selektiraniPosao.VrijemeRadaDo)
                        {
                                ModelState.AddModelError(string.Empty, "Ova oprema je zauzeta.");
                                return View(dodijeljenaOprema);
                        }

                        if (item.Posao.VrijemeRadaOd <= selektiraniPosao?.VrijemeRadaDo && selektiraniPosao.VrijemeRadaOd <= item.Posao.VrijemeRadaDo)
                        {
                            ModelState.AddModelError(string.Empty, "Ova oprema je vec zauzeta.");
                            return View(dodijeljenaOprema);
                        }
                    }
                }

                _context.Add(dodijeljenaOprema);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dodijeljenaOprema);
        }

        // GET: DodijeljenaOprema/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dodijeljenaOprema = await _context.DodijeljenaOprema.Include(x => x.Posao).FirstOrDefaultAsync(x => x.Id == id);
            if (dodijeljenaOprema == null)
            {
                return NotFound();
            }
            ViewData["OpremaId"] = new SelectList(_context.Opreme, "Id", "Id", dodijeljenaOprema.OpremaId);

            ViewData["NazivPosla"] = dodijeljenaOprema?.Posao?.Naziv;
            ViewData["PosaoId"] = dodijeljenaOprema?.Posao?.Id;

            return View(dodijeljenaOprema);
        }

        // POST: DodijeljenaOprema/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OpremaId,BrojOpreme,PosaoId")] DodijeljenaOprema dodijeljenaOprema)
        {
            if (id != dodijeljenaOprema.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dodijeljenaOprema);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DodijeljenaOpremaExists(dodijeljenaOprema.Id))
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
            ViewData["OpremaId"] = new SelectList(_context.Opreme, "Id", "Id", dodijeljenaOprema.OpremaId);

            ViewData["NazivPosla"] = dodijeljenaOprema?.Posao?.Naziv;
            ViewData["PosaoId"] = dodijeljenaOprema?.Posao?.Id;

            return View(dodijeljenaOprema);
        }

        // GET: DodijeljenaOprema/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dodijeljenaOprema = await _context.DodijeljenaOprema
                .Include(d => d.Oprema)
                .Include(d => d.Posao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dodijeljenaOprema == null)
            {
                return NotFound();
            }

            return View(dodijeljenaOprema);
        }

        // POST: DodijeljenaOprema/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dodijeljenaOprema = await _context.DodijeljenaOprema.FindAsync(id);
            _context.DodijeljenaOprema.Remove(dodijeljenaOprema);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DodijeljenaOpremaExists(int id)
        {
            return _context.DodijeljenaOprema.Any(e => e.Id == id);
        }
    }
}

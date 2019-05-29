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
    public class OsobeZaPosaoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OsobeZaPosaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OsobeZaPosao
        public async Task<IActionResult> Index(int? id)
        {
            var posao = _context.SklopljeniPoslovi.Find(id);

            if (posao == null) return NotFound();

            var dodijenjeOsobe = await _context.DodijeljeneOsobe
                .Include(x => x.Osoba)
                .Include(x => x.Posao)
                .Where(x => x.PosaoId == id).ToListAsync();

            ViewData["PosaoId"] = id;
            ViewData["NazivPosla"] = posao.Naziv;

            return View(dodijenjeOsobe);
        }

        // GET: OsobeZaPosao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dodijeljeneOsobe = await _context.DodijeljeneOsobe
                .Include(d => d.Osoba)
                .Include(d => d.Posao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dodijeljeneOsobe == null)
            {
                return NotFound();
            }

            return View(dodijeljeneOsobe);
        }

        // GET: OsobeZaPosao/Create
        public IActionResult Create(int id)
        {
            var posao = _context.SklopljeniPoslovi.FirstOrDefault(x => x.Id == id);

            if (posao == null) return NotFound("Nazalost ne mozemo pronaci takav posao");

            ViewData["NazivPosla"] = posao?.Naziv;
            ViewData["PosaoId"] = posao?.Id;

            ViewData["OsobaId"] = new SelectList(_context.Osobe, "Id", "Ime");

            return View();
        }

        // POST: OsobeZaPosao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OsobaId,BrojOsoba,PosaoId")] DodijeljeneOsobe dodijeljeneOsobe)
        {
            if (ModelState.IsValid)
            {
                dodijeljeneOsobe.Id = 0;
                dodijeljeneOsobe.BrojOsoba = 1;

                var posloviOsobe = await _context.DodijeljeneOsobe.Include(x => x.Posao).Where(x => x.OsobaId == dodijeljeneOsobe.OsobaId).ToListAsync();
                var selektiraniPosao = await _context.SklopljeniPoslovi.FindAsync(dodijeljeneOsobe.PosaoId);

                ViewData["OsobaId"] = new SelectList(_context.Osobe, "Id", "Ime", dodijeljeneOsobe.OsobaId);
                ViewData["NazivPosla"] = selektiraniPosao?.Naziv;
                ViewData["PosaoId"] = selektiraniPosao?.Id;

                if (posloviOsobe != null)
                {
                    foreach (var item in posloviOsobe)
                    {

                        if (item.Posao.VrijemeRadaOd == selektiraniPosao.VrijemeRadaOd && item.Posao.VrijemeRadaDo == selektiraniPosao.VrijemeRadaDo)
                        {
                            ModelState.AddModelError(string.Empty, "Ova osoba je zauzeta za ovaj posao");
                            return View(dodijeljeneOsobe);
                        }

                        if (item.Posao.VrijemeRadaOd <= selektiraniPosao.VrijemeRadaDo && selektiraniPosao.VrijemeRadaOd <= item.Posao.VrijemeRadaDo)
                        {
                            ModelState.AddModelError(string.Empty, "Ova osoba je zauzeta za ovaj posao");
                            return View(dodijeljeneOsobe);
                        }
                    }
                }

                _context.Add(dodijeljeneOsobe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new{id = dodijeljeneOsobe.PosaoId});
            }
            return View(dodijeljeneOsobe);
        }

        // GET: OsobeZaPosao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dodijeljeneOsobe = await _context.DodijeljeneOsobe.Include(x => x.Posao).FirstOrDefaultAsync(x => x.Id == id);
            if (dodijeljeneOsobe == null)
            {
                return NotFound();
            }
            ViewData["OsobaId"] = new SelectList(_context.Osobe, "Id", "Ime", dodijeljeneOsobe.OsobaId);
            ViewData["NazivPosla"] = dodijeljeneOsobe?.Posao?.Naziv;
            ViewData["PosaoId"] = dodijeljeneOsobe?.Posao?.Id;
            return View(dodijeljeneOsobe);
        }

        // POST: OsobeZaPosao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OsobaId,BrojOsoba,PosaoId")] DodijeljeneOsobe dodijeljeneOsobe)
        {
            if (id != dodijeljeneOsobe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dodijeljeneOsobe.BrojOsoba = 1;
                    _context.Update(dodijeljeneOsobe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DodijeljeneOsobeExists(dodijeljeneOsobe.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new {id=  dodijeljeneOsobe.PosaoId});
            }
            ViewData["OsobaId"] = new SelectList(_context.Osobe, "Id", "Ime", dodijeljeneOsobe.OsobaId);
            ViewData["NazivPosla"] = dodijeljeneOsobe?.Posao?.Naziv;
            ViewData["PosaoId"] = dodijeljeneOsobe?.Posao?.Id;
            return View(dodijeljeneOsobe);
        }

        // GET: OsobeZaPosao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dodijeljeneOsobe = await _context.DodijeljeneOsobe
                .Include(d => d.Osoba)
                .Include(d => d.Posao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dodijeljeneOsobe == null)
            {
                return NotFound();
            }

            return View(dodijeljeneOsobe);
        }

        // POST: OsobeZaPosao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dodijeljeneOsobe = await _context.DodijeljeneOsobe.FindAsync(id);
            _context.DodijeljeneOsobe.Remove(dodijeljeneOsobe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = dodijeljeneOsobe.PosaoId });
        }

        private bool DodijeljeneOsobeExists(int id)
        {
            return _context.DodijeljeneOsobe.Any(e => e.Id == id);
        }
    }
}

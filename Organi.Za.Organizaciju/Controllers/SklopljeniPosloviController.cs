using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Organi.Za.Organizaciju.Data;
using Organi.Za.Organizaciju.ViewModels;

namespace Organi.Za.Organizaciju.Controllers
{
    public class SklopljeniPosloviController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SklopljeniPosloviController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SklopljeniPoslovi
        public async Task<IActionResult> Index(int? id)
        {
            var poslovi = await _context
                .SklopljeniPoslovi
                .Include(x => x.Ponuda)
                .Include(s => s.Lokacija)
                .Include(s => s.Usluga).ToListAsync();


            SklopljeniPosao selektiraniPosao = null;

            if (id != null)
                selektiraniPosao = await _context.SklopljeniPoslovi
                    .Include(x => x.DodijeljenaOprema)
                    .ThenInclude(x => x.Oprema)
                    .Include(x => x.DodijeljeneOsobe)
                    .ThenInclude(x => x.Osoba)
                    .FirstOrDefaultAsync(x => x.Id == id);

            var vm = new PosloviViewModel
            {
                Poslovi = poslovi,
                DodijeljeneOsobe = selektiraniPosao?.DodijeljeneOsobe.Select(x => x.Osoba),
                DodideljenaOprema = selektiraniPosao?.DodijeljenaOprema.Select(x => x.Oprema)
            };

            return View(vm);
        }

        // GET: SklopljeniPoslovi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var sklopljeniPosao = await _context.SklopljeniPoslovi
                .Include(s => s.Lokacija)
                .Include(s => s.Usluga)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sklopljeniPosao == null) return NotFound();

            return View(sklopljeniPosao);
        }

        // GET: SklopljeniPoslovi/Create
        public IActionResult Create(int? id)
        {
            var ponuda = _context.PonudaZaNatjecaj.Find(id);

            if (ponuda != null)
            {
                ViewData["PonudaId"] = ponuda.Id;
                ViewData["NazivPonude"] = ponuda.Naziv;
            }

            ViewData["LokacijaId"] = new SelectList(_context.Lokacije, "Id", "LokalniNaziv");
            ViewData["UslugaId"] = new SelectList(_context.Usluge, "Id", "Naziv");
            return View();
        }

        // POST: SklopljeniPoslovi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Naziv,Opis,UslugaId,Vrijeme,LokacijaId,DogovorenaCijena,PonudaId")]
            SklopljeniPosao sklopljeniPosao)
        {
            if (ModelState.IsValid)
            {
                sklopljeniPosao.Id = 0;
                _context.Add(sklopljeniPosao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["LokacijaId"] =
                new SelectList(_context.Lokacije, "Id", "LokalniNaziv", sklopljeniPosao.LokacijaId);
            ViewData["UslugaId"] = new SelectList(_context.Usluge, "Id", "Naziv", sklopljeniPosao.UslugaId);
            return View(sklopljeniPosao);
        }

        // GET: SklopljeniPoslovi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var sklopljeniPosao = await _context.SklopljeniPoslovi
                .Include(x => x.Usluga)
                .Include(x => x.Ponuda)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (sklopljeniPosao == null) return NotFound();

            if (sklopljeniPosao.Ponuda != null)
            {
                ViewData["PonudaId"] = sklopljeniPosao?.Ponuda?.Id;
                ViewData["NazivPonude"] = sklopljeniPosao?.Ponuda?.Naziv;
            }

            ViewData["LokacijaId"] =
                new SelectList(_context.Lokacije, "Id", "LokalniNaziv", sklopljeniPosao.LokacijaId);
            ViewData["UslugaId"] = new SelectList(_context.Usluge, "Id", "Naziv", sklopljeniPosao.UslugaId);
            return View(sklopljeniPosao);
        }

        // POST: SklopljeniPoslovi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,Naziv,Opis,UslugaId,Vrijeme,LokacijaId,DogovorenaCijena,PonudaId")]
            SklopljeniPosao sklopljeniPosao)
        {
            if (id != sklopljeniPosao.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sklopljeniPosao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SklopljeniPosaoExists(sklopljeniPosao.Id))
                        return NotFound();
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["LokacijaId"] =
                new SelectList(_context.Lokacije, "Id", "LokalniNaziv", sklopljeniPosao.LokacijaId);
            ViewData["UslugaId"] = new SelectList(_context.Usluge, "Id", "Naziv", sklopljeniPosao.UslugaId);
            return View(sklopljeniPosao);
        }

        // GET: SklopljeniPoslovi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var sklopljeniPosao = await _context.SklopljeniPoslovi
                .Include(s => s.Lokacija)
                .Include(s => s.Usluga)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sklopljeniPosao == null) return NotFound();

            return View(sklopljeniPosao);
        }

        // POST: SklopljeniPoslovi/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sklopljeniPosao = await _context.SklopljeniPoslovi.FindAsync(id);
            _context.SklopljeniPoslovi.Remove(sklopljeniPosao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SklopljeniPosaoExists(int id)
        {
            return _context.SklopljeniPoslovi.Any(e => e.Id == id);
        }
    }
}
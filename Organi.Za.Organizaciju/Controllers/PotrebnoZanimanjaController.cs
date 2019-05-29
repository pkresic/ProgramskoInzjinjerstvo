using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Organi.Za.Organizaciju.Data;

namespace Organi.Za.Organizaciju.Controllers
{
    public class PotrebnoZanimanjaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PotrebnoZanimanjaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PotrebnoZanimanja
        public async Task<IActionResult> Index(int? id)
        {
            var usluga = _context.Usluge.Find(id);

            if (usluga == null) return NotFound();

            var zanimanja = await _context.PotrebnoZanimanje
                .Include(p => p.Usluga)
                .Include(p => p.Zanimanje)
                .Where(m => m.UslugaId == id).ToListAsync();

            if (zanimanja == null) return NotFound();

            ViewData["UslugaId"] = id;
            ViewData["NazivUsluge"] = usluga.Naziv;

            return View(zanimanja);
        }

        // GET: PotrebnoZanimanja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var potrebnoZanimanje = await _context.PotrebnoZanimanje
                .Include(p => p.Usluga)
                .Include(p => p.Zanimanje)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (potrebnoZanimanje == null) return NotFound();

            return View(potrebnoZanimanje);
        }

        // GET: PotrebnoZanimanja/Create
        public IActionResult Create(int id)
        {
            var usluga = _context.Usluge.FirstOrDefault(x => x.Id == id);

            if (usluga == null) return NotFound("Nazalost ne mozemo pronaci takvu uslugu");

            ViewData["NazivUsluge"] = usluga?.Naziv;
            ViewData["UslugaId"] = usluga?.Id;
            ViewData["ZanimanjeId"] = new SelectList(_context.Zanimanja, "Id", "Naziv");
            return View();
        }

        // POST: PotrebnoZanimanja/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,UslugaId,ZanimanjeId,Broj")] PotrebnoZanimanje potrebnoZanimanje)
        {
            if (ModelState.IsValid)
            {
                var usluge = _context.Usluge.Find(potrebnoZanimanje.UslugaId);
                var zanimanje = _context.Zanimanja.Find(potrebnoZanimanje.ZanimanjeId);

                potrebnoZanimanje.Usluga = usluge;
                potrebnoZanimanje.Zanimanje = zanimanje;

                potrebnoZanimanje.Id = 0;

                _context.Add(potrebnoZanimanje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new {id = usluge.Id});
            }

            ViewData["UslugaId"] = new SelectList(_context.Usluge, "Id", "Naziv", potrebnoZanimanje.UslugaId);
            ViewData["ZanimanjeId"] = new SelectList(_context.Zanimanja, "Id", "Naziv", potrebnoZanimanje.ZanimanjeId);
            return View(potrebnoZanimanje);
        }

        // GET: PotrebnoZanimanja/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var potrebnoZanimanje = await _context.PotrebnoZanimanje.FindAsync(id);
            if (potrebnoZanimanje == null) return NotFound();
            ViewData["UslugaId"] = new SelectList(_context.Usluge, "Id", "Naziv", potrebnoZanimanje.UslugaId);
            ViewData["ZanimanjeId"] = new SelectList(_context.Zanimanja, "Id", "Naziv", potrebnoZanimanje.ZanimanjeId);
            return View(potrebnoZanimanje);
        }

        // POST: PotrebnoZanimanja/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,UslugaId,ZanimanjeId,Broj")] PotrebnoZanimanje potrebnoZanimanje)
        {
            if (id != potrebnoZanimanje.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(potrebnoZanimanje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PotrebnoZanimanjeExists(potrebnoZanimanje.Id))
                        return NotFound();
                    throw;
                }

                return RedirectToAction(nameof(Index), new {id = potrebnoZanimanje.UslugaId});
            }

            ViewData["UslugaId"] = new SelectList(_context.Usluge, "Id", "Naziv", potrebnoZanimanje.UslugaId);
            ViewData["ZanimanjeId"] = new SelectList(_context.Zanimanja, "Id", "Naziv", potrebnoZanimanje.ZanimanjeId);
            return View(potrebnoZanimanje);
        }

        // GET: PotrebnoZanimanja/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var potrebnoZanimanje = await _context.PotrebnoZanimanje
                .Include(p => p.Usluga)
                .Include(p => p.Zanimanje)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (potrebnoZanimanje == null) return NotFound();

            return View(potrebnoZanimanje);
        }

        // POST: PotrebnoZanimanja/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var potrebnoZanimanje = await _context.PotrebnoZanimanje.FindAsync(id);
            _context.PotrebnoZanimanje.Remove(potrebnoZanimanje);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new {id = potrebnoZanimanje.UslugaId});
        }

        private bool PotrebnoZanimanjeExists(int id)
        {
            return _context.PotrebnoZanimanje.Any(e => e.Id == id);
        }
    }
}
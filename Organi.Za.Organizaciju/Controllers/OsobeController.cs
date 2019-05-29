using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Organi.Za.Organizaciju.Data;
using Organi.Za.Organizaciju.ViewModels;

namespace Organi.Za.Organizaciju.Controllers
{
    public class OsobeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OsobeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Osobas
        public async Task<IActionResult> Index(int? id)
        {
            var osobe = await _context.Osobe.ToListAsync();

            Osoba selektiranaOsoba = null;

            if (id != null)
            {
                selektiranaOsoba = await _context.Osobe
                    .Include(x => x.Certifikats).ThenInclude(x => x.Certifikat)
                    .Include(x => x.Zanimanja).ThenInclude(x => x.Zanimanje)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }

            var vm = new OsobaViewModel
            {
                Osobe = osobe,
                Certifikati = selektiranaOsoba?.Certifikats.Select(x => x.Certifikat).ToList(),
                Zanimanja = selektiranaOsoba?.Zanimanja.Select(x => x.Zanimanje).ToList(),
            };

            ViewData["Id"] = id;

            return View(vm);
        }

        // GET: Osobas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var osoba = await _context.Osobe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (osoba == null) return NotFound();

            return View(osoba);
        }

        // GET: Osobas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Osobas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,Prezime,DatumRodjenja,MjesecniTrosak")]
            Osoba osoba)
        {
            if (ModelState.IsValid)
            {
                _context.Add(osoba);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(osoba);
        }

        // GET: Osobas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var osoba = await _context.Osobe.FindAsync(id);
            if (osoba == null) return NotFound();
            return View(osoba);
        }

        // POST: Osobas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Prezime,DatumRodjenja,MjesecniTrosak")]
            Osoba osoba)
        {
            if (id != osoba.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(osoba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OsobaExists(osoba.Id))
                        return NotFound();
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(osoba);
        }

        // GET: Osobas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var osoba = await _context.Osobe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (osoba == null) return NotFound();

            return View(osoba);
        }

        // POST: Osobas/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var osoba = await _context.Osobe.FindAsync(id);
            _context.Osobe.Remove(osoba);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OsobaExists(int id)
        {
            return _context.Osobe.Any(e => e.Id == id);
        }
    }
}
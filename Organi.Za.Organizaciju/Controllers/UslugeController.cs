using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Organi.Za.Organizaciju.Data;
using Organi.Za.Organizaciju.ViewModels;

namespace Organi.Za.Organizaciju.Controllers
{
    public class UslugeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UslugeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Usluge
        public async Task<IActionResult> Index(int? id)
        {
            var usluge = await _context.Usluge.Include(u => u.Kategorija).ToListAsync();

            Usluga selektiranaUsluga = null;

            if (id != null)
            {
                selektiranaUsluga = await _context.Usluge
                    .Include(x => x.PotrebnaOprema).ThenInclude(x => x.Oprema)
                    .Include(x => x.PotrebnoZanimanje).ThenInclude(x => x.Zanimanje)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }

            ViewData["Id"] = id;

            var vm = new UslugeViewModel
            {
                Usluge = usluge,
                PotrebnaOprema = selektiranaUsluga?.PotrebnaOprema.Select(x => x.Oprema).ToList(),
                PotrebnaZanimanja = selektiranaUsluga?.PotrebnoZanimanje.Select(x => x.Zanimanje).ToList(),
            };

            return View(vm);
        }

        // GET: Usluge/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var usluga = await _context.Usluge
                .Include(u => u.Kategorija)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usluga == null) return NotFound();

            return View(usluga);
        }

        // GET: Usluge/Create
        public IActionResult Create()
        {
            ViewData["KategorijaId"] = new SelectList(_context.KategorijeEvenata, "Id", "Naziv");
            return View();
        }

        // POST: Usluge/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,Cijena,Opis,KategorijaId")]
            Usluga usluga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usluga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["KategorijaId"] = new SelectList(_context.KategorijeEvenata, "Id", "Naziv", usluga.KategorijaId);
            return View(usluga);
        }

        // GET: Usluge/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var usluga = await _context.Usluge.FindAsync(id);
            if (usluga == null) return NotFound();
            ViewData["KategorijaId"] = new SelectList(_context.KategorijeEvenata, "Id", "Id", usluga.KategorijaId);
            return View(usluga);
        }

        // POST: Usluge/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,Cijena,Opis,KategorijaId")]
            Usluga usluga)
        {
            if (id != usluga.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usluga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UslugaExists(usluga.Id))
                        return NotFound();
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["KategorijaId"] = new SelectList(_context.KategorijeEvenata, "Id", "Naziv", usluga.KategorijaId);
            return View(usluga);
        }

        // GET: Usluge/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var usluga = await _context.Usluge
                .Include(u => u.Kategorija)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usluga == null) return NotFound();

            return View(usluga);
        }

        // POST: Usluge/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usluga = await _context.Usluge.FindAsync(id);
            _context.Usluge.Remove(usluga);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UslugaExists(int id)
        {
            return _context.Usluge.Any(e => e.Id == id);
        }
    }
}
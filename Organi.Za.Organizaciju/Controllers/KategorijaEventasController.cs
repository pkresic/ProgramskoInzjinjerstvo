using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Organi.Za.Organizaciju.Data;
using ReflectionIT.Mvc.Paging;
using Rotativa.AspNetCore;

namespace Organi.Za.Organizaciju.Controllers
{
    public class KategorijaEventasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KategorijaEventasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Print()
        {
            var item = _context.KategorijeEvenata.ToList();

            return new ViewAsPdf("~/Views/KategorijaEventas/KategorijeReport.cshtml", item);
        }

        public async Task<List<string>> Search(string search)
        {
            var query = await _context.KategorijeEvenata.Where(x => x.Naziv.StartsWith(search)).ToListAsync();

            return query.Select(x => x.Naziv).ToList();
        }

        // GET: KategorijaEventas
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "Naziv")
        {
            var qry = _context.KategorijeEvenata.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter)) qry = qry.Where(p => p.Naziv.Contains(filter));

            var model = await PagingList.CreateAsync(qry, 3, page, sortExpression, "Naziv");

            model.RouteValue = new RouteValueDictionary
            {
                {"filter", filter}
            };

            return View(model);
        }

        // GET: KategorijaEventas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var kategorijaEventa = await _context.KategorijeEvenata
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kategorijaEventa == null) return NotFound();

            return View(kategorijaEventa);
        }

        // GET: KategorijaEventas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KategorijaEventas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,Opis")] KategorijaEventa kategorijaEventa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kategorijaEventa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(kategorijaEventa);
        }

        // GET: KategorijaEventas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var kategorijaEventa = await _context.KategorijeEvenata.FindAsync(id);
            if (kategorijaEventa == null) return NotFound();
            return View(kategorijaEventa);
        }

        // POST: KategorijaEventas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,Opis")] KategorijaEventa kategorijaEventa)
        {
            if (id != kategorijaEventa.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kategorijaEventa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KategorijaEventaExists(kategorijaEventa.Id))
                        return NotFound();
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(kategorijaEventa);
        }

        // GET: KategorijaEventas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var kategorijaEventa = await _context.KategorijeEvenata
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kategorijaEventa == null) return NotFound();

            return View(kategorijaEventa);
        }

        // POST: KategorijaEventas/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kategorijaEventa = await _context.KategorijeEvenata.FindAsync(id);
            _context.KategorijeEvenata.Remove(kategorijaEventa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KategorijaEventaExists(int id)
        {
            return _context.KategorijeEvenata.Any(e => e.Id == id);
        }
    }
}
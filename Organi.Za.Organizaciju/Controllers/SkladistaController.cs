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
    public class SkladistaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SkladistaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Print()
        {
            var item = _context.Skladista.ToList();

            return new ViewAsPdf("~/Views/Skladista/SkladistaReport.cshtml", item);
        }

        public async Task<List<string>> Search(string search)
        {
            var query = await _context.Skladista.Where(x => x.Naziv.StartsWith(search)).ToListAsync();

            return query.Select(x => x.Naziv).ToList();
        }

        // GET: Skladista
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "Naziv")
        {
            var qry = _context.Skladista.AsNoTracking().AsQueryable();
            if (!string.IsNullOrWhiteSpace(filter))
            {
                qry = qry.Where(p => p.Naziv.Contains(filter));
            }
            var model = await PagingList.CreateAsync(qry, 3, page, sortExpression, "Naziv");
            model.RouteValue = new RouteValueDictionary
            {
                {"filter", filter}
            };

            return View(model);
        }

        // GET: Skladista/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var skladiste = await _context.Skladista
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skladiste == null) return NotFound();

            return View(skladiste);
        }

        // GET: Skladista/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Skladista/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,LokalniNaziv,Mjesto,Grad")]
            Skladiste skladiste)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skladiste);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(skladiste);
        }

        // GET: Skladista/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var skladiste = await _context.Skladista.FindAsync(id);
            if (skladiste == null) return NotFound();
            return View(skladiste);
        }

        // POST: Skladista/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,LokalniNaziv,Mjesto,Grad")]
            Skladiste skladiste)
        {
            if (id != skladiste.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skladiste);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkladisteExists(skladiste.Id))
                        return NotFound();
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(skladiste);
        }

        // GET: Skladista/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var skladiste = await _context.Skladista
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skladiste == null) return NotFound();

            return View(skladiste);
        }

        // POST: Skladista/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var skladiste = await _context.Skladista.FindAsync(id);
            _context.Skladista.Remove(skladiste);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkladisteExists(int id)
        {
            return _context.Skladista.Any(e => e.Id == id);
        }
    }
}
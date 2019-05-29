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
    public class CertifikatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CertifikatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult PrintCertificates()
        {
           var certificates =  _context.Certifikati.ToList();

            return new ViewAsPdf("~/Views/Certifikats/CertifikatiReport.cshtml", certificates);
        }

        public async Task<List<string>> Search(string search)
        {
            var query = await _context.Certifikati.Where(x => x.Naziv.StartsWith(search)).ToListAsync();

            return query.Select(x => x.Naziv).ToList();
        }

        // GET: Certifikats
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "Naziv")
        {
            var qry = _context.Certifikati.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                qry = qry.Where(p => p.Naziv.Contains(filter));
            }

            var model = await PagingList.CreateAsync(qry, 3, page, sortExpression, "Naziv");

            model.RouteValue = new RouteValueDictionary {
                { "filter", filter}
            };
            return View(model);
        }

        // GET: Certifikats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var certifikat = await _context.Certifikati
                .FirstOrDefaultAsync(m => m.Id == id);
            if (certifikat == null) return NotFound();

            return View(certifikat);
        }

        // GET: Certifikats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Certifikats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,Opis")] Certifikat certifikat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(certifikat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(certifikat);
        }

        // GET: Certifikats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var certifikat = await _context.Certifikati.FindAsync(id);
            if (certifikat == null) return NotFound();
            return View(certifikat);
        }

        // POST: Certifikats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,Opis")] Certifikat certifikat)
        {
            if (id != certifikat.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(certifikat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CertifikatExists(certifikat.Id))
                        return NotFound();
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(certifikat);
        }

        // GET: Certifikats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var certifikat = await _context.Certifikati
                .FirstOrDefaultAsync(m => m.Id == id);
            if (certifikat == null) return NotFound();

            return View(certifikat);
        }

        // POST: Certifikats/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var certifikat = await _context.Certifikati.FindAsync(id);
            _context.Certifikati.Remove(certifikat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CertifikatExists(int id)
        {
            return _context.Certifikati.Any(e => e.Id == id);
        }
    }
}
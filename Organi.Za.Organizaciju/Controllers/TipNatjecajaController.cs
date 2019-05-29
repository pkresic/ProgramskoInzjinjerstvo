using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Organi.Za.Organizaciju.Data;
using ReflectionIT.Mvc.Paging;
using Rotativa.AspNetCore;

namespace Organi.Za.Organizaciju.Controllers
{
    public class TipNatjecajaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipNatjecajaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Print()
        {
            var item = _context.TipoviNatjecaja.ToList();

            return new ViewAsPdf("~/Views/TipNatjecaja/TipoviNatjecajaReport.cshtml", item);
        }


        public async Task<List<string>> Search(string search)
        {
            var query = await _context.TipoviNatjecaja.Where(x => x.Naziv.StartsWith(search)).ToListAsync();

            return query.Select(x => x.Naziv).ToList();
        }

        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "Naziv")
        {
            var qry = _context.TipoviNatjecaja.AsNoTracking().AsQueryable();
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

        // GET: TipNatjecaja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipNatjecaja = await _context.TipoviNatjecaja
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipNatjecaja == null)
            {
                return NotFound();
            }

            return View(tipNatjecaja);
        }

        // GET: TipNatjecaja/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipNatjecaja/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,Opis")] TipNatjecaja tipNatjecaja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipNatjecaja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipNatjecaja);
        }

        // GET: TipNatjecaja/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipNatjecaja = await _context.TipoviNatjecaja.FindAsync(id);
            if (tipNatjecaja == null)
            {
                return NotFound();
            }
            return View(tipNatjecaja);
        }

        // POST: TipNatjecaja/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,Opis")] TipNatjecaja tipNatjecaja)
        {
            if (id != tipNatjecaja.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipNatjecaja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipNatjecajaExists(tipNatjecaja.Id))
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
            return View(tipNatjecaja);
        }

        // GET: TipNatjecaja/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipNatjecaja = await _context.TipoviNatjecaja
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipNatjecaja == null)
            {
                return NotFound();
            }

            return View(tipNatjecaja);
        }

        // POST: TipNatjecaja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipNatjecaja = await _context.TipoviNatjecaja.FindAsync(id);
            _context.TipoviNatjecaja.Remove(tipNatjecaja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipNatjecajaExists(int id)
        {
            return _context.TipoviNatjecaja.Any(e => e.Id == id);
        }
    }
}

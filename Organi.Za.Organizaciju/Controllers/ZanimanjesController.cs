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
    public class ZanimanjesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZanimanjesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Print()
        {
            var items = _context.Zanimanja.ToList();

            return new ViewAsPdf("~/Views/Zanimanjes/ZanimanjaReport.cshtml", items);
        }

        public async Task<List<string>> Search(string search)
        {
            var query = await _context.Zanimanja.Where(x => x.Naziv.StartsWith(search)).ToListAsync();

            return query.Select(x => x.Naziv).ToList();
        }

        // GET: Zanimanjes
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "Naziv")
        {
            var qry = _context.Zanimanja.AsNoTracking().AsQueryable();
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

        // GET: Zanimanjes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zanimanje = await _context.Zanimanja
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zanimanje == null)
            {
                return NotFound();
            }

            return View(zanimanje);
        }

        // GET: Zanimanjes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zanimanjes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,Opis")] Zanimanje zanimanje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zanimanje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zanimanje);
        }

        // GET: Zanimanjes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zanimanje = await _context.Zanimanja.FindAsync(id);
            if (zanimanje == null)
            {
                return NotFound();
            }
            return View(zanimanje);
        }

        // POST: Zanimanjes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,Opis")] Zanimanje zanimanje)
        {
            if (id != zanimanje.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zanimanje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZanimanjeExists(zanimanje.Id))
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
            return View(zanimanje);
        }

        // GET: Zanimanjes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zanimanje = await _context.Zanimanja
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zanimanje == null)
            {
                return NotFound();
            }

            return View(zanimanje);
        }

        // POST: Zanimanjes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zanimanje = await _context.Zanimanja.FindAsync(id);
            _context.Zanimanja.Remove(zanimanje);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZanimanjeExists(int id)
        {
            return _context.Zanimanja.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Organi.Za.Organizaciju.Data;
using ReflectionIT.Mvc.Paging;

namespace Organi.Za.Organizaciju.Controllers
{
    public class ZanimanjaOsobaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZanimanjaOsobaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ZanimanjaOsoba
        public async Task<IActionResult> Index(int page = 1)
        {
            var qry = _context.ZanimanjaOsoba.Include(z => z.Osoba).Include(z => z.Zanimanje).AsNoTracking().OrderBy(p => p.ZanimanjeId);
            var model = await PagingList.CreateAsync(qry, 3, page);
            return View(model);
        }

        // GET: ZanimanjaOsoba/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zanimanjaOsobe = await _context.ZanimanjaOsoba
                .Include(z => z.Osoba)
                .Include(z => z.Zanimanje)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zanimanjaOsobe == null)
            {
                return NotFound();
            }

            return View(zanimanjaOsobe);
        }

        // GET: ZanimanjaOsoba/Create
        public IActionResult Create()
        {
            ViewData["OsobaId"] = new SelectList(_context.Osobe, "Id", "Ime");
            ViewData["ZanimanjeId"] = new SelectList(_context.Zanimanja, "Id", "Naziv");
            return View();
        }

        // POST: ZanimanjaOsoba/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ZanimanjeId,OsobaId")] ZanimanjaOsobe zanimanjaOsobe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zanimanjaOsobe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OsobaId"] = new SelectList(_context.Osobe, "Id", "Ime", zanimanjaOsobe.OsobaId);
            ViewData["ZanimanjeId"] = new SelectList(_context.Zanimanja, "Id", "Naziv", zanimanjaOsobe.ZanimanjeId);
            return View(zanimanjaOsobe);
        }

        // GET: ZanimanjaOsoba/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zanimanjaOsobe = await _context.ZanimanjaOsoba.FindAsync(id);
            if (zanimanjaOsobe == null)
            {
                return NotFound();
            }
            ViewData["OsobaId"] = new SelectList(_context.Osobe, "Id", "Ime", zanimanjaOsobe.OsobaId);
            ViewData["ZanimanjeId"] = new SelectList(_context.Zanimanja, "Id", "Naziv", zanimanjaOsobe.ZanimanjeId);
            return View(zanimanjaOsobe);
        }

        // POST: ZanimanjaOsoba/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ZanimanjeId,OsobaId")] ZanimanjaOsobe zanimanjaOsobe)
        {
            if (id != zanimanjaOsobe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zanimanjaOsobe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZanimanjaOsobeExists(zanimanjaOsobe.Id))
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
            ViewData["OsobaId"] = new SelectList(_context.Osobe, "Id", "Ime", zanimanjaOsobe.OsobaId);
            ViewData["ZanimanjeId"] = new SelectList(_context.Zanimanja, "Id", "Naziv", zanimanjaOsobe.ZanimanjeId);
            return View(zanimanjaOsobe);
        }

        // GET: ZanimanjaOsoba/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zanimanjaOsobe = await _context.ZanimanjaOsoba
                .Include(z => z.Osoba)
                .Include(z => z.Zanimanje)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zanimanjaOsobe == null)
            {
                return NotFound();
            }

            return View(zanimanjaOsobe);
        }

        // POST: ZanimanjaOsoba/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zanimanjaOsobe = await _context.ZanimanjaOsoba.FindAsync(id);
            _context.ZanimanjaOsoba.Remove(zanimanjaOsobe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZanimanjaOsobeExists(int id)
        {
            return _context.ZanimanjaOsoba.Any(e => e.Id == id);
        }
    }
}

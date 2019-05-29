using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Organi.Za.Organizaciju.Data;

namespace Organi.Za.Organizaciju.Controllers
{
    public class PonudaZaNatjecajsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PonudaZaNatjecajsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PonudaZaNatjecajs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PonudaZaNatjecaj.Include(p => p.Natjecaj).Include(p => p.Usluga);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PonudaZaNatjecajs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ponudaZaNatjecaj = await _context.PonudaZaNatjecaj
                .Include(p => p.Natjecaj)
                .Include(p => p.Usluga)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ponudaZaNatjecaj == null)
            {
                return NotFound();
            }

            return View(ponudaZaNatjecaj);
        }

        // GET: PonudaZaNatjecajs/Create
        public IActionResult Create()
        {
            ViewData["NatjecajId"] = new SelectList(_context.Natjecaji, "Id", "Naziv");
            ViewData["UslugaId"] = new SelectList(_context.Usluge, "Id", "Naziv");
            return View();
        }

        // POST: PonudaZaNatjecajs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UslugaId,NatjecajId,Cijena,DodatnaPoruka,Naziv")] PonudaZaNatjecaj ponudaZaNatjecaj)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ponudaZaNatjecaj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NatjecajId"] = new SelectList(_context.Natjecaji, "Id", "Naziv", ponudaZaNatjecaj.NatjecajId);
            ViewData["UslugaId"] = new SelectList(_context.Usluge, "Id", "Naziv", ponudaZaNatjecaj.UslugaId);
            return View(ponudaZaNatjecaj);
        }

        // GET: PonudaZaNatjecajs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ponudaZaNatjecaj = await _context.PonudaZaNatjecaj.FindAsync(id);
            if (ponudaZaNatjecaj == null)
            {
                return NotFound();
            }
            ViewData["NatjecajId"] = new SelectList(_context.Natjecaji, "Id", "Naziv", ponudaZaNatjecaj.NatjecajId);
            ViewData["UslugaId"] = new SelectList(_context.Usluge, "Id", "Naziv", ponudaZaNatjecaj.UslugaId);
            return View(ponudaZaNatjecaj);
        }

        // POST: PonudaZaNatjecajs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UslugaId,NatjecajId,Cijena,DodatnaPoruka,Naziv")] PonudaZaNatjecaj ponudaZaNatjecaj)
        {
            if (id != ponudaZaNatjecaj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ponudaZaNatjecaj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PonudaZaNatjecajExists(ponudaZaNatjecaj.Id))
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
            ViewData["NatjecajId"] = new SelectList(_context.Natjecaji, "Id", "Naziv", ponudaZaNatjecaj.NatjecajId);
            ViewData["UslugaId"] = new SelectList(_context.Usluge, "Id", "Naziv", ponudaZaNatjecaj.UslugaId);
            return View(ponudaZaNatjecaj);
        }

        // GET: PonudaZaNatjecajs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ponudaZaNatjecaj = await _context.PonudaZaNatjecaj
                .Include(p => p.Natjecaj)
                .Include(p => p.Usluga)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ponudaZaNatjecaj == null)
            {
                return NotFound();
            }

            return View(ponudaZaNatjecaj);
        }

        // POST: PonudaZaNatjecajs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ponudaZaNatjecaj = await _context.PonudaZaNatjecaj.FindAsync(id);
            _context.PonudaZaNatjecaj.Remove(ponudaZaNatjecaj);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PonudaZaNatjecajExists(int id)
        {
            return _context.PonudaZaNatjecaj.Any(e => e.Id == id);
        }
    }
}

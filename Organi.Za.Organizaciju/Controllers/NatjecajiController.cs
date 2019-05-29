using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Organi.Za.Organizaciju.Data;
using Organi.Za.Organizaciju.ViewModels;

namespace Organi.Za.Organizaciju.Controllers
{
    public class NatjecajiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NatjecajiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Natjecaji
        public async Task<IActionResult> Index(int? id)
        {
            var natjecaji = await _context.Natjecaji.Include(n => n.Tip).ToListAsync();
            IEnumerable<PonudaZaNatjecaj> selektiraniNatjecaj = null;

            if (id != null)
            {
                selektiraniNatjecaj =
                    await _context.PonudaZaNatjecaj.Include(x => x.Usluga).Where(x => x.NatjecajId == id).ToListAsync();
            }

            var vm = new NatjecajiViewModel
            {
                Natjecaji = natjecaji,
                Ponude = selektiraniNatjecaj,
            };

            return View(vm);
        }

        // GET: Natjecaji/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var natjecaj = await _context.Natjecaji
                .Include(n => n.Tip)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (natjecaj == null)
            {
                return NotFound();
            }

            return View(natjecaj);
        }

        // GET: Natjecaji/Create
        public IActionResult Create()
        {
            ViewData["TipId"] = new SelectList(_context.TipoviNatjecaja, "Id", "Naziv");
            return View();
        }

        // POST: Natjecaji/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,TipId,VrijediDo,Opis,VrijednostNatjecaja")] Natjecaj natjecaj)
        {
            if (ModelState.IsValid)
            {
                _context.Add(natjecaj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipId"] = new SelectList(_context.TipoviNatjecaja, "Id", "Naziv", natjecaj.TipId);
            return View(natjecaj);
        }

        // GET: Natjecaji/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var natjecaj = await _context.Natjecaji.FindAsync(id);
            if (natjecaj == null)
            {
                return NotFound();
            }
            ViewData["TipId"] = new SelectList(_context.TipoviNatjecaja, "Id", "Naziv", natjecaj.TipId);
            return View(natjecaj);
        }

        // POST: Natjecaji/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,TipId,VrijediDo,Opis,VrijednostNatjecaja")] Natjecaj natjecaj)
        {
            if (id != natjecaj.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(natjecaj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NatjecajExists(natjecaj.Id))
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
            ViewData["TipId"] = new SelectList(_context.TipoviNatjecaja, "Id", "Naziv", natjecaj.TipId);
            return View(natjecaj);
        }

        // GET: Natjecaji/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var natjecaj = await _context.Natjecaji
                .Include(n => n.Tip)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (natjecaj == null)
            {
                return NotFound();
            }

            return View(natjecaj);
        }

        // POST: Natjecaji/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var natjecaj = await _context.Natjecaji.FindAsync(id);
            _context.Natjecaji.Remove(natjecaj);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NatjecajExists(int id)
        {
            return _context.Natjecaji.Any(e => e.Id == id);
        }
    }
}

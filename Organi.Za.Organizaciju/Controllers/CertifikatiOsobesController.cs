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
    public class CertifikatiOsobesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CertifikatiOsobesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CertifikatiOsobes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CertifikatiOsoba.Include(c => c.Certifikat).Include(c => c.Osoba);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CertifikatiOsobes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certifikatiOsobe = await _context.CertifikatiOsoba
                .Include(c => c.Certifikat)
                .Include(c => c.Osoba)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (certifikatiOsobe == null)
            {
                return NotFound();
            }

            return View(certifikatiOsobe);
        }

        // GET: CertifikatiOsobes/Create
        public IActionResult Create()
        {
            ViewData["CertifikatId"] = new SelectList(_context.Certifikati, "Id", "Naziv");
            ViewData["OsobaId"] = new SelectList(_context.Osobe, "Id", "Ime");
            return View();
        }

        // POST: CertifikatiOsobes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CertifikatId,OsobaId,DatumPolaganja")] CertifikatiOsobe certifikatiOsobe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(certifikatiOsobe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CertifikatId"] = new SelectList(_context.Certifikati, "Id", "Naziv", certifikatiOsobe.CertifikatId);
            ViewData["OsobaId"] = new SelectList(_context.Osobe, "Id", "Ime", certifikatiOsobe.OsobaId);
            return View(certifikatiOsobe);
        }

        // GET: CertifikatiOsobes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certifikatiOsobe = await _context.CertifikatiOsoba.FindAsync(id);
            if (certifikatiOsobe == null)
            {
                return NotFound();
            }
            ViewData["CertifikatId"] = new SelectList(_context.Certifikati, "Id", "Naziv", certifikatiOsobe.CertifikatId);
            ViewData["OsobaId"] = new SelectList(_context.Osobe, "Id", "Ime", certifikatiOsobe.OsobaId);
            return View(certifikatiOsobe);
        }

        // POST: CertifikatiOsobes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CertifikatId,OsobaId,DatumPolaganja")] CertifikatiOsobe certifikatiOsobe)
        {
            if (id != certifikatiOsobe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(certifikatiOsobe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CertifikatiOsobeExists(certifikatiOsobe.Id))
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
            ViewData["CertifikatId"] = new SelectList(_context.Certifikati, "Id", "Naziv", certifikatiOsobe.CertifikatId);
            ViewData["OsobaId"] = new SelectList(_context.Osobe, "Id", "Ime", certifikatiOsobe.OsobaId);
            return View(certifikatiOsobe);
        }

        // GET: CertifikatiOsobes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certifikatiOsobe = await _context.CertifikatiOsoba
                .Include(c => c.Certifikat)
                .Include(c => c.Osoba)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (certifikatiOsobe == null)
            {
                return NotFound();
            }

            return View(certifikatiOsobe);
        }

        // POST: CertifikatiOsobes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var certifikatiOsobe = await _context.CertifikatiOsoba.FindAsync(id);
            _context.CertifikatiOsoba.Remove(certifikatiOsobe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CertifikatiOsobeExists(int id)
        {
            return _context.CertifikatiOsoba.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Groupe3GestionEnseignant.Models;
using Groupe3GestionEnseignant.Models.ENTITE;

namespace Groupe3GestionEnseignant.Controllers
{
    public class SaisirsController : Controller
    {
        private readonly Groupe3GestionEnseingnantDbContext _context;

        public SaisirsController(Groupe3GestionEnseingnantDbContext context)
        {
            _context = context;
        }

        // GET: Saisirs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Saisir.ToListAsync());
        }

        // GET: Saisirs/Details/5
        public async Task<IActionResult> Details(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saisir = await _context.Saisir
                .FirstOrDefaultAsync(m => m.Jour == id);
            if (saisir == null)
            {
                return NotFound();
            }

            return View(saisir);
        }

        // GET: Saisirs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Saisirs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Jour,IdCahierTexte,IdEnseignant")] Saisir saisir)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saisir);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(saisir);
        }

        // GET: Saisirs/Edit/5
        public async Task<IActionResult> Edit(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saisir = await _context.Saisir.FindAsync(id);
            if (saisir == null)
            {
                return NotFound();
            }
            return View(saisir);
        }

        // POST: Saisirs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DateTime id, [Bind("Jour,IdCahierTexte,IdEnseignant")] Saisir saisir)
        {
            if (id != saisir.Jour)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saisir);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaisirExists(saisir.Jour))
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
            return View(saisir);
        }

        // GET: Saisirs/Delete/5
        public async Task<IActionResult> Delete(DateTime? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saisir = await _context.Saisir
                .FirstOrDefaultAsync(m => m.Jour == id);
            if (saisir == null)
            {
                return NotFound();
            }

            return View(saisir);
        }

        // POST: Saisirs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(DateTime id)
        {
            var saisir = await _context.Saisir.FindAsync(id);
            if (saisir != null)
            {
                _context.Saisir.Remove(saisir);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaisirExists(DateTime id)
        {
            return _context.Saisir.Any(e => e.Jour == id);
        }
    }
}

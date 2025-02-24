﻿using System;
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
    public class CahierDeTextesController : Controller
    {
        private readonly Groupe3GestionEnseingnantDbContext _context;

        public CahierDeTextesController(Groupe3GestionEnseingnantDbContext context)
        {
            _context = context;
        }

        // GET: CahierDeTextes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CahierDeTexte.ToListAsync());
        }

        // GET: CahierDeTextes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cahierDeTexte = await _context.CahierDeTexte
                .FirstOrDefaultAsync(m => m.IdCahierTexte == id);
            if (cahierDeTexte == null)
            {
                return NotFound();
            }

            return View(cahierDeTexte);
        }

        // GET: CahierDeTextes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CahierDeTextes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCahierTexte,Contenu,Date")] CahierDeTexte cahierDeTexte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cahierDeTexte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cahierDeTexte);
        }

        // GET: CahierDeTextes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cahierDeTexte = await _context.CahierDeTexte.FindAsync(id);
            if (cahierDeTexte == null)
            {
                return NotFound();
            }
            return View(cahierDeTexte);
        }

        // POST: CahierDeTextes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCahierTexte,Contenu,Date")] CahierDeTexte cahierDeTexte)
        {
            if (id != cahierDeTexte.IdCahierTexte)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cahierDeTexte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CahierDeTexteExists(cahierDeTexte.IdCahierTexte))
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
            return View(cahierDeTexte);
        }

        // GET: CahierDeTextes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cahierDeTexte = await _context.CahierDeTexte
                .FirstOrDefaultAsync(m => m.IdCahierTexte == id);
            if (cahierDeTexte == null)
            {
                return NotFound();
            }

            return View(cahierDeTexte);
        }

        // POST: CahierDeTextes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cahierDeTexte = await _context.CahierDeTexte.FindAsync(id);
            if (cahierDeTexte != null)
            {
                _context.CahierDeTexte.Remove(cahierDeTexte);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CahierDeTexteExists(int id)
        {
            return _context.CahierDeTexte.Any(e => e.IdCahierTexte == id);
        }
    }
}

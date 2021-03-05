using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DefautAfpaBriveContext;
using ModelAfpa;

namespace WebApplication1.Controllers
{
    public class StagiairesController : Controller
    {
        private readonly DefaultContext _context;

        public StagiairesController(DefaultContext context)
        {
            _context = context;
        }

        // GET: Stagiaires
        public async Task<IActionResult> Index()
        {
            return View(await _context.Stagiaires.ToListAsync());
        }

        // GET: Stagiaires/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stagiaire = await _context.Stagiaires
                .FirstOrDefaultAsync(m => m.IdPersonne == id);
            if (stagiaire == null)
            {
                return NotFound();
            }

            return View(stagiaire);
        }

        // GET: Stagiaires/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stagiaires/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost,ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStagiaire([Bind("MatriculeStagiaire,DateNaissanceStagiaire,IdPersonne,NomPersonne,PrenomPersonne,CivilitePersonne,SexePersonne,AdresseMail,CatPersonne")] Stagiaire stagiaire)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stagiaire);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stagiaire);
        }

        // GET: Stagiaires/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stagiaire = await _context.Stagiaires.FindAsync(id);
            if (stagiaire == null)
            {
                return NotFound();
            }
            return View(stagiaire);
        }

        // POST: Stagiaires/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MatriculeStagiaire,DateNaissanceStagiaire,IdPersonne,NomPersonne,PrenomPersonne,CivilitePersonne,SexePersonne,AdresseMail,CatPersonne")] Stagiaire stagiaire)
        {
            if (id != stagiaire.IdPersonne)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stagiaire);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StagiaireExists(stagiaire.IdPersonne))
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
            return View(stagiaire);
        }

        // GET: Stagiaires/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stagiaire = await _context.Stagiaires
                .FirstOrDefaultAsync(m => m.IdPersonne == id);
            if (stagiaire == null)
            {
                return NotFound();
            }

            return View(stagiaire);
        }

        // POST: Stagiaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stagiaire = await _context.Stagiaires.FindAsync(id);
            _context.Stagiaires.Remove(stagiaire);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StagiaireExists(int id)
        {
            return _context.Stagiaires.Any(e => e.IdPersonne == id);
        }
    }
}

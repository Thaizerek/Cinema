using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cinema.Data;
using Cinema.Models;

namespace Cinema.Controllers
{
    public class AktorzyController : Controller
    {
        private readonly CinemaContext _context;

        public AktorzyController(CinemaContext context)
        {
            _context = context;
        }

        // GET: Aktorzy
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aktorzy.ToListAsync());
        }

        // GET: Aktorzy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aktorzy = await _context.Aktorzy
                .FirstOrDefaultAsync(m => m.AktorId == id);
            if (aktorzy == null)
            {
                return NotFound();
            }

            return View(aktorzy);
        }

        // GET: Aktorzy/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aktorzy/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AktorId,AktorZdjecieURL,AktorImieNazwisko,AktorBiografia")] Aktorzy aktorzy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aktorzy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aktorzy);
        }

        // GET: Aktorzy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aktorzy = await _context.Aktorzy.FindAsync(id);
            if (aktorzy == null)
            {
                return NotFound();
            }
            return View(aktorzy);
        }

        // POST: Aktorzy/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AktorId,AktorZdjecieURL,AktorImieNazwisko,AktorBiografia")] Aktorzy aktorzy)
        {
            if (id != aktorzy.AktorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aktorzy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AktorzyExists(aktorzy.AktorId))
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
            return View(aktorzy);
        }

        // GET: Aktorzy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aktorzy = await _context.Aktorzy
                .FirstOrDefaultAsync(m => m.AktorId == id);
            if (aktorzy == null)
            {
                return NotFound();
            }

            return View(aktorzy);
        }

        // POST: Aktorzy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aktorzy = await _context.Aktorzy.FindAsync(id);
            _context.Aktorzy.Remove(aktorzy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AktorzyExists(int id)
        {
            return _context.Aktorzy.Any(e => e.AktorId == id);
        }
    }
}

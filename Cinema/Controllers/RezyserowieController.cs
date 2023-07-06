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
    public class RezyserowieController : Controller
    {
        private readonly CinemaContext _context;

        public RezyserowieController(CinemaContext context)
        {
            _context = context;
        }

        // GET: Rezyserowie
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rezyserowie.ToListAsync());
        }

        // GET: Rezyserowie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezyserowie = await _context.Rezyserowie
                .FirstOrDefaultAsync(m => m.RezyserId == id);
            if (rezyserowie == null)
            {
                return NotFound();
            }

            return View(rezyserowie);
        }

        // GET: Rezyserowie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rezyserowie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RezyserId,RezyserZdjecieURL,RezyserImieNazwisko,RezyserBiografia")] Rezyserowie rezyserowie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rezyserowie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rezyserowie);
        }

        // GET: Rezyserowie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezyserowie = await _context.Rezyserowie.FindAsync(id);
            if (rezyserowie == null)
            {
                return NotFound();
            }
            return View(rezyserowie);
        }

        // POST: Rezyserowie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RezyserId,RezyserZdjecieURL,RezyserImieNazwisko,RezyserBiografia")] Rezyserowie rezyserowie)
        {
            if (id != rezyserowie.RezyserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezyserowie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezyserowieExists(rezyserowie.RezyserId))
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
            return View(rezyserowie);
        }

        // GET: Rezyserowie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezyserowie = await _context.Rezyserowie
                .FirstOrDefaultAsync(m => m.RezyserId == id);
            if (rezyserowie == null)
            {
                return NotFound();
            }

            return View(rezyserowie);
        }

        // POST: Rezyserowie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezyserowie = await _context.Rezyserowie.FindAsync(id);
            _context.Rezyserowie.Remove(rezyserowie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RezyserowieExists(int id)
        {
            return _context.Rezyserowie.Any(e => e.RezyserId == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VacationManager.Models;
using VacationManager.Repositories;

namespace VacationManager.Controllers
{
    public class TimeOffsController : Controller
    {
        private readonly VacationManagerDbContext _context;

        public TimeOffsController(VacationManagerDbContext context)
        {
            _context = context;
        }

        // GET: TimeOffs
        public async Task<IActionResult> Index()
        {
            return View(await _context.TimeOffs.ToListAsync());
        }

        // GET: TimeOffs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeOff = await _context.TimeOffs
                .FirstOrDefaultAsync(m => m.TimeOffId == id);
            if (timeOff == null)
            {
                return NotFound();
            }

            return View(timeOff);
        }

        // GET: TimeOffs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TimeOffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TimeOffId,From,To,CreatedOn,HalfDay,Type,Approved")] TimeOff timeOff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeOff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(timeOff);
        }

        // GET: TimeOffs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeOff = await _context.TimeOffs.FindAsync(id);
            if (timeOff == null)
            {
                return NotFound();
            }
            return View(timeOff);
        }

        // POST: TimeOffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TimeOffId,From,To,CreatedOn,HalfDay,Type,Approved")] TimeOff timeOff)
        {
            if (id != timeOff.TimeOffId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeOff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeOffExists(timeOff.TimeOffId))
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
            return View(timeOff);
        }

        // GET: TimeOffs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeOff = await _context.TimeOffs
                .FirstOrDefaultAsync(m => m.TimeOffId == id);
            if (timeOff == null)
            {
                return NotFound();
            }

            return View(timeOff);
        }

        // POST: TimeOffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timeOff = await _context.TimeOffs.FindAsync(id);
            _context.TimeOffs.Remove(timeOff);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeOffExists(int id)
        {
            return _context.TimeOffs.Any(e => e.TimeOffId == id);
        }
    }
}

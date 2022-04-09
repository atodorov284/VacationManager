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
    /// <summary>
    /// Controls the Team logic.
    /// </summary>
    public class TeamsController : Controller
    {
        private readonly VacationManagerDbContext _context;

        public TeamsController(VacationManagerDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: Teams
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.Teams.ToListAsync());
        }

        /// <summary>
        /// GET: Teams/Details/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .FirstOrDefaultAsync(m => m.TeamId == id);
            if (team == null)
            {
                return NotFound();
            }
            await UpdateDevelopers(team);
            ViewData["Developers"] = _context.Users.Where(u => u.Team == team.Name && u.Role == 1).Select(u => u.Username).ToList();
            ViewData["Projects"] = _context.Projects.Where(project => project.TeamNames.Contains(team.Name)).Select(project => project.Name).ToList();
            return View(team);
        }

        /// <summary>
        /// GET: Teams/Create
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            ViewData["Managers"] = _context.Users.Where(u => u.Role == 2).Select(u => u.Username).ToList();
            return View();
        }

        /// <summary>
        /// POST: Teams/Create
        /// To protect from overposting attacks, enable the specific properties you want to bind to.
        /// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        /// <param name="team"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeamId,Name,Leader")] Team team)
        {
            if (ModelState.IsValid)
            {
                _context.Add(team);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        /// <summary>
        /// GET: Teams/Edit/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams.FindAsync(id);
            ViewData["Managers"] = _context.Users.Where(u => u.Role == 2).Select(u => u.Username).ToList();
            if (team == null)
            {
                return NotFound();
            }
            return View(team);
        }

        /// <summary>
        /// POST: Teams/Edit/5
        /// To protect from overposting attacks, enable the specific properties you want to bind to.
        /// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="team"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeamId,Name,Leader")] Team team)
        {
            if (id != team.TeamId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.TeamId))
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
            return View(team);
        }

        /// <summary>
        /// GET: Teams/Delete/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .FirstOrDefaultAsync(m => m.TeamId == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        /// <summary>
        /// POST: Teams/Delete/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.TeamId == id);
        }

        private async Task<IActionResult> UpdateDevelopers(Team team)
        {
            List<User> developers = _context.Users.Where(user => user.Team == team.Name && user.Role == 1).ToList();
            team.Developers = developers;
            _context.Update(team);
            await _context.SaveChangesAsync();
            return View();
        }
    }
}

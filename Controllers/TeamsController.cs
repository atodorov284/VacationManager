using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacationManager.Models;
using VacationManager.Repositories;

namespace VacationManager.Controllers
{
    /// <summary>
    /// Class TeamsController.
    /// Implements the <see cref="Controller" />
    /// </summary>
    /// <seealso cref="Controller" />
    public class TeamsController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly VacationManagerDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamsController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public TeamsController(VacationManagerDbContext context)
        {
            _context = context;
        }

        // GET: Teams
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.Teams.ToListAsync());
        }

        // GET: Teams/Details/5
        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
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

        // GET: Teams/Create
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult Create()
        {
            ViewData["Managers"] = _context.Users.Where(u => u.Role == 2).Select(u => u.Username).ToList();
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Creates the specified team.
        /// </summary>
        /// <param name="team">The team.</param>
        /// <returns>IActionResult.</returns>
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

        // GET: Teams/Edit/5
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
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

        // POST: Teams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="team">The team.</param>
        /// <returns>IActionResult.</returns>
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

        // GET: Teams/Delete/5
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
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

        // POST: Teams/Delete/5
        /// <summary>
        /// Deletes the confirmed.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Teams the exists.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.TeamId == id);
        }

        /// <summary>
        /// Updates the developers.
        /// </summary>
        /// <param name="team">The team.</param>
        /// <returns>IActionResult.</returns>
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

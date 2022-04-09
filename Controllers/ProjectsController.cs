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
    /// Controlls the Project logic.
    /// </summary>
    public class ProjectsController : Controller
    {
        private readonly VacationManagerDbContext _context;

        public ProjectsController(VacationManagerDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: Projects
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.Projects.ToListAsync());
        }

        /// <summary>
        /// GET: Projects/Details/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var project = await _context.Projects
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        /// <summary>
        /// GET: Projects/Create
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// POST: Projects/Create
        /// To protect from overposting attacks, enable the specific properties you want to bind to.
        /// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectId,Name,Description")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        /// <summary>
        /// GET: Projects/Edit/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FindAsync(id);
            ViewData["Teams"] = _context.Teams.Select(t => t.Name).ToList();
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        /// <summary>
        /// POST: Projects/Edit/5
        /// To protect from overposting attacks, enable the specific properties you want to bind to.
        /// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectId,Name,Description,TeamToAdd,TeamToRemove,Teams")] Project project)
        {
            if (id != project.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Project oldProject = _context.Projects.Where(p => p.ProjectId == id).FirstOrDefault();
                    if(oldProject.TeamNames == null)
                    {
                        oldProject.TeamNames = "";
                    }
                    if(project.TeamToRemove != project.TeamToAdd)
                    {
                        if (!oldProject.TeamNames.Contains(project.TeamToAdd) && project.TeamToAdd != "None")
                        {
                            oldProject.TeamNames += project.TeamToAdd + " ";
                        }
                        if (oldProject.TeamNames.Contains(project.TeamToRemove) && project.TeamToRemove != "None")
                        {
                            List<string> names = oldProject.TeamNames.Split().ToList();
                            names.Remove(project.TeamToRemove);
                            oldProject.TeamNames = String.Join(" ", names);
                        }
                    }
                    
                    _context.Update(oldProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.ProjectId))
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
            return View(project);
        }

        /// <summary>
        /// GET: Projects/Delete/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        /// <summary>
        /// POST: Projects/Delete/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Exits from the current project.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.ProjectId == id);
        }
    }
}

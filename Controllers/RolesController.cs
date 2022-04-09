using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VacationManager.Repositories;

namespace VacationManager.Controllers
{
    /// <summary>
    /// Class RolesController.
    /// Implements the <see cref="Controller" />
    /// </summary>
    /// <seealso cref="Controller" />
    public class RolesController : Controller
    {

        /// <summary>
        /// The context
        /// </summary>
        private readonly VacationManagerDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="RolesController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public RolesController(VacationManagerDbContext context)
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
            return View(await _context.Users.ToListAsync());
        }
    }
}
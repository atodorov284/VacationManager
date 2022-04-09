using Microsoft.AspNetCore.Mvc;
using VacationManager.Repositories;
using VacationManager.ViewModels.Home;
using Microsoft.AspNetCore.Http;
using System.Linq;
using VacationManager.Models;
using VacationManager.ExtentionMethods;

namespace VacationManager.Controllers
{
    /// <summary>
    /// Class HomeController.
    /// Implements the <see cref="Controller" />
    /// </summary>
    /// <seealso cref="Controller" />
    public class HomeController : Controller
    {

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Logins this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Logins the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult Login(UserCreateVM model)
        {
            if (!this.ModelState.IsValid)
                return View(model);

            VacationManagerDbContext context = new VacationManagerDbContext();
            User loggedUser = context.Users.Where(u => u.Username == model.Username &&
                                                       u.Password == model.Password)
                                           .FirstOrDefault();
            if (loggedUser == null)
            {
                this.ModelState.AddModelError("authError", "Invalid username or password!");
                return View(model);
            }

            HttpContext.Session.SetObject("loggedUser", loggedUser);

            return RedirectToAction("Index", "Home");
        }
        /// <summary>
        /// Logouts this instance.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("loggedUser");

            return RedirectToAction("Login", "Home");
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VacationManager.Repositories;
using VacationManager.ViewModels.Home;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VacationManager.Models;
using VacationManager.ExtentionMethods;

namespace VacationManager.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Redirects to the Index section.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Redirects to the Logic section.
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Logs in the user.
        /// </summary>
        /// <param name="model">User's input data: username and password.</param>
        /// <returns>Redirects to the index page.</returns>
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
        /// Logs out the user from the system.
        /// </summary>
        /// <returns>Redirects to the login page.</returns>
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("loggedUser");

            return RedirectToAction("Login", "Home");
        }
    }
}
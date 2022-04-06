using Microsoft.AspNetCore.Mvc;
using System.Linq;
using VacationManager.Models;
using VacationManager.Repositories;
using VacationManager.Services;
using VacationManager.ViewModels.Users;

namespace VacationManager.Controllers
{
    public class UsersController : Controller
    {
        private VacationManagerDbContext context;
        private UsersRepository repository;
        private UsersServices services;

        public UsersController(VacationManagerDbContext context,UsersRepository repository, UsersServices services)
        {
            this.context = context;
            this.repository = repository;
            this.services = services;
        }

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            User user = this.repository.GetOne(id);

            if (user == null)
            {
                return NotFound();
            }

            EditUsersVM editUsersViewModel = new EditUsersVM
            {
                Id = user.UserId,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                Role = user.Role
            };

            return this.View(editUsersViewModel);
        }

        [HttpPost]
        public IActionResult EditUser(EditUsersVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            User item = new User();
            item.UserId = model.Id;
            item.Username = model.Username;
            item.Password = model.Password;
            item.FirstName = model.FirstName;
            item.LastName = model.LastName;

            repository.Update(item);

            return RedirectToAction("ViewCreatedUsers", "User");
        }

        public IActionResult DeleteUser(int id)
        {
            User user = repository.GetOne(id);

            if (user == null)
            {
                return NotFound();
            }

            repository.Remove(user);

            return this.RedirectToAction("ViewCreatedUsers", "User");
        }

        public IActionResult ViewUser(int id)
        {
            ViewData["User"] = repository.GetOne(id);

            return View();
        }

        public IActionResult AddToTeam(int id)
        {
            int userId = repository.GetOne(id).UserId;
            services.AddUserToTeam(userId, id);

            return this.RedirectToAction("ViewCreatedUsers", "User");
        }

        public IActionResult ViewCreatedUsers()
        {
            ViewData["CreatedUsers"] = services.GetAllUsers();
            ViewData["Context"] = context;
            return View();
        }

        public IActionResult ViewCreatedRoles()
        {
            ViewData["CreatedUsers"] = services.GetAllUsers();
            ViewData["Context"] = context;
            return View();
        }

        

    }
}

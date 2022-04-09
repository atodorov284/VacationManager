﻿using Microsoft.AspNetCore.Mvc;
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
using Microsoft.EntityFrameworkCore;

namespace VacationManager.Controllers
{
    /// <summary>
    /// Controls the User's Role logic.
    /// </summary>
    public class RolesController : Controller
    {

        private readonly VacationManagerDbContext _context;

        public RolesController(VacationManagerDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET: Teams
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }
    }
}
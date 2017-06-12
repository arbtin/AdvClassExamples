using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EndangeredSpecies.Data;
using EndangeredSpecies.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using EndangeredSpecies.ViewModels;

namespace EndangeredSpecies.Controllers
{
    public class ManageUsersController : Controller
    {
        private ApplicationDbContext db_context;

        public ManageUsersController(ApplicationDbContext context)
        {
            db_context = context;
        }

        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var Users = db_context.Users.ToList();
            return View(Users);
        }

    }
}
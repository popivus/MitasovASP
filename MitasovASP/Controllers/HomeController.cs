using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MitasovASP.Data;
using MitasovASP.Models;

namespace MitasovASP.Controllers
{
    public class HomeController : Controller
    {
        private AppDBContent db;
        public HomeController(AppDBContent context)
        {
            this.db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Brick.ToListAsync());
        }

        public IActionResult Contacts()
        {
            return View();
        }

       
    }
}

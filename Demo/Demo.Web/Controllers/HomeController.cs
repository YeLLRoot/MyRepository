using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Demo.Web.Models;
using Demo.Data;
using Microsoft.EntityFrameworkCore;

namespace Demo.Web.Controllers
{
    public class HomeController : Controller
    {
        public MyContext dbcontext { get; }

        public HomeController(MyContext context)
        {
            dbcontext = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await dbcontext.Movies.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

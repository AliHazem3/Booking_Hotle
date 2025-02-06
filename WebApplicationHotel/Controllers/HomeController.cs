using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationHotel.Models;

namespace WebApplicationHotel.Controllers
{
    public class HomeController : Controller
    {
         


        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

 
    }
}

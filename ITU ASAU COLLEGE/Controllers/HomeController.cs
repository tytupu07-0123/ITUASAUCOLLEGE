using ITU_ASAU_COLLEGE.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ITU_ASAU_COLLEGE.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Admin");
            }
            else if (User.IsInRole("Teacher"))
            {
                return RedirectToAction("Index", "TeachersDashboard");
            }
            else if (User.IsInRole("Student"))
            {
                return RedirectToAction("Index", "StudentsDashboard");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AboutUs()
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

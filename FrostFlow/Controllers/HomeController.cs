using FrostFlow.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FrostFlow.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult PantallaPrincipal()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

    }
}

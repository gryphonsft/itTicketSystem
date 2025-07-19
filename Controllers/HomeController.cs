using System.Diagnostics;
using itTicketSystem.Filters;
using itTicketSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace itTicketSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }


        [Authorize(Roles = "Admin")]
        public IActionResult AdminView()
        {
            var assignedUsers = _context.Users
                        .Where(u => u.RoleId == 2)
                        .Select(u => new SelectListItem
                        {
                            Value = u.Id.ToString(),
                            Text = u.Username
                        })
                        .ToList();

            ViewBag.AssignedUsers = assignedUsers;

            var tickets = _context.Tickets
            .Include(t => t.AssignedToUser)
            .ToList();

            //Hali hazırdaki session'ı yakalayıp viewbag olarak view sayfasına gönderme.
            var id = HttpContext.Session.GetInt32("Id");
            var username = HttpContext.Session.GetString("username");
            var rol = HttpContext.Session.GetString("role");

            ViewBag.Id = id;
            ViewBag.Role = rol;
            ViewBag.Username = username;


            return View("AdminView", tickets);
        }



        [Authorize(Roles = "Personel,Admin")]
        public IActionResult PersonelView()
        {
            var assignedUsers = _context.Users
                        .Where(u => u.RoleId == 2)
                        .Select(u => new SelectListItem
                        {
                            Value = u.Id.ToString(),
                            Text = u.Username
                        })
                        .ToList();

            ViewBag.AssignedUsers = assignedUsers;

            var tickets = _context.Tickets
            .Include(t => t.AssignedToUser)
            .ToList();

            //Hali hazırdaki session'ı yakalayıp viewbag olarak view sayfasına gönderme.
            var id = HttpContext.Session.GetInt32("Id");
            var username = HttpContext.Session.GetString("username");
            var rol = HttpContext.Session.GetString("role");

            ViewBag.Id = id;
            ViewBag.Role = rol;
            ViewBag.Username = username;


            return View("PersonelView", tickets);
        }


        [Authorize(Roles = "Kullanıcı")]
        public IActionResult UserView()
        {

            var assignedUsers = _context.Users
            .Where(u => u.RoleId == 2)
            .Select(u => new SelectListItem
            {
                Value = u.Id.ToString(),
                Text = u.Username
            })
            .ToList();

            ViewBag.AssignedUsers = assignedUsers;

            var tickets = _context.Tickets
            .Include(t => t.AssignedToUser)
            .ToList();

            //Hali hazırdaki session'ı yakalayıp viewbag olarak view sayfasına gönderme.
            var id = HttpContext.Session.GetInt32("Id");
            var username = HttpContext.Session.GetString("username");
            var rol = HttpContext.Session.GetString("role");

            ViewBag.Id = id;
            ViewBag.Role = rol;
            ViewBag.Username = username;

            return View("UserView", tickets);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult SettingsView()
        {
            var id = HttpContext.Session.GetInt32("Id");
            var username = HttpContext.Session.GetString("username");
            var rol = HttpContext.Session.GetString("role");

            ViewBag.Id = id;
            ViewBag.Role = rol;
            ViewBag.Username = username;


            return View();
        }
        [HttpGet]
        public IActionResult About()
        {
            var id = HttpContext.Session.GetInt32("Id");
            var username = HttpContext.Session.GetString("username");
            var rol = HttpContext.Session.GetString("role");

            ViewBag.Id = id;
            ViewBag.Role = rol;
            ViewBag.Username = username;
            return View();
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

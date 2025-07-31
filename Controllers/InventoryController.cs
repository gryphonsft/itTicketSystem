using System.Diagnostics;
using itTicketSystem.Filters;
using itTicketSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace itTicketSystem.Controllers
{

    public class InventoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InventoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var id = HttpContext.Session.GetInt32("Id");
            var username = HttpContext.Session.GetString("username");
            var rol = HttpContext.Session.GetString("role");

            ViewBag.Id = id;
            ViewBag.Role = rol;
            ViewBag.Username = username;

            var BrandModelSelectDB = _context.BrandModelSelectDB.ToList();

            return View(BrandModelSelectDB);
        }
        [HttpPost]
        public async Task<IActionResult> DeviceCreate(Devices devices)
        {
            var role = HttpContext.Session.GetString("role");

            var devi = new Devices
            {
                DeviceName = devices.DeviceName,  
                DeviceType = devices.DeviceType,
                Brand = devices.Brand,
                Model = devices.Model,

                IsActive = devices.IsActive,
                CreatedAt = DateTime.Now,
                UpdatedAt = null
            };
            _context.Devices.Add(devi);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Cihaz başarıyla eklendi!";

            switch (role)
            {
                case "Admin":
                    return RedirectToAction("Index", "Inventory");
                default:
                    return RedirectToAction("Login", "Auth");
            }



        }
    }
}
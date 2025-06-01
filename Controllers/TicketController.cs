using itTicketSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace itTicketSystem.Controllers
{
    public class TicketController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketController(ApplicationDbContext context)
        {
            _context = context;

        }




        [HttpPost]
        public async Task<IActionResult> Create(TicketsCreateDto dto)
        {

            var role = HttpContext.Session.GetString("role");
            if (!ModelState.IsValid)
                return View("Index", dto);

            var ticket = new Tickets
            {
                title = dto.Title,
                description = dto.Description,
                priority = dto.Priority,
                category = dto.Category,
                assigned_to_user_id = dto.AssignedToUserId,


                user_id = HttpContext.Session.GetInt32("Id") ?? 0,
                status = null,
                created_at = DateTime.Now,
                closed_at = null
            };



            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Ticket basariyla olusturuldu!";

            switch (role)
            {
                case "Admin":
                    return RedirectToAction("AdminView", "Home");
                case "Personel":
                    return RedirectToAction("PersonelPanel", "Home");
                case "User":
                    return RedirectToAction("UserView", "Home");
                default:
                    return RedirectToAction("Login", "Auth");
            }
        }


    }


}
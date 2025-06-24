using itTicketSystem.Models;
using Microsoft.AspNetCore.Authorization;
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

        public IActionResult Index()
        {
            return View();
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
                case "Kullanici":
                    return RedirectToAction("UserView", "Home");
                default:
                    return RedirectToAction("Login", "Auth");
            }
        }


        [Authorize(Roles = "Admin,Personel")]
        public IActionResult PersonelTicket()
        {
            var id = HttpContext.Session.GetInt32("Id");
            var username = HttpContext.Session.GetString("username");
            var rol = HttpContext.Session.GetString("role");

            ViewBag.Id = id;
            ViewBag.Role = rol;
            ViewBag.Username = username;


            var tickets = _context.Tickets.Include(t => t.Users)
            .Include(t => t.AssignedToUser).ToList();

            return View(tickets);
        }

        public IActionResult TicketModal(int id)
        {
            var ticket = _context.Tickets
         .Include(t => t.Users)
         .Include(t => t.AssignedToUser)
         .FirstOrDefault(t => t.id == id);

            if (ticket == null)
                return NotFound();

            return PartialView("_TicketModalPartial", ticket);


        }

        [HttpPost]
        public IActionResult UpdateTicket(Tickets ticket)
        {
            var existing = _context.Tickets.FirstOrDefault(t => t.id == ticket.id);
            if (existing != null)
            {
                existing.title = ticket.title;
                existing.status = ticket.status;
                existing.priority = ticket.priority;
                existing.description = ticket.description;
                existing.category = ticket.category;

                if (ticket.status == "Kapalı" && existing.closed_at == null)
                {
                    existing.closed_at = DateTime.Now;
                }
                else if (ticket.status == "Açık" || ticket.status == "Beklemede")
                {
                    existing.closed_at = null;
                }
                _context.SaveChanges();
            }

            return RedirectToAction("PersonelTicket");
        }


    }



}
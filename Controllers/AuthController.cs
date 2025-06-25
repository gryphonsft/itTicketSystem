using System.Security.Claims;
using itTicketSystem.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace itTicketSystem.Controllers;

public class AuthController : Controller
{

    private readonly ApplicationDbContext _context;

    public AuthController(ApplicationDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public IActionResult Login()
    {

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {

        var user = _context.Users
        .Include(u => u.Roles)
        .FirstOrDefault(u => u.Username == username && u.Password == password);
        
        if (user != null)
        {
            HttpContext.Session.SetInt32("Id", user.Id);
            HttpContext.Session.SetString("username", user.Username);
            HttpContext.Session.SetString("role", user.Roles.RoleName);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Roles.RoleName)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            switch (user.Roles.RoleName)
            {
                case "Admin":
                    return RedirectToAction("AdminView", "Home");
                case "Personel":
                    return RedirectToAction("PersonelView", "Home");
                case "Kullanıcı":
                    return RedirectToAction("UserView", "Home");
                default:
                    return RedirectToAction("Login", "Auth");
            }
        }
        ViewBag.Error = "Geçersiz giriş";
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        HttpContext.Session.Clear();
        return RedirectToAction("Login", "Auth");
    }

    public IActionResult AccessDenied()
    {
        return View();
    }

}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using clinica2.Data;
using clinica2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;


public class AccountController : Controller
{
    private readonly ApplicationDbContext _context;

    public AccountController(ApplicationDbContext context)
    {
        _context = context;
    }
    // GET: Account/Register
    public IActionResult Register()
    {
        var sites = _context.site.ToList();
        ViewBag.Sites = new SelectList(sites, "id_site", "site_number");

        return View();
    }

    // POST: Account/Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var existingUser = await _context.patients
                .FirstOrDefaultAsync(u => u.login == model.login);

            if (existingUser != null)
            {
                ModelState.AddModelError("login", "Этот логин уже занят");
                ReloadSites(model.id_site);
                return View(model);
            }

            if (!IsStrongPassword(model.password))
            {
                ModelState.AddModelError("password", "Пароль должен содержать: 6+ символов, заглавную и строчную буквы, цифру и спецсимвол");
                ReloadSites(model.id_site);
                return View(model);
            }

            var patient = new patients
            {
                first_name = model.last_name,
                last_name = model.first_name,
                middle_name = model.middle_name,
                date_of_birth = model.date_of_birth,
                gender = model.gender,
                policy_number = model.policy_number,
                telephone = model.telephone,
                login = model.login,
                password = model.password,
                id_site = model.id_site,
                id_role = 2
            };

            _context.patients.Add(patient);
            await _context.SaveChangesAsync();

            return RedirectToAction("Login", "Account");
        }

        ReloadSites(model.id_site);
        return View(model);
    }

    private void ReloadSites(int? selectedSite = null)
    {
        ViewBag.Sites = new SelectList(_context.site.ToList(),
            "id_site", "site_number", selectedSite);
    }
    // GET: Account/Login
    public IActionResult Login()
    {
        return View();
    }
    // POST: Account/Login
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(string login, string password)
    {
        var doctor = await _context.doctors
            .FirstOrDefaultAsync(d => d.login == login && d.password == password);

        if (doctor != null)
        {
            return await AuthenticateUser(
                doctor.login,
                doctor.id_role.ToString(), "doctors", "Index", "Home");
        }
        var patient = await _context.patients
            .FirstOrDefaultAsync(p => p.login == login && p.password == password);
        if (patient != null)
        {
            return await AuthenticateUser(
                patient.login,
                patient.id_role.ToString(), "patient", "Index", "Home");
        }
        ModelState.AddModelError("", "Неверный логин или пароль");
        return View();
    }

    private async Task<IActionResult> AuthenticateUser(
        string login,
        string role,
        string userType,
        string action,
        string controller)
    {
        var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, login),
        new Claim(ClaimTypes.Role, role),
        new Claim("UserType", userType)
    };

        var claimsIdentity = new ClaimsIdentity(
            claims,
            CookieAuthenticationDefaults.AuthenticationScheme);
        var authProperties = new AuthenticationProperties();
        await HttpContext.SignInAsync(
            "YourAppCookie",
            new ClaimsPrincipal(claimsIdentity),
            authProperties);
        return RedirectToAction(action, controller);
    }
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("YourAppCookie");
        return RedirectToAction("Index", "Home");
    }
    public IActionResult Layout()
    {
        return View();
    }
    private bool IsStrongPassword(string password)
    {
        return password.Length >= 6 &&
               password.Any(char.IsUpper) &&
               password.Any(char.IsLower) &&
               password.Any(char.IsDigit) &&
               password.Any(ch => !char.IsLetterOrDigit(ch));
    }
}


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rental.DbModels;
using Rental.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginServices _loginServices;
        private readonly zavrsniContext _dbContext;
        public LoginController(LoginServices logSer, zavrsniContext dbContext)
        {
            _loginServices = logSer;
            _dbContext = dbContext;
        }

        public IActionResult SignUpKlijent()
        {
            
            if (HttpContext.Session.GetString("Role") == "Korisnik" || HttpContext.Session.GetString("Role") == "Admin")
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            return View();
        }
        [HttpPost]
        public IActionResult SignUpKlijent(string ime,string prezime,string email,string lozinka)
        {           
            if (HttpContext.Session.GetString("Role") == "Korisnik" || HttpContext.Session.GetString("Role") == "Admin")
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            var noviKorisnik = _loginServices.VerifyKlijent(ime, prezime, email, lozinka);
            
            if (noviKorisnik == null)
            {
                ViewBag.Poruka = "Morate unijeti sve podatke i lozinka mora imati najmanje 5 znakova";
                return View();
            }
            else
            {   
                _loginServices.SignUpKlijent(noviKorisnik);
                
                HttpContext.Session.SetString("Role", "Korisnik");
                HttpContext.Session.SetString("Email", noviKorisnik.EMail);
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                for (int i = 0; i < 100000000; i++)
                {

                }
                watch.Stop();
                ViewBag.TimeExecute = watch.ElapsedMilliseconds;
                
                return RedirectToRoute(new { controller = "Voziloes", action = "Index" });
            }
        }

        public IActionResult SignIn()
        {
            if (HttpContext.Session.GetString("Role") == "Korisnik" || HttpContext.Session.GetString("Role") == "Admin")

                return RedirectToRoute(new { controller = "Home", action = "Index" });
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(string username, string password)
        {
            
            if (HttpContext.Session.GetString("Role") == "Korisnik" || HttpContext.Session.GetString("Role") == "Admin")
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            var klijent = _loginServices.SignIn(username, password);
            if (klijent != null)
            {
                HttpContext.Session.SetString("Role", "Korisnik");
                HttpContext.Session.SetString("Email", klijent.EMail);
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            else
            {
                ViewBag.Message = "Pogresan unos!";
                return View();
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        public IActionResult SignInAdmin()
        {
            if (HttpContext.Session.GetString("Role") == "Korisnik" || HttpContext.Session.GetString("Role") == "Admin")
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            return View();
        }

        [HttpPost]
        public IActionResult SignInAdmin(string username, string password)
        {

            if (HttpContext.Session.GetString("Role") == "Korisnik" || HttpContext.Session.GetString("Role") == "Admin")
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            var klijent = _loginServices.SignIn(username, password);
            if (klijent != null && username=="admin" && password=="admin")
            {
                HttpContext.Session.SetString("Role", "Admin");
                HttpContext.Session.SetString("Email", klijent.EMail);
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            else if (klijent != null)
            {
                ViewBag.Message = "Prijavite se kao korisnik!";
                return View();
            }
            else
            {
                ViewBag.Message = "Pogresan unos!";
                return View();
            }
        }

    }
}

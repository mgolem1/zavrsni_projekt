using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rental.DbModels;
using Rental.Mappers;
using Rental.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rental.Controllers
{
    public class RezVozilaController : Controller
    {

        private readonly zavrsniContext _dbContext;

        public RezVozilaController(zavrsniContext db)
        {

            _dbContext = db;
        }

        int idVoz, idKl;
        public IActionResult RezervacijaVozila(int id)
        {
            var dbVoz = _dbContext.Vozilo.Where(x => (x.Idvozilo.Equals(id))).FirstOrDefault();
            HttpContext.Session.SetString("Vozilo", dbVoz.Model);
            string voz = HttpContext.Session.GetString("Vozilo");
            idVoz = id;
            HttpContext.Session.SetString("CijenaPoDanu", dbVoz.Cijena.ToString());
            var klij = HttpContext.Session.GetString("Email");
            ViewBag.K = klij;
            ViewBag.V = voz;
            var dbKl = _dbContext.Klijent.Where(x => (x.Email.Equals(klij))).FirstOrDefault();
            idKl = dbKl.Idklijent;

            ViewBag.MjestoPre = _dbContext.Mjesto.Select(i => new SelectListItem
            {
                Value = i.Idmjesto.ToString(),
                Text = i.Naziv
            }).ToList();

            ViewBag.MjestoPov = _dbContext.Mjesto.Select(i => new SelectListItem
            {
                Value = i.Idmjesto.ToString(),
                Text = i.Naziv
            }).ToList();

            ViewBag.NacinPla = _dbContext.NacinPlacanja.Select(i => new SelectListItem
            {
                Value = i.IdnacinPlacanja.ToString(),
                Text = i.Naziv
            }).ToList();

            ViewBag.Klij = _dbContext.Klijent.Select(i => new SelectListItem
            {
                Value = idKl.ToString(),
                Text = HttpContext.Session.GetString("Email").ToString()
            }).ToList();

            ViewBag.Voz = _dbContext.Vozilo.Select(i => new SelectListItem
            {
                Value = id.ToString(),
                Text = HttpContext.Session.GetString("Vozilo").ToString()
            }).ToList();

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RezervacijaVozila([Bind] Rezervacija rezervacija)
        {
            TimeSpan objTimeSpan = rezervacija.DatumDo - rezervacija.DatumOd;
            double Days = objTimeSpan.TotalHours;
            double dani = Math.Round(Days / 24);
            HttpContext.Session.SetString("ukDana", dani.ToString());
            int cij = int.Parse(HttpContext.Session.GetString("CijenaPoDanu"));
            int dani2 = int.Parse(HttpContext.Session.GetString("ukDana"));
            int uk = dani2 * cij;
            int id = rezervacija.Idrezervacija;
            HttpContext.Session.SetString("ukDana", uk.ToString());
            ViewBag.U = uk.ToString();

            if (ModelState.IsValid)
            {
                if (rezervacija.CijenaRez == null)
                {
                    rezervacija.CijenaRez = uk.ToString();
                    _dbContext.Add(rezervacija);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToRoute(new { controller = "RezVozila", action = "Details", id=rezervacija.Idrezervacija });
                }
                else
                {
                    return RedirectToRoute(new { controller = "Home", action = "Index" });
                }
                //_dbContext.Add(rezervacija);
                //await _dbContext.SaveChangesAsync();
                //return RedirectToRoute(new { controller = "Home", action = "Index" });
            }


            return RedirectToRoute(new { controller = "Home", action = "Privacy" });
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _dbContext.Rezervacija
                .Include(r => r.KlijentNavigation)
                .Include(r => r.MjestoPovrataNavigation)
                .Include(r => r.MjestoPreuzimanjaNavigation)
                .Include(r => r.NacinNavigation)
                .Include(r => r.VoziloNavigation)
                .FirstOrDefaultAsync(m => m.Idrezervacija == id);
            if (rezervacija == null)
            {
                return NotFound();
            }

            return View(rezervacija);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rental.DbModels;

namespace Rental.Controllers
{
    public class RezervacijasController : Controller
    {
        private readonly zavrsniContext _context;

        public RezervacijasController(zavrsniContext context)
        {
            _context = context;
        }

        // GET: Rezervacijas
        public async Task<IActionResult> Index()
        {
            var zavrsniContext = _context.Rezervacija.Include(r => r.KlijentNavigation).Include(r => r.MjestoPovrataNavigation).Include(r => r.MjestoPreuzimanjaNavigation).Include(r => r.NacinNavigation).Include(r => r.VoziloNavigation);
            //int cij = int.Parse(HttpContext.Session.GetString("CijenaPoDanu"));
            //int dani=int.Parse(HttpContext.Session.GetString("ukDana"));
            //int uk = dani * cij;
            //HttpContext.Session.SetString("ukCijena", uk.ToString());
            return View(await zavrsniContext.ToListAsync());
        }

        // GET: Rezervacijas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacija
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

        // GET: Rezervacijas/Create

        public  IActionResult Create()
        {

            //var dbVoz = _context.Vozilo.Where(x => (x.Idvozilo.Equals(id))).FirstOrDefault();
            //HttpContext.Session.SetString("Vozilo", dbVoz.Model);
            //var voz = HttpContext.Session.GetString("Vozilo").ToString();
            //ViewBag.Klij = HttpContext.Session.GetString("Email").ToString();
           // ViewBag.voz = HttpContext.Session.GetString("Vozilo").ToString();

            ViewData["Klijent"] = new SelectList(_context.Klijent, "Idklijent", "Email");
            ViewData["MjestoPovrata"] = new SelectList(_context.Mjesto, "Idmjesto", "Naziv");
            ViewData["MjestoPreuzimanja"] = new SelectList(_context.Mjesto, "Idmjesto", "Naziv");
            ViewData["Nacin"] = new SelectList(_context.NacinPlacanja, "IdnacinPlacanja", "Naziv");
            ViewData["Vozilo"] = new SelectList(_context.Vozilo, "Idvozilo", "Model"); ;
            return View();
        }

        // POST: Rezervacijas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idrezervacija,DatumOd,DatumDo,MjestoPreuzimanja,MjestoPovrata,Vozilo,Klijent,Nacin")] Rezervacija rezervacija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rezervacija);
                await _context.SaveChangesAsync();
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            
            
            return RedirectToRoute(new { controller = "Home", action = "Privacy" });
        }

        // GET: Rezervacijas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacija.FindAsync(id);
            if (rezervacija == null)
            {
                return NotFound();
            }
            ViewData["Klijent"] = new SelectList(_context.Klijent, "", "", rezervacija.Klijent);
            ViewData["MjestoPovrata"] = new SelectList(_context.Mjesto, "Idmjesto", "Naziv", rezervacija.MjestoPovrata);
            ViewData["MjestoPreuzimanja"] = new SelectList(_context.Mjesto, "Idmjesto", "Naziv", rezervacija.MjestoPreuzimanja);
            ViewData["Nacin"] = new SelectList(_context.NacinPlacanja, "IdnacinPlacanja", "Naziv", rezervacija.Nacin);
            ViewData["Vozilo"] = new SelectList(_context.Vozilo, "Idvozilo", "Model", rezervacija.Vozilo);
            return View(rezervacija);
        }

        // POST: Rezervacijas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idrezervacija,DatumOd,DatumDo,MjestoPreuzimanja,MjestoPovrata,Vozilo,Klijent,Nacin")] Rezervacija rezervacija)
        {
            if (id != rezervacija.Idrezervacija)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezervacija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezervacijaExists(rezervacija.Idrezervacija))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Klijent"] = new SelectList(_context.Klijent, "Idklijent", "Email", rezervacija.Klijent);
            ViewData["MjestoPovrata"] = new SelectList(_context.Mjesto, "Idmjesto", "Naziv", rezervacija.MjestoPovrata);
            ViewData["MjestoPreuzimanja"] = new SelectList(_context.Mjesto, "Idmjesto", "Naziv", rezervacija.MjestoPreuzimanja);
            ViewData["Nacin"] = new SelectList(_context.NacinPlacanja, "IdnacinPlacanja", "Naziv", rezervacija.Nacin);
            ViewData["Vozilo"] = new SelectList(_context.Vozilo, "Idvozilo", "Model", rezervacija.Vozilo);
            return View(rezervacija);
        }

        // GET: Rezervacijas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacija
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

        // POST: Rezervacijas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezervacija = await _context.Rezervacija.FindAsync(id);
            _context.Rezervacija.Remove(rezervacija);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RezervacijaExists(int id)
        {
            return _context.Rezervacija.Any(e => e.Idrezervacija == id);
        }
    }
}

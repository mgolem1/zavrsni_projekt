using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Rental.DbModels;
using Rental.Services;

namespace Rental.Controllers
{
    public class VoziloesController : Controller
    {
        private readonly zavrsniContext _context;


        public VoziloesController(zavrsniContext context)
        {
            _context = context;

            
        }

        

        // GET: Voziloes
        public async Task<IActionResult> Index()
        {
            var zavrsniContext = _context.Vozilo.Include(v => v.KategorijaNavigation);
            return View(await zavrsniContext.ToListAsync());
        }
        public async Task<IActionResult> Index2()
        {
            var zavrsniContext = _context.Vozilo.Include(v => v.KategorijaNavigation);
            return View(await zavrsniContext.ToListAsync());
        }
        public async Task<IActionResult> PopisVozila()
        {
            var zavrsniContext = _context.Vozilo.Include(v => v.KategorijaNavigation);
            return View(await zavrsniContext.ToListAsync());
        }


        // GET: Voziloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vozilo = await _context.Vozilo
                .Include(v => v.KategorijaNavigation)
                .FirstOrDefaultAsync(m => m.Idvozilo == id);
            if (vozilo == null)
            {
                return NotFound();
            }

            return View(vozilo);
        }

        // GET: Voziloes/Create
        public IActionResult Create()
        {
            ViewData["Kategorija"] = new SelectList(_context.Kategorija, "Idkategorija", "Naziv");
            return View();
        }

        // POST: Voziloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idvozilo,Model,Kategorija,Cijena,Registracija")] Vozilo vozilo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vozilo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Kategorija"] = new SelectList(_context.Kategorija, "Idkategorija", "Naziv", vozilo.Kategorija);
            return View(vozilo);
        }
        [Rental.Startup.SessionUserTimeout]
        // GET: Voziloes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vozilo = await _context.Vozilo.FindAsync(id);
            if (vozilo == null)
            {
                return NotFound();
            }
            ViewData["Kategorija"] = new SelectList(_context.Kategorija, "Idkategorija", "Naziv", vozilo.Kategorija);
            return View(vozilo);
        }

        // POST: Voziloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Idvozilo,Model,Kategorija,Cijena,Registracija")] Vozilo vozilo)
        {
            if (id != vozilo.Idvozilo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vozilo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoziloExists(vozilo.Idvozilo))
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
            ViewData["Kategorija"] = new SelectList(_context.Kategorija, "Idkategorija", "Naziv", vozilo.Kategorija);
            return View(vozilo);
        }

        // GET: Voziloes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vozilo = await _context.Vozilo
                .Include(v => v.KategorijaNavigation)
                .FirstOrDefaultAsync(m => m.Idvozilo == id);
            if (vozilo == null)
            {
                return NotFound();
            }

            return View(vozilo);
        }

        // POST: Voziloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vozilo = await _context.Vozilo.FindAsync(id);
            _context.Vozilo.Remove(vozilo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoziloExists(int id)
        {
            return _context.Vozilo.Any(e => e.Idvozilo == id);
        }
    }
}

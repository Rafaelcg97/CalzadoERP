using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CalzadoERP.Model;
using Microsoft.IdentityModel.Tokens;

namespace CalzadoERP.Controllers
{
    public class ZapateroesController : Controller
    {
        private readonly ERPContext _context;

        public ZapateroesController(ERPContext context)
        {
            _context = context;
        }

        // GET: Zapateroes
        public IActionResult Index()
        {
            List<Zapatero> listaZapateros = _context.Zapateros.ToList();

            ViewData["zapateros"] = listaZapateros;

            return View();
        }

        public IActionResult GetZapateroByNombre(string nombre)
        {
            List<Zapatero> listaZapateros = new List<Zapatero>();

            if (!nombre.IsNullOrEmpty())
            {
                listaZapateros = (from e in _context.Zapateros
                                    where e.NombreZapatero.Contains(nombre)
                                    select e).ToList();
            }

            ViewData["zapateros"] = listaZapateros;

            return View("Index");

        }

        // GET: Zapateroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Zapateros == null)
            {
                return NotFound();
            }

            var zapatero = await _context.Zapateros
                .FirstOrDefaultAsync(m => m.IdZapatero == id);
            if (zapatero == null)
            {
                return NotFound();
            }

            return View(zapatero);
        }

        // GET: Zapateroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zapateroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdZapatero,NombreZapatero,DireccionZapatero,IdentificacionZapatero,EstadoZapatero,FechaAsociacionZapatero,FechaTerminacionZapatero")] Zapatero zapatero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zapatero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zapatero);
        }

        // GET: Zapateroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Zapateros == null)
            {
                return NotFound();
            }

            var zapatero = await _context.Zapateros.FindAsync(id);
            if (zapatero == null)
            {
                return NotFound();
            }
            return View(zapatero);
        }

        // POST: Zapateroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdZapatero,NombreZapatero,DireccionZapatero,IdentificacionZapatero,EstadoZapatero,FechaAsociacionZapatero,FechaTerminacionZapatero")] Zapatero zapatero)
        {
            if (id != zapatero.IdZapatero)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zapatero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZapateroExists(zapatero.IdZapatero))
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
            return View(zapatero);
        }

        // GET: Zapateroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Zapateros == null)
            {
                return NotFound();
            }

            var zapatero = await _context.Zapateros
                .FirstOrDefaultAsync(m => m.IdZapatero == id);
            if (zapatero == null)
            {
                return NotFound();
            }

            return View(zapatero);
        }

        // POST: Zapateroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Zapateros == null)
            {
                return Problem("Entity set 'ERPContext.Zapateros'  is null.");
            }
            var zapatero = await _context.Zapateros.FindAsync(id);
            if (zapatero != null)
            {
                _context.Zapateros.Remove(zapatero);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZapateroExists(int id)
        {
          return (_context.Zapateros?.Any(e => e.IdZapatero == id)).GetValueOrDefault();
        }
    }
}

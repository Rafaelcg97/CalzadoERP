using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CalzadoERP.Model;

namespace CalzadoERP.Controllers
{
    public class DetalleEstiloesController : Controller
    {
        private readonly ERPContext _context;

        public DetalleEstiloesController(ERPContext context)
        {
            _context = context;
        }

        // GET: DetalleEstiloes
        public async Task<IActionResult> Index()
        {
            var eRPContext = _context.DetalleEstilos.Include(d => d.IdDetalleEstiloNavigation).Include(d => d.IdSkuNavigation);
            return View(await eRPContext.ToListAsync());
        }

        // GET: DetalleEstiloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DetalleEstilos == null)
            {
                return NotFound();
            }

            var detalleEstilo = await _context.DetalleEstilos
                .Include(d => d.IdDetalleEstiloNavigation)
                .Include(d => d.IdSkuNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleEstilo == id);
            if (detalleEstilo == null)
            {
                return NotFound();
            }

            return View(detalleEstilo);
        }

        // GET: DetalleEstiloes/Create
        public IActionResult Create()
        {
            ViewData["IdDetalleEstilo"] = new SelectList(_context.Estilos, "IdEstilo", "IdEstilo");
            ViewData["IdSku"] = new SelectList(_context.Skus, "IdSku", "IdSku");
            return View();
        }

        // POST: DetalleEstiloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDetalleEstilo,IdEstilo,IdSku,CantidadSkuEstilo")] DetalleEstilo detalleEstilo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleEstilo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDetalleEstilo"] = new SelectList(_context.Estilos, "IdEstilo", "IdEstilo", detalleEstilo.IdDetalleEstilo);
            ViewData["IdSku"] = new SelectList(_context.Skus, "IdSku", "IdSku", detalleEstilo.IdSku);
            return View(detalleEstilo);
        }

        // GET: DetalleEstiloes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DetalleEstilos == null)
            {
                return NotFound();
            }

            var detalleEstilo = await _context.DetalleEstilos.FindAsync(id);
            if (detalleEstilo == null)
            {
                return NotFound();
            }
            ViewData["IdDetalleEstilo"] = new SelectList(_context.Estilos, "IdEstilo", "IdEstilo", detalleEstilo.IdDetalleEstilo);
            ViewData["IdSku"] = new SelectList(_context.Skus, "IdSku", "IdSku", detalleEstilo.IdSku);
            return View(detalleEstilo);
        }

        // POST: DetalleEstiloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDetalleEstilo,IdEstilo,IdSku,CantidadSkuEstilo")] DetalleEstilo detalleEstilo)
        {
            if (id != detalleEstilo.IdDetalleEstilo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleEstilo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleEstiloExists(detalleEstilo.IdDetalleEstilo))
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
            ViewData["IdDetalleEstilo"] = new SelectList(_context.Estilos, "IdEstilo", "IdEstilo", detalleEstilo.IdDetalleEstilo);
            ViewData["IdSku"] = new SelectList(_context.Skus, "IdSku", "IdSku", detalleEstilo.IdSku);
            return View(detalleEstilo);
        }

        // GET: DetalleEstiloes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DetalleEstilos == null)
            {
                return NotFound();
            }

            var detalleEstilo = await _context.DetalleEstilos
                .Include(d => d.IdDetalleEstiloNavigation)
                .Include(d => d.IdSkuNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleEstilo == id);
            if (detalleEstilo == null)
            {
                return NotFound();
            }

            return View(detalleEstilo);
        }

        // POST: DetalleEstiloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DetalleEstilos == null)
            {
                return Problem("Entity set 'ERPContext.DetalleEstilos'  is null.");
            }
            var detalleEstilo = await _context.DetalleEstilos.FindAsync(id);
            if (detalleEstilo != null)
            {
                _context.DetalleEstilos.Remove(detalleEstilo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleEstiloExists(int id)
        {
          return (_context.DetalleEstilos?.Any(e => e.IdDetalleEstilo == id)).GetValueOrDefault();
        }
    }
}

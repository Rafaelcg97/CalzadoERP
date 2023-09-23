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
    public class LotesController : Controller
    {
        private readonly ERPContext _context;

        public LotesController(ERPContext context)
        {
            _context = context;
        }

        // GET: Lotes
        public async Task<IActionResult> Index()
        {
            var eRPContext = _context.Lotes.Include(l => l.IdEstiloNavigation).Include(l => l.IdOrdenNavigation).Include(l => l.IdZapateroNavigation);
            return View(await eRPContext.ToListAsync());
        }

        // GET: Lotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lotes == null)
            {
                return NotFound();
            }

            var lote = await _context.Lotes
                .Include(l => l.IdEstiloNavigation)
                .Include(l => l.IdOrdenNavigation)
                .Include(l => l.IdZapateroNavigation)
                .FirstOrDefaultAsync(m => m.IdLote == id);
            if (lote == null)
            {
                return NotFound();
            }

            return View(lote);
        }

        // GET: Lotes/Create
        public IActionResult Create()
        {
            ViewData["IdEstilo"] = new SelectList(_context.Estilos, "IdEstilo", "IdEstilo");
            ViewData["IdOrden"] = new SelectList(_context.Ordens, "IdOrden", "IdOrden");
            ViewData["IdZapatero"] = new SelectList(_context.Zapateros, "IdZapatero", "IdZapatero");
            return View();
        }

        // POST: Lotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLote,IdOrden,IdEstilo,IdZapatero,CantidadLote,PiezasTerminadasLote")] Lote lote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstilo"] = new SelectList(_context.Estilos, "IdEstilo", "IdEstilo", lote.IdEstilo);
            ViewData["IdOrden"] = new SelectList(_context.Ordens, "IdOrden", "IdOrden", lote.IdOrden);
            ViewData["IdZapatero"] = new SelectList(_context.Zapateros, "IdZapatero", "IdZapatero", lote.IdZapatero);
            return View(lote);
        }

        // GET: Lotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lotes == null)
            {
                return NotFound();
            }

            var lote = await _context.Lotes.FindAsync(id);
            if (lote == null)
            {
                return NotFound();
            }
            ViewData["IdEstilo"] = new SelectList(_context.Estilos, "IdEstilo", "IdEstilo", lote.IdEstilo);
            ViewData["IdOrden"] = new SelectList(_context.Ordens, "IdOrden", "IdOrden", lote.IdOrden);
            ViewData["IdZapatero"] = new SelectList(_context.Zapateros, "IdZapatero", "IdZapatero", lote.IdZapatero);
            return View(lote);
        }

        // POST: Lotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLote,IdOrden,IdEstilo,IdZapatero,CantidadLote,PiezasTerminadasLote")] Lote lote)
        {
            if (id != lote.IdLote)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoteExists(lote.IdLote))
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
            ViewData["IdEstilo"] = new SelectList(_context.Estilos, "IdEstilo", "IdEstilo", lote.IdEstilo);
            ViewData["IdOrden"] = new SelectList(_context.Ordens, "IdOrden", "IdOrden", lote.IdOrden);
            ViewData["IdZapatero"] = new SelectList(_context.Zapateros, "IdZapatero", "IdZapatero", lote.IdZapatero);
            return View(lote);
        }

        // GET: Lotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lotes == null)
            {
                return NotFound();
            }

            var lote = await _context.Lotes
                .Include(l => l.IdEstiloNavigation)
                .Include(l => l.IdOrdenNavigation)
                .Include(l => l.IdZapateroNavigation)
                .FirstOrDefaultAsync(m => m.IdLote == id);
            if (lote == null)
            {
                return NotFound();
            }

            return View(lote);
        }

        // POST: Lotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lotes == null)
            {
                return Problem("Entity set 'ERPContext.Lotes'  is null.");
            }
            var lote = await _context.Lotes.FindAsync(id);
            if (lote != null)
            {
                _context.Lotes.Remove(lote);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoteExists(int id)
        {
          return (_context.Lotes?.Any(e => e.IdLote == id)).GetValueOrDefault();
        }
    }
}

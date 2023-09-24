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
    public class SkusController : Controller
    {
        private readonly ERPContext _context;

        public SkusController(ERPContext context)
        {
            _context = context;
        }

        // GET: Skus
        public IActionResult Index()
        {
            List<Sku> listaSku = _context.Skus.ToList();

            ViewData["skus"] = listaSku;

            return View();
        }

        public IActionResult GetSkuByNombre(string nombre)
        {
            List<Sku> listaSku = new List<Sku>();

            if (!nombre.IsNullOrEmpty())
            {
                listaSku = (from e in _context.Skus
                                 where e.NombreSku.Contains(nombre)
                                 select e).ToList();
            }

            ViewData["skus"] = listaSku;

            return View("Index");

        }

        // GET: Skus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Skus == null)
            {
                return NotFound();
            }

            var sku = await _context.Skus
                .Include(s => s.IdProveedorNavigation)
                .FirstOrDefaultAsync(m => m.IdSku == id);
            if (sku == null)
            {
                return NotFound();
            }

            return View(sku);
        }

        // GET: Skus/Create
        public IActionResult Create()
        {
            ViewData["IdProveedor"] = new SelectList(_context.Proveedors, "IdProveedor", "IdProveedor");
            return View();
        }

        // POST: Skus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSku,NombreSku,ColorSku,IdProveedor,PrecioUnitarioSku,UnidadSku,ComentariosSku")] Sku sku)
        {

            _context.Add(sku);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


            ViewData["IdProveedor"] = new SelectList(_context.Proveedors, "IdProveedor", "IdProveedor", sku.IdProveedor);
            return View(sku);
        }

        // GET: Skus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Skus == null)
            {
                return NotFound();
            }

            var sku = await _context.Skus.FindAsync(id);
            if (sku == null)
            {
                return NotFound();
            }
            ViewData["IdProveedor"] = new SelectList(_context.Proveedors, "IdProveedor", "IdProveedor", sku.IdProveedor);
            return View(sku);
        }

        // POST: Skus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSku,NombreSku,ColorSku,IdProveedor,PrecioUnitarioSku,UnidadSku,ComentariosSku")] Sku sku)
        {
            if (id != sku.IdSku)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sku);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkuExists(sku.IdSku))
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
            ViewData["IdProveedor"] = new SelectList(_context.Proveedors, "IdProveedor", "IdProveedor", sku.IdProveedor);
            return View(sku);
        }

        // GET: Skus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Skus == null)
            {
                return NotFound();
            }

            var sku = await _context.Skus
                .Include(s => s.IdProveedorNavigation)
                .FirstOrDefaultAsync(m => m.IdSku == id);
            if (sku == null)
            {
                return NotFound();
            }

            return View(sku);
        }

        // POST: Skus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Skus == null)
            {
                return Problem("Entity set 'ERPContext.Skus'  is null.");
            }
            var sku = await _context.Skus.FindAsync(id);
            if (sku != null)
            {
                _context.Skus.Remove(sku);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkuExists(int id)
        {
          return (_context.Skus?.Any(e => e.IdSku == id)).GetValueOrDefault();
        }
    }
}

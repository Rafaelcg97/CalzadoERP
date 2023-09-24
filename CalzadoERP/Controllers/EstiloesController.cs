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
    public class EstiloesController : Controller
    {
        private readonly ERPContext _context;

        public EstiloesController(ERPContext context)
        {
            _context = context;
        }

        // GET: Estiloes
        public IActionResult Index()
        {
            List<Estilo> listaEstilos = _context.Estilos.ToList();

            ViewData["estilos"] = listaEstilos;

            return View();
        }

        public IActionResult GetEstiloByNombre(string nombre)
        {
            List<Estilo> listaEstilos = new List<Estilo>();

            if (!nombre.IsNullOrEmpty())
            {
                listaEstilos = (from e in _context.Estilos
                                             where e.NombreEstilo.Contains(nombre)
                                             select e).ToList();
            }

            ViewData["estilos"] = listaEstilos;

            return View("Index");

        }


        // GET: Estiloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Estilos == null)
            {
                return NotFound();
            }

            var estilo = await _context.Estilos
                .FirstOrDefaultAsync(m => m.IdEstilo == id);
            if (estilo == null)
            {
                return NotFound();
            }

            return View(estilo);
        }

        // GET: Estiloes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estiloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstilo,NombreEstilo,ColorEstilo,GeneroEstilo,PrecioEstilo,ComentariosEstilo")] Estilo estilo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estilo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estilo);
        }

        // GET: Estiloes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Estilos == null)
            {
                return NotFound();
            }

            var estilo = await _context.Estilos.FindAsync(id);
            if (estilo == null)
            {
                return NotFound();
            }
            return View(estilo);
        }

        // POST: Estiloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstilo,NombreEstilo,ColorEstilo,GeneroEstilo,PrecioEstilo,ComentariosEstilo")] Estilo estilo)
        {
            if (id != estilo.IdEstilo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estilo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstiloExists(estilo.IdEstilo))
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
            return View(estilo);
        }

        // GET: Estiloes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Estilos == null)
            {
                return NotFound();
            }

            var estilo = await _context.Estilos
                .FirstOrDefaultAsync(m => m.IdEstilo == id);
            if (estilo == null)
            {
                return NotFound();
            }

            return View(estilo);
        }

        // POST: Estiloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Estilos == null)
            {
                return Problem("Entity set 'ERPContext.Estilos'  is null.");
            }
            var estilo = await _context.Estilos.FindAsync(id);
            if (estilo != null)
            {
                _context.Estilos.Remove(estilo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstiloExists(int id)
        {
          return (_context.Estilos?.Any(e => e.IdEstilo == id)).GetValueOrDefault();
        }
    }
}

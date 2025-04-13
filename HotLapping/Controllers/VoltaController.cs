using Circuitos.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Circuitos.Data;

namespace Circuitos.Controllers
{
    public class VoltaController : Controller
    {
        private readonly CircuitosContext _context;

        public VoltaController(CircuitosContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var voltas = _context.Voltas
                                 .Include(v => v.Carro)
                                 .Include(v => v.Circuito)
                                 .OrderBy(v => v.DataHora);
            return View(await voltas.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["CarroID"] = new SelectList(_context.Carros, "CarroID", "Modelo");
            ViewData["CircuitoID"] = new SelectList(_context.Circuitos, "CircuitoID", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CarroID,CircuitoID,Tempo")] Volta volta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    volta.DataHora = DateTime.Now;
                    _context.Add(volta);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados.");
            }

            ViewData["CarroID"] = new SelectList(_context.Carros, "CarroID", "Modelo", volta.CarroID);
            ViewData["CircuitoID"] = new SelectList(_context.Circuitos, "CircuitoID", "Nome", volta.CircuitoID);
            return View(volta);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var volta = await _context.Voltas.FindAsync(id);
            if (volta == null)
                return NotFound();

            ViewData["CarroID"] = new SelectList(_context.Carros, "CarroID", "Modelo", volta.CarroID);
            ViewData["CircuitoID"] = new SelectList(_context.Circuitos, "CircuitoID", "Nome", volta.CircuitoID);
            return View(volta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VoltaID,CarroID,CircuitoID,Tempo,DataHora")] Volta volta)
        {
            if (id != volta.VoltaID)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(volta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoltaExists(volta.VoltaID))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["CarroID"] = new SelectList(_context.Carros, "CarroID", "Modelo", volta.CarroID);
            ViewData["CircuitoID"] = new SelectList(_context.Circuitos, "CircuitoID", "Nome", volta.CircuitoID);
            return View(volta);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var volta = await _context.Voltas
                .Include(v => v.Carro)
                .Include(v => v.Circuito)
                .FirstOrDefaultAsync(m => m.VoltaID == id);

            if (volta == null)
                return NotFound();

            return View(volta);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var volta = await _context.Voltas
                .Include(v => v.Carro)
                .Include(v => v.Circuito)
                .FirstOrDefaultAsync(m => m.VoltaID == id);

            if (volta == null)
                return NotFound();

            return View(volta);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var volta = await _context.Voltas.FindAsync(id);
            _context.Voltas.Remove(volta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoltaExists(int id)
        {
            return _context.Voltas.Any(e => e.VoltaID == id);
        }
    }
}

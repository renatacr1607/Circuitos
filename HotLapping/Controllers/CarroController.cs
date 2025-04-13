using Circuitos.Data;
using Circuitos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Circuitos.Controllers
{
    public class CarroController : Controller
    {
        private readonly CircuitosContext _context;

        public CarroController(CircuitosContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Carros.OrderBy(c => c.Marca).ThenBy(c => c.Modelo).ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Marca,Modelo,Potencia,Peso,Tracao,AnoFabricacao")] Carro carro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(carro);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                ModelState.AddModelError("", "Erro ao inserir carro.");
            }

            return View(carro);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var carro = await _context.Carros.FindAsync(id);
            if (carro == null) return NotFound();

            return View(carro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarroID,Marca,Modelo,Potencia,Peso,Tracao,AnoFabricacao")] Carro carro)
        {
            if (id != carro.CarroID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carro);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarroExists(carro.CarroID)) return NotFound();
                    else throw;
                }
            }

            return View(carro);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var carro = await _context.Carros.FirstOrDefaultAsync(c => c.CarroID == id);
            if (carro == null) return NotFound();

            return View(carro);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var carro = await _context.Carros.FirstOrDefaultAsync(c => c.CarroID == id);
            if (carro == null) return NotFound();

            return View(carro);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carro = await _context.Carros.FindAsync(id);
            _context.Carros.Remove(carro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarroExists(int id)
        {
            return _context.Carros.Any(e => e.CarroID == id);
        }
    }
}
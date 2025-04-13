using Circuitos.Data;
using Circuitos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Circuitos.Controllers
{
    public class CircuitoController : Controller
    {
        private readonly CircuitosContext _context;

        public CircuitoController(CircuitosContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Circuitos.OrderBy(c => c.Nome).ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Pais,Cidade,Tamanho,NumeroCurvas,Recorde,RecordePiloto,RecordeCarro,Imagem")] Circuito circuito)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(circuito);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                ModelState.AddModelError("", "Erro ao inserir circuito.");
            }

            return View(circuito);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var circuito = await _context.Circuitos.FindAsync(id);
            if (circuito == null) return NotFound();

            return View(circuito);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CircuitoID,Nome,Pais,Cidade,Tamanho,NumeroCurvas,Recorde,RecordePiloto,RecordeCarro,Imagem")] Circuito circuito)
        {
            if (id != circuito.CircuitoID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(circuito);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CircuitoExists(circuito.CircuitoID)) return NotFound();
                    else throw;
                }
            }

            return View(circuito);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var circuito = await _context.Circuitos.FirstOrDefaultAsync(c => c.CircuitoID == id);
            if (circuito == null) return NotFound();

            return View(circuito);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var circuito = await _context.Circuitos.FirstOrDefaultAsync(c => c.CircuitoID == id);
            if (circuito == null) return NotFound();

            return View(circuito);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var circuito = await _context.Circuitos.FindAsync(id);
            _context.Circuitos.Remove(circuito);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CircuitoExists(int id)
        {
            return _context.Circuitos.Any(e => e.CircuitoID == id);
        }
    }
}

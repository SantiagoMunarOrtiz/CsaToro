using Microsoft.AspNetCore.Mvc;
using MVCCRUD.Models;
using Microsoft.EntityFrameworkCore;

public class VendedoresController : Controller
{
    private readonly MVCCRUDContext _context;

    public VendedoresController(MVCCRUDContext context)
    {
        _context = context;
    }

    // Mostrar lista de vendedores
    public async Task<IActionResult> Index()
    {
        return View(await _context.Vendedores.ToListAsync());
    }

    // Editar vendedor
    public async Task<IActionResult> Edit(string? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var vendedor = await _context.Vendedores.FindAsync(id);
        if (vendedor == null)
        {
            return NotFound();
        }

        return View(vendedor);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, [Bind("Cedula,Nombre,Telefono")] Vendedor vendedor)
    {
        if (id != vendedor.Cedula)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _context.Update(vendedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(vendedor);
    }
}

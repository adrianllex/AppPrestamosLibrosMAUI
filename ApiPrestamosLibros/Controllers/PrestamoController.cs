using Microsoft.AspNetCore.Mvc;
using ApiPrestamosLibros.Models;
using ApiPrestamosLibros.Data;

namespace ApiPrestamosLibros.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrestamoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PrestamoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPrestamos()
        {
            var prestamos = _context.Prestamos.ToList();
            return Ok(prestamos);
        }

        [HttpGet("{id}")]
        public IActionResult GetPrestamo(int id)
        {
            var prestamo = _context.Prestamos.FirstOrDefault(p => p.Id == id);
            if (prestamo == null)
            {
                return NotFound();
            }
            return Ok(prestamo);
        }

        [HttpPost]
        public IActionResult CrearPrestamo(Prestamo prestamo)
        {
            _context.Prestamos.Add(prestamo);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetPrestamo), new { id = prestamo.Id }, prestamo);
        }
    }
}


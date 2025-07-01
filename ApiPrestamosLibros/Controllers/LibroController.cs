using Microsoft.AspNetCore.Mvc;
using ApiPrestamosLibros.Models;
using ApiPrestamosLibros.Data;

namespace ApiPrestamosLibros.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibroController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LibroController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/libro
        [HttpGet]
        public IActionResult GetLibros()
        {
            var libros = _context.Libros.ToList();
            return Ok(libros);
        }

        // GET: api/libro/{id}
        [HttpGet("{id}")]
        public IActionResult GetLibro(int id)
        {
            var libro = _context.Libros.FirstOrDefault(l => l.Id == id);
            if (libro == null)
                return NotFound();

            return Ok(libro);
        }

        // POST: api/libro
        [HttpPost]
        public IActionResult CrearLibro(Libro libro)
        {
            _context.Libros.Add(libro);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetLibro), new { id = libro.Id }, libro);
        }

        // PUT: api/libro/{id}
        [HttpPut("{id}")]
        public IActionResult ActualizarLibro(int id, Libro libroActualizado)
        {
            var libro = _context.Libros.FirstOrDefault(l => l.Id == id);
            if (libro == null)
                return NotFound();

            libro.Titulo = libroActualizado.Titulo;
            libro.Autor = libroActualizado.Autor;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/libro/{id}
        [HttpDelete("{id}")]
        public IActionResult EliminarLibro(int id)
        {
            var libro = _context.Libros.FirstOrDefault(l => l.Id == id);
            if (libro == null)
                return NotFound();

            _context.Libros.Remove(libro);
            _context.SaveChanges();
            return NoContent();
        }
    }
}



using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ApiPrestamosLibros.Data; 
using ApiPrestamosLibros.Models;

namespace ApiPrestamosLibros.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> GetUsuarios()
        {
            return _context.Usuarios.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> GetUsuario(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }
            return usuario;
        }

        [HttpPost]
        public ActionResult<Usuario> CrearUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }
    }
}

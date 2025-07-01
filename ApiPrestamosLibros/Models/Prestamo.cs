using System;

namespace ApiPrestamosLibros.Models
{
    public class Prestamo
    {
        public int Id { get; set; }

        // Clave foránea para el usuario
        public int UsuarioId { get; set; }

        // Clave foránea para el libro
        public int LibroId { get; set; }

        // Fecha de préstamo
        public DateTime FechaPrestamo { get; set; }

        // Fecha de devolución (puede ser null si aún no se ha devuelto)
        public DateTime? FechaDevolucion { get; set; }

        // Propiedad de navegación hacia Usuario
        public Usuario Usuario { get; set; }

        // Propiedad de navegación hacia Libro
        public Libro Libro { get; set; }
    }
}



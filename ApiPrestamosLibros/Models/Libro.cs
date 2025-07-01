using System.Collections.Generic;

namespace ApiPrestamosLibros.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; } 
        public string Genero { get; set; }

        // Relación con los préstamos
        public List<Prestamo> Prestamos { get; set; }
    }
}


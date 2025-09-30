using Microsoft.EntityFrameworkCore;
using PERROVERDE8.API.Models;

namespace PERROVERDE8.API.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    
    public DbSet<Product> Products { get; set; }

    // Aquí cada compañero irá agregando sus tablas (DbSet)
    // Ejemplo:
    // public DbSet<Alumno> Alumnos { get; set; }
    // public DbSet<Curso> Cursos { get; set; }
}
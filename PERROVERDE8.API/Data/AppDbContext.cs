using Microsoft.EntityFrameworkCore;
using PERROVERDE8.API.Models;

namespace PERROVERDE8.API.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
}
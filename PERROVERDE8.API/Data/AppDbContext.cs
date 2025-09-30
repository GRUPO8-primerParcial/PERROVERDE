using Microsoft.EntityFrameworkCore;
using PERROVERDE8.API.Models;

namespace PERROVERDE8.API.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Event> Events { get; set; }
    public DbSet<Product> Products { get; set; }
    
    public DbSet<SupportTicket> SupportTickets { get; set; }
}
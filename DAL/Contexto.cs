using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RegistroExpedientes.Model;

public class ApplicationDbContext : IdentityDbContext
{
    
    public DbSet<Expedientes> Expedientes { get; set; }
    public DbSet<Usuarios> Usuarios { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    

}
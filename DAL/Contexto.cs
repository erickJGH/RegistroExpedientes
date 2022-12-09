using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RegistroExpedientes.Model;

public class ApplicationDbContext : IdentityDbContext
{
    
    public DbSet<Expedientes> Expedientes { get; set; }
    public DbSet<Usuarios> Usuarios { get; set; }

    // public Internal.InternalDbSet<TEntity>.get_EntityType();
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    

}
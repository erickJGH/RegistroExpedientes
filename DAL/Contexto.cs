using Microsoft.EntityFrameworkCore;
using RegistroExpedientes.Model;

public class Contexto : DbContext
{
    
    public DbSet<Expedientes> Expedientes { get; set; }
    public DbSet<Usuarios> Usuarios { get; set; }
    
    // public Internal.InternalDbSet<TEntity>.get_EntityType();
    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
    }

}
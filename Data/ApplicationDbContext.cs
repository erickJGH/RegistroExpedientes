using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RegistroExpedientes.Model;

namespace RegistroExpedientes.Data
{
    public class Contexto : IdentityDbContext
    {
        public virtual DbSet<Departamento> Departamentos { get; set; } = null!;
        public virtual DbSet<Expediente> Expedientes { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        {
        }
    }
}
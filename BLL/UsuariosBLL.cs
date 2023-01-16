using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RegistroExpedientes.Model;

public class UsuariosBLL
{
    private ApplicationDbContext _contexto;

    public UsuariosBLL(ApplicationDbContext context)
    {
        _contexto = context;
    }

    public async Task<bool> Existe(int idUsuario)
    {
        return await _contexto.Usuarios.AnyAsync(o => o.IdUsuario == idUsuario);
    }

    private async Task<bool> Insertar(Usuarios usuario)
    {
        using (var transaction = _contexto.Database.BeginTransaction())
        {
            try
            {
                _contexto.Usuarios.Add(usuario);
                var result = await _contexto.SaveChangesAsync();
                transaction.Commit();
                return result > 0;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }

    private async Task<bool> Modificar(Usuarios usuario)
    {
        using (var transaction = _contexto.Database.BeginTransaction())
        {
            try
            {
                _contexto.Entry(usuario).State = EntityState.Modified;
                var result = await _contexto.SaveChangesAsync();
                transaction.Commit();
                return result > 0;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }

    public async Task<bool> Guardar(Usuarios usuario)
    {
        if (!await Existe(usuario.IdUsuario))
            return await this.Insertar(usuario);
        else
            return await this.Modificar(usuario);
    }

    public async Task<bool> Eliminar(Usuarios usuario)
    {
        using (var transaction = _contexto.Database.BeginTransaction())
        {
            try
            {
                _contexto.Entry(usuario).State = EntityState.Deleted;
                var result = await _contexto.SaveChangesAsync();
                transaction.Commit();
                return result > 0;
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }

    public async Task<bool> Eliminacion(Usuarios usuario)
    {
        bool elimino;
        if (await Existe(usuario.IdUsuario))
            return elimino = true && await this.Eliminar(usuario);
        else
            return elimino = false;
    }

    public async Task<Usuarios?> Buscar(int IdUsuario)
    {
        return await _contexto.Usuarios.FindAsync(IdUsuario);
    }

    public async Task<List<Usuarios>> GetList(Expression<Func<Usuarios, bool>> Criterio)
    {
        return await _contexto.Usuarios.AsNoTracking().Where(Criterio).ToListAsync();
    }

}




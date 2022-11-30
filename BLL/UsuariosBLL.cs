using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RegistroExpedientes.Model;

public class UsuariosBLL
{
    private ExpedientesContext _contexto;

    public UsuariosBLL(ExpedientesContext context)
    {
        _contexto = context;
    }

    public async Task<bool> Existe(int idUsuario)
    {
        return await _contexto.Usuarios.AnyAsync(o => o.IdUsuario == idUsuario);
    }

    private async Task<bool> Insertar(Usuarios usuario)
    {
        _contexto.Usuarios.Add(usuario);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Usuarios usuario)
    {
        _contexto.Entry(usuario).State = EntityState.Modified;
        return await _contexto.SaveChangesAsync() > 0;
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
        _contexto.Entry(usuario).State = EntityState.Deleted;
        return await _contexto.SaveChangesAsync() > 0;
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
        return await _contexto.Usuarios
                .Where(o => o.IdUsuario == IdUsuario)
                .AsTracking()
                .SingleOrDefaultAsync();

    }
    public async Task<List<Usuarios>> GetList(Expression<Func<Usuarios, bool>> Criterio)
    {
        return await _contexto.Usuarios
            .AsTracking()
            .Where(Criterio)
            .ToListAsync();
    }

}


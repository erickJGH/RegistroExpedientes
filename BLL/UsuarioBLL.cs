using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RegistroExpedientes.Model;

public class UsuarioBLL
{
    private ExpedientesContext _contexto;

    public UsuarioBLL(ExpedientesContext context)
    {
        _contexto = context;
    }

    public async Task<bool> Existe(int idUsuario)
    {
        return await _contexto.Usuarios.AnyAsync(o => o.IdUsuario == idUsuario);
    }

    private async Task<bool> Insertar(Usuario usuario)
    {
        _contexto.Usuarios.Add(usuario);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Usuario usuario)
    {
        _contexto.Entry(usuario).State = EntityState.Modified;
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Usuario usuario)
    {
        if (!await Existe(usuario.IdUsuario))
            return await this.Insertar(usuario);
        else
            return await this.Modificar(usuario);
    }

    public async Task<bool> Eliminar(Usuario usuario)
    {
        _contexto.Entry(usuario).State = EntityState.Deleted;
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Eliminacion(Usuario usuario)
    {
        bool elimino;
        if (await Existe(usuario.IdUsuario))
            return elimino = true && await this.Eliminar(usuario);
        else
            return elimino = false;
    }

    public async Task<Usuario?> Buscar(int IdUsuario)
    {
        return await _contexto.Usuarios
                .Where(o => o.IdUsuario == IdUsuario)
                .AsTracking()
                .SingleOrDefaultAsync();

    }
    public async Task<List<Usuario>> GetList(Expression<Func<Usuario, bool>> Criterio)
    {
        return await _contexto.Usuarios
            .AsTracking()
            .Where(Criterio)
            .ToListAsync();
    }

}

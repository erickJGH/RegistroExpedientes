using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RegistroExpedientes.Model;

public class ExpedienteBLL
{
    private ExpedientesContext _contexto;

    public ExpedienteBLL(ExpedientesContext context)
    {
        _contexto = context;
    }

    public async Task<bool> Existe(int idExpediente)
    {
        return await _contexto.Expedientes.AnyAsync(o => o.IdExpediente == idExpediente);
    }

    private async Task<bool> Insertar(Expediente expediente)
    {
        _contexto.Expedientes.Add(expediente);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Expediente expediente)
    {
        _contexto.Entry(expediente).State = EntityState.Modified;
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Expediente expediente)
    {
        if (!await Existe(expediente.IdExpediente))
            return await this.Insertar(expediente);
        else
            return await this.Modificar(expediente);
    }

    public async Task<bool> Eliminar(Expediente expediente)
    {
        _contexto.Entry(expediente).State = EntityState.Deleted;
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Eliminacion(Expediente expediente)
    {
        bool elimino;
        if (await Existe(expediente.IdExpediente))
            return elimino = true && await this.Eliminar(expediente);
        else
            return elimino = false;
    }

    public async Task<Expediente?> Buscar(int IdExpediente)
    {
        return await _contexto.Expedientes
                .Where(o => o.IdExpediente == IdExpediente)
                .AsTracking()
                .SingleOrDefaultAsync();

    }
    public async Task<List<Expediente>> GetList(Expression<Func<Expediente, bool>> Criterio)
    {
        return await _contexto.Expedientes
            .AsTracking()
            .Where(Criterio)
            .ToListAsync();
    }

}


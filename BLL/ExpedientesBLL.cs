using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RegistroExpedientes.Model;

public class ExpedientesBLL
{
    private ApplicationDbContext _contexto;

    public ExpedientesBLL(ApplicationDbContext context)
    {
        _contexto = context;
    }

    public async Task<bool> Existe(int idExpediente)
    {
        return await _contexto.Expedientes.AnyAsync(o => o.IdExpediente == idExpediente);
    }

    private async Task<bool> Insertar(Expedientes expediente)
    {
        using var transaction = await _contexto.Database.BeginTransactionAsync();
        try
        {
            _contexto.Expedientes.Add(expediente);
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


    private async Task<bool> Modificar(Expedientes expediente)
    {
        using var transaction = await _contexto.Database.BeginTransactionAsync();
        try
        {
            _contexto.Update(expediente);
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

    public async Task<bool> Guardar(Expedientes expediente)
    {
        return expediente.IdExpediente == 0 ? await Insertar(expediente) : await Modificar(expediente);
    }

    public async Task<bool> Eliminar(Expedientes expediente)
    {
        using (var transaction = _contexto.Database.BeginTransaction())
        {
            try
            {
                _contexto.Entry(expediente).State = EntityState.Deleted;
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

    public async Task<bool> Eliminacion(Expedientes expediente)
    {
        bool elimino;
        if (await Existe(expediente.IdExpediente))
            return elimino = true && await this.Eliminar(expediente);
        else
            return elimino = false;
    }

    public async Task<Expedientes?> Buscar(int IdExpediente)
    {
        return await _contexto.Expedientes.FindAsync(IdExpediente);
    }

    public async Task<List<Expedientes>> GetList(Expression<Func<Expedientes, bool>> Criterio)
    {
        return await _contexto.Expedientes.AsNoTracking().Where(Criterio).ToListAsync();
    }

}

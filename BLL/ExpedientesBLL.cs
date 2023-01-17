using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistroExpedientes.Model;

public class ExpedienteBLL
{
    private readonly ApplicationDbContext _contexto;
    private EntityState _state;


    public ExpedienteBLL(ApplicationDbContext context)
    {
        _contexto = context;
    }

    public async Task<bool> Existe(int idExpediente)
    {
        return await _contexto.Expedientes.AnyAsync(o => o.IdExpediente == idExpediente);
    }

    private async Task<bool> Insertar(Expedientes expediente)
    {
        _contexto.Expedientes.Add(expediente);
        _state = EntityState.Added;
        return await SaveChangesAsync();
    }

    private async Task<bool> Modificar(Expedientes expediente)
    {
        _contexto.Entry(expediente).State = _state;
        _state = EntityState.Modified;

        return await SaveChangesAsync();
    }

    public async Task<bool> Guardar(Expedientes expediente)
    {
        bool expedienteExiste = await Existe(expediente.IdExpediente);
        if (!expedienteExiste)
            return await this.Insertar(expediente);
        else
            return await this.Modificar(expediente);
    }

    public async Task<bool> Eliminar(Expedientes expediente)
    {
        _contexto.Entry(expediente).State = _state;
        _state = EntityState.Deleted;
        return await SaveChangesAsync();
    }
    public async Task<bool> Eliminacion(Expedientes expediente)
    {
        bool elimino;
        bool expedienteExiste = await Existe(expediente.IdExpediente);
        if (expedienteExiste)
            elimino = true && await this.Eliminar(expediente);
        else
            elimino = false;
        return elimino;
    }
    public async Task<Expedientes?> Buscar(int IdExpediente)
    {
        return await _contexto.Expedientes
                .Where(o => o.IdExpediente == IdExpediente)
                .SingleOrDefaultAsync();
    }
    public async Task<List<Expedientes>> GetList(Expression<Func<Expedientes, bool>> Criterio)
    {
        return await _contexto.Expedientes
            .Where(Criterio)
            .ToListAsync();
    }

    private async Task<bool> SaveChangesAsync()
    {
        return await _contexto.SaveChangesAsync() > 0;
    }
}



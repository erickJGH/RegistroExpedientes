using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RegistroExpedientes.Model;

public class DepartamentoBLL
{
    private Contexto _contexto;

    public DepartamentoBLL(Contexto context)
    {
        _contexto = context;
    }

    public async Task<bool> Existe(int idDepartamento)
    {
        return await _contexto.Departamentos.AnyAsync(o => o.IdDepartamento == idDepartamento);
    }

    private async Task<bool> Insertar(Departamentos departamento)
    {
        _contexto.Departamentos.Add(departamento);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(Departamentos departamento)
    {
        _contexto.Entry(departamento).State = EntityState.Modified;
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(Departamentos departamento)
    {
        if (!await Existe(departamento.IdDepartamento))
            return await this.Insertar(departamento);
        else
            return await this.Modificar(departamento);
    }

    public async Task<bool> Eliminar(Departamentos departamento)
    {
        _contexto.Entry(departamento).State = EntityState.Deleted;
        return await _contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Eliminacion(Departamentos departamento)
    {
        bool elimino;
        if (await Existe(departamento.IdDepartamento))
            return elimino = true && await this.Eliminar(departamento);
        else
            return elimino = false;
    }

    public async Task<Departamentos?> Buscar(int IdDepartamento)
    {
        return await _contexto.Departamentos
                .Where(o => o.IdDepartamento == IdDepartamento)
                .AsTracking()
                .SingleOrDefaultAsync();

    }
    public async Task<List<Departamentos>> GetList(Expression<Func<Departamentos, bool>> Criterio)
    {
        return await _contexto.Departamentos
            .AsTracking()
            .Where(Criterio)
            .ToListAsync();
    }

}


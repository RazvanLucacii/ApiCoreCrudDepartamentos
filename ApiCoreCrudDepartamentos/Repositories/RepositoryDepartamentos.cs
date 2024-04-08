using ApiCoreCrudDepartamentos.Data;
using ApiCoreCrudDepartamentos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCoreCrudDepartamentos.Repositories
{
    public class RepositoryDepartamentos
    {
        private DepartamentoContext context;

        public RepositoryDepartamentos(DepartamentoContext context)
        {
            this.context = context;
        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            return await this.context.Departamentos.ToListAsync();
        }

        public async Task<Departamento> GetDepartamentoAsync(int iddepartamento)
        {
            return await this.context.Departamentos.FirstOrDefaultAsync(z => z.IdDepartamento == iddepartamento);
        }

        public async Task InsertDepartamentoAsync(int id, string nombre, string localidad)
        {
            Departamento departamento = new Departamento();
            departamento.IdDepartamento = id;
            departamento.Nombre = nombre;
            departamento.Localidad = localidad;
            this.context.Departamentos.Add(departamento);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateDepartamentoAsync(int id, string nombre, string localidad)
        {
            Departamento departamento = await this.GetDepartamentoAsync(id);
            departamento.Nombre = nombre;
            departamento.Localidad = localidad;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteDepartamentoAsync(int id)
        {
            Departamento departamento = await this.GetDepartamentoAsync(id);
            this.context.Departamentos.Remove(departamento);
            await this.context.SaveChangesAsync();
        }


    }
}

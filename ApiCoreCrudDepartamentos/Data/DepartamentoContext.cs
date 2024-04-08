using ApiCoreCrudDepartamentos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCoreCrudDepartamentos.Data
{
    public class DepartamentoContext : DbContext
    {
        public DepartamentoContext(DbContextOptions<DepartamentoContext>options):base(options) { }

        public DbSet<Departamento> Departamentos { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace DesafioTecnico.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext()
        {

        }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Equipamento> Equipamentos { get; set; }
    }
}

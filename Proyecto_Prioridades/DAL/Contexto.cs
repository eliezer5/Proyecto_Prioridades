using Microsoft.EntityFrameworkCore;
using Proyecto_Prioridades.Models;

namespace Proyecto_Prioridades.DAL
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }
        public DbSet<Prioridades> Prioridades { get; set; }
    }
}

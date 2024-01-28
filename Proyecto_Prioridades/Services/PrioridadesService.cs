using Microsoft.EntityFrameworkCore;
using Proyecto_Prioridades.DAL;
using Proyecto_Prioridades.Models;
using System.Linq.Expressions;

namespace Proyecto_Prioridades.BLL
{
    public class PrioridadesService
    {
        private readonly Contexto _contexto;
        public PrioridadesService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> Save(Prioridades prioridad)
        {
            if (_contexto.Prioridades.Any(p => p.Descripción.ToLower() == prioridad.Descripción.ToLower()))
            {
                return false;
            }
            if (prioridad.PrioridadId == 0)
                _contexto.Prioridades.Add(prioridad);
            else
                _contexto.Update(prioridad);
           
            var saved = await _contexto.SaveChangesAsync() > 0;
            return saved;
        }

        public async Task<Prioridades?> FindAsync(int id)
        {
            var prioridad = await _contexto.Prioridades.FindAsync(id);
            return prioridad;
        }

        public async Task <bool> Delete(int id)
        {
            var prioridad = _contexto.Prioridades.Find(id);

            _contexto.Prioridades.Remove(prioridad);
            var deleted = await _contexto.SaveChangesAsync() > 0;
            return deleted;
        }
        //get all
        public async Task <List<Prioridades>> GetPrioridades(Expression<Func<Prioridades, bool>> criterio)
        {
           return await _contexto.Prioridades
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

        public async Task<Prioridades?> FindByIdAsync(int id)
        {
     

            return await Task.Run(() =>
            {
                return _contexto.Prioridades.FirstOrDefault(p => p.PrioridadId == id);
            });
        }

    }
}

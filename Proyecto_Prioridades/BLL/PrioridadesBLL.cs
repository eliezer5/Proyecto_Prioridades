using Proyecto_Prioridades.DAL;
using Proyecto_Prioridades.Models;

namespace Proyecto_Prioridades.BLL
{
    public class PrioridadesBLL
    {
        private readonly Contexto _contexto;
        public PrioridadesBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Save(Prioridades prioridad)
        {
            if (_contexto.Prioridades.Any(p => p.Descripción.ToLower() == prioridad.Descripción.ToLower()))
            {
                return false;
            }
            if (prioridad.PrioridadId == 0)
                _contexto.Prioridades.Add(prioridad);

            var saved = _contexto.SaveChanges() > 0;
            return saved;
        }


        public async Task<Prioridades?> FindAsync(int id)
        {
            var prioridad = await _contexto.Prioridades.FindAsync(id);
            return prioridad;
        }

        public async Task<string> FindDescription(int id)
        {
            var prioridad = await _contexto.Prioridades.FindAsync(id);


            return prioridad.Descripción;
        }

        public bool Delete(int id)
        {
            var prioridad = _contexto.Prioridades.Find(id);

            _contexto.Prioridades.Remove(prioridad);
            var deleted = _contexto.SaveChanges() > 0;
            return deleted;
        }
        //get all
        public List<Prioridades> GetTickets()
        {
            var prioridades = _contexto.Prioridades.ToList();
            return prioridades;
        }
    }
}

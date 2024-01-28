using Microsoft.EntityFrameworkCore;
using Proyecto_Prioridades.DAL;
using Proyecto_Prioridades.Models;
using System.Linq.Expressions;

namespace Proyecto_Prioridades.Services
{
    public class SistemasService
    {
        private readonly Contexto _contexto;

        public SistemasService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> validar(Sistemas sistema)
        {
            return await _contexto.Sistemas.AnyAsync(c =>
            (c.NombreSistema!.ToLower() == sistema.NombreSistema!.ToLower()
            || c.DescripcionSistema == sistema.DescripcionSistema));
        }
        public async Task<bool> Save(Sistemas sistema)
        {
            if (await validar(sistema))
                return false;
            if (sistema.SistemaId == 0)
                _contexto.Sistemas.Add(sistema);
            else
                _contexto.Update(sistema);

            var saved = await _contexto.SaveChangesAsync() > 0;
            return saved;
        }

        public async Task<Sistemas?> FindAsync(int id)
        {
            var sistema = await _contexto.Sistemas.FindAsync(id);
            return sistema;
        }

        public async Task<bool> Delete(int id)
        {
            var sistema = _contexto.Sistemas.Find(id);

            _contexto.Sistemas.Remove(sistema);
            var deleted = await _contexto.SaveChangesAsync() > 0;
            return deleted;
        }
        //get all
        public async Task<List<Sistemas>> GetClientes(Expression<Func<Sistemas, bool>> criterio)
        {
            return await _contexto.Sistemas
                 .AsNoTracking()
                 .Where(criterio)
                 .ToListAsync();
        }


        public async Task<Sistemas?> FindByIdAsync(int id)
        {


            return await Task.Run(() =>
            {
                return _contexto.Sistemas.FirstOrDefault(p => p.SistemaId == id);
            });
        }
    }
}

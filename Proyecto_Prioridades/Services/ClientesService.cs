using Microsoft.EntityFrameworkCore;
using Proyecto_Prioridades.DAL;
using Proyecto_Prioridades.Models;
using System.Linq.Expressions;

namespace Proyecto_Prioridades.Services
{
    public class ClientesService
    {

        private readonly Contexto _contexto;

        public ClientesService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> validar(Clientes cliente)
        {
            return await _contexto.Clientes.AnyAsync(c =>
            (c.Nombres!.ToLower() == cliente.Nombres!.ToLower()
            || c.Rnc == cliente.Rnc));
        }
        public async Task<bool> Save(Clientes cliente)
        {
            if (await validar(cliente))
                return false;
            if (cliente.ClienteId == 0)
                _contexto.Clientes.Add(cliente);
            else
                _contexto.Update(cliente);

            var saved = await _contexto.SaveChangesAsync() > 0;
            return saved;
        }

        public async Task<Clientes?> FindAsync(int id)
        {
            var cliente = await _contexto.Clientes.FindAsync(id);
            return cliente;
        }

        public async Task<bool> Delete(int id)
        {
            var cliente = _contexto.Clientes.Find(id);

            _contexto.Clientes.Remove(cliente);
            var deleted = await _contexto.SaveChangesAsync() > 0;
            return deleted;
        }
        //get all
        public async Task<List<Clientes>> GetClientes(Expression<Func<Clientes, bool>> criterio)
        {
            return await _contexto.Clientes
                 .AsNoTracking()
                 .Where(criterio)
                 .ToListAsync();
        }


        public async Task<Clientes?> FindByIdAsync(int id)
        {


            return await Task.Run(() =>
            {
                return _contexto.Clientes.FirstOrDefault(p => p.ClienteId == id);
            });
        }
    }
}

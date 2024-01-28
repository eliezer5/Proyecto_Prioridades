using Microsoft.EntityFrameworkCore;
using Proyecto_Prioridades.DAL;
using Proyecto_Prioridades.Models;
using System.Linq.Expressions;

namespace Proyecto_Prioridades.Services
{
    public class TicketsService
    {
        private readonly Contexto _contexto;

        public TicketsService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<bool> validar(Tickets ticket)
        {
            var prioridadId =  await _contexto.Prioridades.AnyAsync(c =>
            c.PrioridadId == ticket.PrioridadId);

            var clienteId = await _contexto.Clientes.AnyAsync(c =>
            c.ClienteID == ticket.ClienteId);

            var sistemaId = await _contexto.Sistemas.AnyAsync(c =>
            c.SistemaId == ticket.SistemaId);

            return prioridadId || clienteId || sistemaId;
        }
        public async Task<bool> Save(Tickets ticket)
        {
            if (!(await validar(ticket)))
                return false;
            if (ticket.SistemaId == 0)
                _contexto.Tickets.Add(ticket);
            else
                _contexto.Update(ticket);

            var saved = await _contexto.SaveChangesAsync() > 0;
            return saved;
        }

        public async Task<Tickets?> FindAsync(int id)
        {
            var ticket = await _contexto.Tickets.FindAsync(id);
            return ticket;
        }

        public async Task<bool> Delete(int id)
        {
            var ticket = _contexto.Tickets.Find(id);

            _contexto.Tickets.Remove(ticket);
            var deleted = await _contexto.SaveChangesAsync() > 0;
            return deleted;
        }
        //get all
        public async Task<List<Tickets>> GetClientes(Expression<Func<Tickets, bool>> criterio)
        {
            return await _contexto.Tickets
                 .AsNoTracking()
                 .Where(criterio)
                 .ToListAsync();
        }
        public async Task<Tickets?> FindByIdAsync(int id)
        {
            return await Task.Run(() =>
            {
                return _contexto.Tickets.FirstOrDefault(p => p.TicketId == id);
            });
        }
    }
}

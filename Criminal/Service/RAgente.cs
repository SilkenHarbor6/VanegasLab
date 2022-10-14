using Criminal.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criminal.Service
{
    public class RAgente
    {
        private bdcriminalContext db = new bdcriminalContext();
        public async Task<List<Agente>> GetAll()
        {
            using (var db = new bdcriminalContext())
            {
                return await db.Agentes.ToListAsync();
            }
        }
        public async Task<Response> Post(Agente item)
        {
            try
            {
                db.Agentes.Add(item);
                await db.SaveChangesAsync();
                return new Response { IsSuccess = true };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}

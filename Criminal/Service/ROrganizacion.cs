using Criminal.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criminal.Service
{
    public class ROrganizacion
    {
        private readonly bdcriminalContext db = new bdcriminalContext();
        public async Task<Response> Post(Organizacion item)
        {
            try
            {
                db.Organizacions.Add(item);
                await db.SaveChangesAsync();
                return new Response
                {
                    IsSuccess = true,
                };
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
        public async Task<List<Organizacion>> GetAll()
        {
            using (var db = new bdcriminalContext())
            {
                return await db.Organizacions.ToListAsync();
            }
        }
    }
}

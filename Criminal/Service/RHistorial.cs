using Criminal.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criminal.Service
{
    public class RHistorial
    {
        private bdcriminalContext db = new bdcriminalContext();
        public async Task<List<DelincuenteOrg>> GetAll(int DelincuenteID)
        {
            using (var db = new bdcriminalContext())
            {
                return await db.DelincuenteOrgs.Where(x => x.CodigoDelincuente == DelincuenteID).ToListAsync();
            }
        }
        public async Task<bool> post(DelincuenteOrg item)
        {
            try
            {
                db.DelincuenteOrgs.Add(item);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

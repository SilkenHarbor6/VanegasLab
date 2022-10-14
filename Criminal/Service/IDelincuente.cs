using Criminal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criminal.Service
{
    internal interface IDelincuente
    {
        Task<List<Delincuente>> GetAll();
        Task<Response> Post(Delincuente item);
        Task<Response> Put(Delincuente item);
        Task<Response> Delete(int id);
    }
}

using Criminal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criminal.Service
{
    internal interface IUsuario
    {
        Task<Response> Login(string username, string password);
        Task<Response> Register(Usuario item);
    }
}

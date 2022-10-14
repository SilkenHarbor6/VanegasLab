using Criminal.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criminal.Service
{
    internal class RUsuario : IUsuario
    {
        private readonly bdcriminalContext db = new bdcriminalContext();
        public async Task<Response> Login(string username, string password)
        {
            using(var db=new bdcriminalContext())
            {
                var login = await db.Usuarios.Where(x => x.UserEmail == username && x.Pass == Cypher.generarSHA1(password)).FirstOrDefaultAsync();
                if (login==null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "Las credenciales no coinciden"
                    };
                }
                return new Response
                {
                    IsSuccess = true,
                    Result = login
                };
            }
        }

        public async Task<Response> Register(Usuario item)
        {
            try
            {
                var check = await db.Usuarios.Where(x => x.UserEmail == item.UserEmail).FirstOrDefaultAsync();
                if (check!=null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message="Ya hay un usuario registrado con ese correo/usuario"
                    };
                }
                item.Pass = Cypher.generarSHA1(item.Pass);
                db.Usuarios.Add(item);
                var r = await db.SaveChangesAsync();
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
    }
}

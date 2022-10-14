using Criminal.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criminal.Service
{
    internal class RDelincuente : IDelincuente
    {
        private readonly bdcriminalContext db = new bdcriminalContext();
        public Task<Response> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Delincuente>> GetAll()
        {
            using(var db = new bdcriminalContext())
            {
                return await db.Delincuentes.ToListAsync();
            }
        }

        public async Task<Response> Post(Delincuente item)
        {
            try
            {
                db.Delincuentes.Add(item);
                await db.SaveChangesAsync();
                return new Response
                {
                    IsSuccess = true,
                    Result = item,
                    Message="Delincuente registrado"
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

        public async Task<Response> Put(Delincuente item)
        {
            try
            {
                var dbItem = await db.Delincuentes.FindAsync(item.CodigoDelincuente);
                if (dbItem == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "No se encontro ningun registro con ese id"
                    };
                }
                dbItem.Nombre = item.Nombre;
                dbItem.FechaNacimiento = item.FechaNacimiento;
                dbItem.RecompensaInicial = item.RecompensaInicial;
                dbItem.Aliases = item.Aliases;
                dbItem.PaisOrigen = item.PaisOrigen;
                dbItem.FechaPrimerDelito = item.FechaPrimerDelito;
                dbItem.TipoDelincuente = item.TipoDelincuente;
                dbItem.TipoEstafador = item.TipoEstafador;
                dbItem.Descripcion = item.Descripcion;
                dbItem.CantidadDelitos = item.CantidadDelitos;
                dbItem.IncrementoRecompensa = item.IncrementoRecompensa;
                //dbItem. NUMERO VICTIMAS
                dbItem.IncrementoRecompensa = item.IncrementoRecompensa;
                db.Entry(dbItem).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return new Response
                {
                    IsSuccess = true,
                    Result = dbItem
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

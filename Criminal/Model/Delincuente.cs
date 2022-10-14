using System;
using System.Collections.Generic;

namespace Criminal.Model
{
    public partial class Delincuente
    {
        public Delincuente()
        {
            DelincuenteOrgs = new HashSet<DelincuenteOrg>();
        }

        public int CodigoDelincuente { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string Aliases { get; set; } = null!;
        public decimal RecompensaInicial { get; set; }
        public string TipoDelincuente { get; set; } = null!;
        public string? PaisOrigen { get; set; }
        public DateTime FechaPrimerDelito { get; set; }
        public string? Especialidad { get; set; }
        public string? Descripcion { get; set; }
        public bool EsPeligroso { get; set; }
        public decimal IncrementoRecompensa { get; set; }
        public int CantidadDelitos { get; set; }
        public int? CodigoAgente { get; set; }
        public string? TipoEstafador { get; set; }
        public int? Victimas { get; set; }
        public virtual Agente? CodigoAgenteNavigation { get; set; }
        public virtual ICollection<DelincuenteOrg> DelincuenteOrgs { get; set; }
    }
}

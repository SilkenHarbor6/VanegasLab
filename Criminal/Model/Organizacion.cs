using System;
using System.Collections.Generic;

namespace Criminal.Model
{
    public partial class Organizacion
    {
        public Organizacion()
        {
            DelincuenteOrgs = new HashSet<DelincuenteOrg>();
        }

        public int CodigoOrg { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Objetivo { get; set; } = null!;
        public DateTime FechaCreacion { get; set; }
        public string Relaciones { get; set; } = null!;

        public virtual ICollection<DelincuenteOrg> DelincuenteOrgs { get; set; }
    }
}

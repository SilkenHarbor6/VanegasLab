using System;
using System.Collections.Generic;

namespace Criminal.Model
{
    public partial class DelincuenteOrg
    {
        public int Id { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public int CodigoDelincuente { get; set; }
        public int CodigoOrg { get; set; }

        public virtual Delincuente CodigoDelincuenteNavigation { get; set; } = null!;
        public virtual Organizacion CodigoOrgNavigation { get; set; } = null!;
    }
}

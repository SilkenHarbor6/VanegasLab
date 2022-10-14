using System;
using System.Collections.Generic;

namespace Criminal.Model
{
    public partial class Agente
    {
        public Agente()
        {
            Delincuentes = new HashSet<Delincuente>();
        }

        public int Nif { get; set; }
        public string Nombre { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public int NumeroAgente { get; set; }

        public virtual ICollection<Delincuente> Delincuentes { get; set; }
    }
}

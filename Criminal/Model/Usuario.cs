using System;
using System.Collections.Generic;

namespace Criminal.Model
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string Pass { get; set; } = null!;
    }
}

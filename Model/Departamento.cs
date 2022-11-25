using System;
using System.Collections.Generic;

namespace RegistroExpedientes.Model
{
    public partial class Departamento
    {
        public Departamento()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdDepartamento { get; set; }
        public string NombreDepartamento { get; set; } = null!;

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}

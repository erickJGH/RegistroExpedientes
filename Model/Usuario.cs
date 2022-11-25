using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RegistroExpedientes.Model
{
    public partial class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public int IdDepartamento { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public string Usuario1 { get; set; } = null!;
        public string Clave { get; set; } = null!;
        public string Privilegio { get; set; } = null!;
        public bool Estado { get; set; }
        public DateTime PersonCreatedDate { get; set; }
        public DateTime? PersonLastLogin { get; set; }

        public virtual Departamento IdDepartamentoNavigation { get; set; } = null!;
    }
}

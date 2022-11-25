using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RegistroExpedientes.Model
{
    public partial class Departamento
    {
        public Departamento()
        {
            Usuarios = new HashSet<Usuario>();
        }
        [Key]
        public int IdDepartamento { get; set; }
        [Required(ErrorMessage = "Favor introducir el departamento")]
        public string NombreDepartamento { get; set; } = null!;

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}

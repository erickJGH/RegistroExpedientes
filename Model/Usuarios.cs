using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RegistroExpedientes.Model
{
    public partial class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "Ingrese Id Departamento")]
        public int IdDepartamento { get; set; }
        [Required(ErrorMessage = "Ingrese Nombre")]
        public string Nombre { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese Apellido")]
        public string Apellido { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese Cedula")]
        public string Cedula { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese Usuario")]
        public string Usuario1 { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese Clave")]
        public string Clave { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese Privilegio")]
        public string Privilegio { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese Estado")]
        public bool Estado { get; set; }
        [Required(ErrorMessage = "Ingrese Fecha")]
        public DateTime PersonCreatedDate { get; set; }
        [Required(ErrorMessage = "Ingrese Fecha")]
        public DateTime? PersonLastLogin { get; set; }
        public virtual Departamentos IdDepartamentoNavigation { get; set; } = null!;
    }
}

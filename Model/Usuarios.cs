using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroExpedientes.Model
{
    public partial class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Departamento { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese Nombre")]
        public string Nombre { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese Apellido")]
        public string Apellido { get; set; } = null!;
        [RegularExpression(@"^\d{3}-\d{7}-\d{1}$")]
        [Required(ErrorMessage = "Favor de Ingresar cedula.Ejemplo 123-1234567-8")]
        public string Cedula { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese Usuario")]
        public string Usuario1 { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese Clave")]
        public string Clave { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese Privilegio")]
        public string Privilegio { get; set; } = null!;

        [Required(ErrorMessage = "Ingrese Estado")]
        public bool Estado { get; set; }

        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$")]
        [Phone(ErrorMessage = "Favor de ingresar correctamente el numero Telefonico.Ejemplo 123-123-1234")]
        [Required(ErrorMessage = "Favor introducir su telefono.")]
        public string Telefono { get; set; } = null!;


        public DateTime PersonCreatedDate { get; set; }
        public DateTime PersonLastLogin { get; set; }

    }
}

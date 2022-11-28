using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RegistroExpedientes.Model
{
    public partial class Expediente
    {
        [Key]
        public int IdExpediente { get; set; }
        [Required(ErrorMessage ="Ingrese Descripcion Expediente")]
        public string DescripcionExpediente { get; set; } = null!;
        [Required(ErrorMessage ="Ingrese Nombre Beneficiario")]
        public string NombreBeneficiario { get; set; } = null!;
        [Required(ErrorMessage ="Ingrese Apellido Beneficiario")]
        public string ApellidoBeneficiario { get; set; } = null!;
        [RegularExpression(@"^\d{3}-\d{7}-\d{1}$")]
        [Required(ErrorMessage ="Ingrese Cedula")]
        public string CedulaoRnc { get; set; } = null!;
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$")]
        [Phone(ErrorMessage = "Favor de ingresar correctamente el numero Celular.")]
        [Required(ErrorMessage ="Ingrese Telefono")]
        public string Telefono { get; set; } = null!;
        [Required(ErrorMessage ="Ingrese Tipo Expediente")]
        public string TipoExpediente { get; set; } = null!;
        [Required(ErrorMessage ="Ingrese Monto")]
        public decimal Monto { get; set; }
        [Required(ErrorMessage ="Ingrese Estado")]
        public string Estado { get; set; } = null!;
        [Required(ErrorMessage = "Ingrese Fecha")]
        public DateTime FechaDeEntrada { get; set; }
    }
}

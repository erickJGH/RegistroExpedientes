using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RegistroExpedientes.Model
{
    public partial class Expediente
    {
        [Key]
        public int IdExpediente { get; set; }
        public string DescripcionExpediente { get; set; } = null!;
        public string NombreBeneficiario { get; set; } = null!;
        public string ApellidoBeneficiario { get; set; } = null!;
        public string CedulaoRnc { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string TipoExpediente { get; set; } = null!;
        public decimal Monto { get; set; }
        public string Estado { get; set; } = null!;
        public DateTime FechaDeEntrada { get; set; }
    }
}

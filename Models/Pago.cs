using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIONFIT.Models
{
    [Table("t_pago")]
    public class Pago
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_pago")]
        public int Id {get;set;}

        public DateTime PaymenDate{ get; set; }

        public string? NombreTarjeta{ get; set; }

        public string? NumeroTarjeta{ get; set; }

        [NotMapped]
        public string? DueDateYYMM{ get; set; }

        [NotMapped]
        public string? cVV{ get; set; }

        public Decimal MontoTotal{ get; set; }
        
        public string? UserId{ get; set; }
            }
}
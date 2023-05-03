using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIONFIT.Models
{

    [Table("boleta")]
    public class Boleta
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_boleta")]
        public int Id {get;set;}


        public string? UserID { get; set; }

        public Producto? Producto { get; set; }

        public int Cantidad { get; set; }

        public Decimal Precio { get; set; }
    }
}
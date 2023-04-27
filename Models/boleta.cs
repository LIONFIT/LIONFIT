using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIONFIT.Models
{

    [Table("boleta")]
    public class boleta
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_boleta")]
        public int Id {get;set;}


        [Column ("fecha")]
        public String? Fecha {get;set;}

        
        [Column ("precio_total")]
        public Double? total {get;set;}

    }
}
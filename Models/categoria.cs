using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIONFIT.Models
{

    [Table("categoria")]
    public class Categoria
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_categoria")]
        public int Id {get;set;}


        [Column ("nombre_categoria")]
        public String? NomCategoria {get;set;}

        
        [Column ("descripcion")]
        public String? DesCategoria {get;set;}

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIONFIT.Models
{

    [Table("producto")]
    public class Producto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_producto")]
        public int Id {get;set;}


        [Column ("nombre_producto")]
        public String? NomProducto {get;set;}

        [Column ("precio_producto")]
        public Double? Precio {get;set;}

        
        [Column ("descripcion")]
        public String? DesProducto {get;set;}

        
        [Column ("imagen")]
        public String? Imagen {get;set;}
    }
}
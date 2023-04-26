using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIONFIT.Models
{

    [Table("registro_usuario")]
    public class registro_usuario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id {get;set;}


        [Column ("nombre")]
        public String? Nombre {get;set;}

        [Column ("apellido")]
        public String? Apellido {get;set;}

        
        [Column ("correo")]
        public String? CorreoElectronico {get;set;}

        
        [Column ("Fecha_nacimiento")]
        public String? Fecha_nacimiento {get;set;}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIONFIT.Models
{

    [table("t_registro_usuario")]
    public class t_registro_usuario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int id {get;set;}


        [Column ("nombre")]
        public String? Nombre {get;set;}

        [Column ("apellido")]
        public String? Apellido {get;set;}

        
        [Column ("correo")]
        public String? CorreoElectronico {get;set;}

        
        [Column ("Fecha_nacimiento")]
        public date? Fecha_nacimiento {get;set;}
    }
}
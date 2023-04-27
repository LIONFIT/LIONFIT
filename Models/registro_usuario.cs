using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIONFIT.Models
{

    [Table("registro_usuario")]
    public class Registro_usuario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id {get;set;}


        [Column ("nombre")]
        public String? Nombre {get;set;}

        [Column ("apellido_paterno")]
        public String? ApellidoPat {get;set;}
        
        [Column ("apellido_materno")]
        public String? ApellidoMat {get;set;}
        
        [Column ("correo")]
        public String? CorreoElectronico {get;set;}

        [Column ("password")]
        public String? password {get;set;}

        [Column ("celular")]
        public String? celular {get;set;}
    }
}
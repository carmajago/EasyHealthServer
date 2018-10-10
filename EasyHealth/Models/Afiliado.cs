using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyHealth.Models
{
    public class Afiliado
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string Cedula { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }


        [Required]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; }

        [JsonIgnore]
        public List<Cita> Citas { get; set; }


        public string Celular { get; set; }
    }
}
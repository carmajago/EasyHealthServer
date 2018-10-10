using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EasyHealth.Models
{
    public class Dia
    {
        [Key]
        public int id { get; set; }
        [Required]
        public DateTime Fecha { get; set; }

        public List<Hora> Horas { get; set; }
    }
}
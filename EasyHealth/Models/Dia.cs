using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("Medico")]
        public string MedicoFk { get; set; }

        public Medico Medico { get; set; }
    }
}
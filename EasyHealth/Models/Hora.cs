using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EasyHealth.Models
{
    public class Hora
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string HoraInicio { get; set; }
        [Required]
        public string HoraFin { get; set; }

        [ForeignKey("Dia")]
        public int DiaFk { get; set; }

        public Dia Dia { get; set; }
    }
}
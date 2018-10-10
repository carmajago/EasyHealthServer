using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EasyHealth.Models
{
    public class Cita
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public  DateTime FechaYHora { get; set; }
       
        [ForeignKey("ServicioPorMedico")]
        public int ServicioPorMedicoFk  { get; set; }

        [ForeignKey("Afiliado")]
        public string AfiliadoFk { get; set; }

        public Afiliado Afiliado { get; set; }
        public ServicioPorMedico ServicioPorMedico { get; set; }


    }
}
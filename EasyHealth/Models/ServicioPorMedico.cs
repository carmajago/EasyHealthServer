using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EasyHealth.Models
{
    public class ServicioPorMedico
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Medico")]
        public string MedicoFk { get; set; }

        [ForeignKey("Servicio")]
        public int ServicioFk { get; set; }

        [JsonIgnore]
        public Servicio Servicio { get; set; }
        [JsonIgnore]
        public Medico Medico { get; set; }
        [JsonIgnore]
        public List<Cita> Citas { get; set; }
    }

}
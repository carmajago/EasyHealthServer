using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EasyHealth.Models
{
    public class Servicio
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [ForeignKey("Categoria")]
        public int CategoriaFk { get; set; }

        public Categoria Categoria { get; set; }

    }
}
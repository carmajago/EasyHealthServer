using EasyHealth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EasyHealth.Controllers
{
    public class ServiciosPorCategoriaController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public IHttpActionResult GetServicios(int categoria)
        {
            var servicios = db.Servicios.Where(y=>y.CategoriaFk == categoria);

            return Ok(servicios);
        }
    }
}

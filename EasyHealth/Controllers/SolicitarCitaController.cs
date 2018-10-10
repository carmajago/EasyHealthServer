using EasyHealth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EasyHealth.Controllers
{
    public class SolicitarCitaController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public async Task<IHttpActionResult> PostCita()
        {
            return Ok();
        }
        
    }
}

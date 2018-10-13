using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using EasyHealth.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EasyHealth.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class AfiliadosController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Afiliados
        public IQueryable<Afiliado> GetAfiliadoes()
        {
            return db.Afiliados;
        }

        // GET: api/Afiliados/5
        [ResponseType(typeof(Afiliado))]
        public async Task<IHttpActionResult> GetAfiliado(string id)
        {
            Afiliado afiliado = await db.Afiliados.FindAsync(id);
            if (afiliado == null)
            {
                return NotFound();
            }

            return Ok(afiliado);
        }

        // PUT: api/Afiliados/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAfiliado(string id, Afiliado afiliado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != afiliado.Id)
            {
                return BadRequest();
            }

            db.Entry(afiliado).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AfiliadoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Afiliados
        /// <summary>
        /// Crea un afiliado y lo registra en la tabla Users
        /// </summary>
        /// <param name="afiliado"></param>
        /// <returns></returns>
        [ResponseType(typeof(Afiliado))]
        public async Task<IHttpActionResult> PostAfiliado(Afiliado afiliado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (AfiliadoExists(afiliado.Cedula))
            {
                return BadRequest("La cedula ya se encuetra registrada");
            }
            if (AfiliadoCorreoExists(afiliado.Correo))
            {
                return BadRequest("EL correo ya se encuetra registrado");
            }


            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                var UserManager = new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(db));


                var user = new ApplicationUser()
                {
                    Email = afiliado.Correo,
                    UserName = afiliado.Cedula,

                };
                
                ///Validar contraseña 

                var resultado = UserManager.Create(user, afiliado.Contrasena);
                var result1 =UserManager.AddToRole(user.Id, "Afiliado");
                //afiliado.contrasena = null;
                afiliado.Id = user.Id;
            }

            db.Afiliados.Add(afiliado);


            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AfiliadoExists(afiliado.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = afiliado.Id }, afiliado);
        }

        // DELETE: api/Afiliados/5
        [ResponseType(typeof(Afiliado))]
        public async Task<IHttpActionResult> DeleteAfiliado(string id)
        {
            Afiliado afiliado = await db.Afiliados.FindAsync(id);
            if (afiliado == null)
            {
                return NotFound();
            }

            db.Afiliados.Remove(afiliado);
            await db.SaveChangesAsync();

            return Ok(afiliado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AfiliadoExists(string cedula)
        {
            return db.Users.Count(e => e.UserName == cedula) > 0;
        }
        private bool AfiliadoCorreoExists(string correo)
        {
            return db.Users.Count(e => e.Email == correo) > 0;
        }
    }
}
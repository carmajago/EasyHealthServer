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
using System.Web.Http.Description;
using EasyHealth.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EasyHealth.Controllers
{
    public class MedicosController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Medicos
        public IQueryable<Medico> GetMedicos()
        {
            return db.Medicos;
        }

        // GET: api/Medicos/5
        [ResponseType(typeof(Medico))]
        public async Task<IHttpActionResult> GetMedico(string id)
        {
            Medico medico = await db.Medicos.FindAsync(id);
            if (medico == null)
            {
                return NotFound();
            }

            return Ok(medico);
        }

        // PUT: api/Medicos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMedico(string id, Medico medico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medico.Id)
            {
                return BadRequest();
            }

            db.Entry(medico).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicoExists(id))
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

        // POST: api/Medicos
        [ResponseType(typeof(Medico))]
        public async Task<IHttpActionResult> PostMedico(Medico medico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (MedicoCorreoExists(medico.Correo))
            {
                return BadRequest("El correo ya se encuetra registrado");
            }
            if (MedicoExists(medico.Cedula))
            {
                return BadRequest("La cedula ya se encuetra registrado");
            }

            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                var UserManager = new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(db));


                var user = new ApplicationUser()
                {
                    Email = medico.Correo,
                    UserName = medico.Correo, //Se utiliza el correo porque el médico puede se un afiliado
                };

                ///Validar contraseña 

                var resultado = UserManager.Create(user, medico.Contrasena);
                var result1 = UserManager.AddToRole(user.Id, "Medico");
                //afiliado.contrasena = null;
                medico.Id = user.Id;
            }

            db.Medicos.Add(medico);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MedicoExists(medico.Cedula))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = medico.Id }, medico);
        }

        // DELETE: api/Medicos/5
        [ResponseType(typeof(Medico))]
        public async Task<IHttpActionResult> DeleteMedico(string id)
        {
            Medico medico = await db.Medicos.FindAsync(id);
            if (medico == null)
            {
                return NotFound();
            }

            db.Medicos.Remove(medico);
            await db.SaveChangesAsync();

            return Ok(medico);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MedicoExists(string cedula)
        {
            return db.Medicos.Count(e => e.Cedula == cedula) > 0;
        }
        private bool MedicoCorreoExists(string correo)
        {
            return db.Medicos.Count(e => e.Correo == correo) > 0;
        }
    }
}
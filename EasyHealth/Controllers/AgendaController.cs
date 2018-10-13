using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EasyHealth.Models;

namespace EasyHealth.Controllers
{
    public class AgendaController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Agenda
        public IQueryable<Dia> GetDias()
        {
            return db.Dias.Include(xx=>xx.Horas);
        }

        // GET: api/Agenda/5
        [ResponseType(typeof(Dia))]
        public IHttpActionResult GetDia(int id)
        {
            Dia dia = db.Dias.Find(id);
            if (dia == null)
            {
                return NotFound();
            }

            return Ok(dia);
        }

        // PUT: api/Agenda/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDia(int id, Dia dia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dia.id)
            {
                return BadRequest();
            }

            db.Entry(dia).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiaExists(id))
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

        // POST: api/Agenda
        [ResponseType(typeof(Dia))]
        public IHttpActionResult PostDia(Dia dia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Dias.Add(dia);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dia.id }, dia);
        }

        // DELETE: api/Agenda/5
        [ResponseType(typeof(Dia))]
        public IHttpActionResult DeleteDia(int id)
        {
            Dia dia = db.Dias.Find(id);
            if (dia == null)
            {
                return NotFound();
            }

            db.Dias.Remove(dia);
            db.SaveChanges();

            return Ok(dia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DiaExists(int id)
        {
            return db.Dias.Count(e => e.id == id) > 0;
        }
    }
}
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
using MultiplexBookingWebAPI.Models;
using System.Web.Http.Cors;

namespace MultiplexBookingWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ShowController : ApiController
    {
        private MOVIEDBEntities db = new MOVIEDBEntities();

        // GET: api/Show
        public IQueryable<SHOW> GetSHOWs()
        {
            return db.SHOWs;
        }

        // GET: api/Show/5
        [ResponseType(typeof(SHOW))]
        public IHttpActionResult GetSHOW(int id)
        {
            SHOW sHOW = db.SHOWs.Find(id);
            if (sHOW == null)
            {
                return NotFound();
            }

            return Ok(sHOW);
        }

        // PUT: api/Show/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSHOW(int id, SHOW sHOW)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sHOW.ShowID)
            {
                return BadRequest();
            }

            db.Entry(sHOW).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SHOWExists(id))
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

        // POST: api/Show
        [ResponseType(typeof(SHOW))]
        public IHttpActionResult PostSHOW(SHOW sHOW)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SHOWs.Add(sHOW);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sHOW.ShowID }, sHOW);
        }

        // DELETE: api/Show/5
        [ResponseType(typeof(SHOW))]
        public IHttpActionResult DeleteSHOW(int id)
        {
            SHOW sHOW = db.SHOWs.Find(id);
            if (sHOW == null)
            {
                return NotFound();
            }

            db.SHOWs.Remove(sHOW);
            db.SaveChanges();

            return Ok(sHOW);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SHOWExists(int id)
        {
            return db.SHOWs.Count(e => e.ShowID == id) > 0;
        }
    }
}
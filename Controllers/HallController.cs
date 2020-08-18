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

namespace MultiplexBookingWebAPI.Controllers
{
    public class HallController : ApiController
    {
        private MOVIEDBEntities db = new MOVIEDBEntities();

        // GET: api/Hall
        public IQueryable<HALL> GetHALLs()
        {
            return db.HALLs;
        }

        // GET: api/Hall/5
        [ResponseType(typeof(HALL))]
        public IHttpActionResult GetHALL(int id)
        {
            HALL hALL = db.HALLs.Find(id);
            if (hALL == null)
            {
                return NotFound();
            }

            return Ok(hALL);
        }

        // PUT: api/Hall/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHALL(int id, HALL hALL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hALL.HallID)
            {
                return BadRequest();
            }

            db.Entry(hALL).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HALLExists(id))
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

        // POST: api/Hall
        [ResponseType(typeof(HALL))]
        public IHttpActionResult PostHALL(HALL hALL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HALLs.Add(hALL);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (HALLExists(hALL.HallID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = hALL.HallID }, hALL);
        }

        // DELETE: api/Hall/5
        [ResponseType(typeof(HALL))]
        public IHttpActionResult DeleteHALL(int id)
        {
            HALL hALL = db.HALLs.Find(id);
            if (hALL == null)
            {
                return NotFound();
            }

            db.HALLs.Remove(hALL);
            db.SaveChanges();

            return Ok(hALL);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HALLExists(int id)
        {
            return db.HALLs.Count(e => e.HallID == id) > 0;
        }
    }
}
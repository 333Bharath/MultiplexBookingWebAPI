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
    public class HallcapacityController : ApiController
    {
        private MOVIEDBEntities db = new MOVIEDBEntities();

        // GET: api/Hallcapacity
        public IQueryable<HALL_CAPACITY> GetHALL_CAPACITY()
        {
            return db.HALL_CAPACITY;
        }

        // GET: api/Hallcapacity/5
        [ResponseType(typeof(HALL_CAPACITY))]
        public IHttpActionResult GetHALL_CAPACITY(int id)
        {
            HALL_CAPACITY hALL_CAPACITY = db.HALL_CAPACITY.Find(id);
            if (hALL_CAPACITY == null)
            {
                return NotFound();
            }

            return Ok(hALL_CAPACITY);
        }

        // PUT: api/Hallcapacity/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHALL_CAPACITY(int id, HALL_CAPACITY hALL_CAPACITY)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hALL_CAPACITY.HallNo)
            {
                return BadRequest();
            }

            db.Entry(hALL_CAPACITY).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HALL_CAPACITYExists(id))
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

        // POST: api/Hallcapacity
        [ResponseType(typeof(HALL_CAPACITY))]
        public IHttpActionResult PostHALL_CAPACITY(HALL_CAPACITY hALL_CAPACITY)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HALL_CAPACITY.Add(hALL_CAPACITY);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (HALL_CAPACITYExists(hALL_CAPACITY.HallNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = hALL_CAPACITY.HallNo }, hALL_CAPACITY);
        }

        // DELETE: api/Hallcapacity/5
        [ResponseType(typeof(HALL_CAPACITY))]
        public IHttpActionResult DeleteHALL_CAPACITY(int id)
        {
            HALL_CAPACITY hALL_CAPACITY = db.HALL_CAPACITY.Find(id);
            if (hALL_CAPACITY == null)
            {
                return NotFound();
            }

            db.HALL_CAPACITY.Remove(hALL_CAPACITY);
            db.SaveChanges();

            return Ok(hALL_CAPACITY);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HALL_CAPACITYExists(int id)
        {
            return db.HALL_CAPACITY.Count(e => e.HallNo == id) > 0;
        }
    }
}
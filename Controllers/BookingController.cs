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
    public class BookingController : ApiController
    {
        private MOVIEDBEntities db = new MOVIEDBEntities();

        // GET: api/Booking
        public IQueryable<BOOKING> GetBOOKINGs()
        {
            return db.BOOKINGs;
        }

        // GET: api/Booking/5
        [ResponseType(typeof(BOOKING))]
        public IHttpActionResult GetBOOKING(int id)
        {
            BOOKING bOOKING = db.BOOKINGs.Find(id);
            if (bOOKING == null)
            {
                return NotFound();
            }

            return Ok(bOOKING);
        }

        // PUT: api/Booking/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBOOKING(int id, BOOKING bOOKING)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bOOKING.BookingID)
            {
                return BadRequest();
            }

            db.Entry(bOOKING).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BOOKINGExists(id))
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

        // POST: api/Booking
        [ResponseType(typeof(BOOKING))]
        public IHttpActionResult PostBOOKING(BOOKING bOOKING)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BOOKINGs.Add(bOOKING);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bOOKING.BookingID }, bOOKING);
        }

        // DELETE: api/Booking/5
        [ResponseType(typeof(BOOKING))]
        public IHttpActionResult DeleteBOOKING(int id)
        {
            BOOKING bOOKING = db.BOOKINGs.Find(id);
            if (bOOKING == null)
            {
                return NotFound();
            }

            db.BOOKINGs.Remove(bOOKING);
            db.SaveChanges();

            return Ok(bOOKING);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BOOKINGExists(int id)
        {
            return db.BOOKINGs.Count(e => e.BookingID == id) > 0;
        }
    }
}
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
    public class FeedbackController : ApiController
    {
        private MOVIEDBEntities db = new MOVIEDBEntities();

        // GET: api/Feedback
        public IQueryable<FEEDBACK> GetFEEDBACKs()
        {
            return db.FEEDBACKs;
        }

        // GET: api/Feedback/5
        [ResponseType(typeof(FEEDBACK))]
        public IHttpActionResult GetFEEDBACK(int id)
        {
            FEEDBACK fEEDBACK = db.FEEDBACKs.Find(id);
            if (fEEDBACK == null)
            {
                return NotFound();
            }

            return Ok(fEEDBACK);
        }

        // PUT: api/Feedback/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFEEDBACK(int id, FEEDBACK fEEDBACK)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fEEDBACK.FeedBackNo)
            {
                return BadRequest();
            }

            db.Entry(fEEDBACK).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FEEDBACKExists(id))
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

        // POST: api/Feedback
        [ResponseType(typeof(FEEDBACK))]
        public IHttpActionResult PostFEEDBACK(FEEDBACK fEEDBACK)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FEEDBACKs.Add(fEEDBACK);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fEEDBACK.FeedBackNo }, fEEDBACK);
        }

        // DELETE: api/Feedback/5
        [ResponseType(typeof(FEEDBACK))]
        public IHttpActionResult DeleteFEEDBACK(int id)
        {
            FEEDBACK fEEDBACK = db.FEEDBACKs.Find(id);
            if (fEEDBACK == null)
            {
                return NotFound();
            }

            db.FEEDBACKs.Remove(fEEDBACK);
            db.SaveChanges();

            return Ok(fEEDBACK);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FEEDBACKExists(int id)
        {
            return db.FEEDBACKs.Count(e => e.FeedBackNo == id) > 0;
        }
    }
}
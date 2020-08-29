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
using System.Web.UI.WebControls;

namespace MultiplexBookingWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MovieController : ApiController
    {
        private MOVIEDBEntities db = new MOVIEDBEntities();

        // GET: api/Movie
        public IQueryable<MOVIE> GetMOVIEs()
        {
            return db.MOVIEs;
        }

        // GET: api/Movie/5
        [ResponseType(typeof(MOVIE))]
        public IHttpActionResult GetMOVIE(int id)
        {
            MOVIE mOVIE = db.MOVIEs.Find(id);
            if (mOVIE == null)
            {
                return NotFound();
            }

            return Ok(mOVIE);
        }

        // PUT: api/Movie/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMOVIE(int id, MOVIE mOVIE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mOVIE.MovieID)
            {
                return BadRequest();
            }

            db.Entry(mOVIE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MOVIEExists(id))
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

        // POST: api/Movie
        [ResponseType(typeof(MOVIE))]
        public IHttpActionResult PostMOVIE(MOVIE mOVIE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MOVIEs.Add(mOVIE);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mOVIE.MovieID }, mOVIE);
        }

        // DELETE: api/Movie/5
        [ResponseType(typeof(MOVIE))]
        public IHttpActionResult DeleteMOVIE(int id)
        {
            MOVIE mOVIE = db.MOVIEs.Find(id);
            if (mOVIE == null)
            {
                return NotFound();
            }

            db.MOVIEs.Remove(mOVIE);
            db.SaveChanges();

            return Ok(mOVIE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MOVIEExists(int id)
        {
            return db.MOVIEs.Count(e => e.MovieID == id) > 0;
        }
    }
}
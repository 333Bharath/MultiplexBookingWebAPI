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
    public class MagazineController : ApiController
    {
        private MOVIEDBEntities db = new MOVIEDBEntities();

        // GET: api/Magazine
        public IQueryable<MAGAZINE> GetMAGAZINEs()
        {
            return db.MAGAZINEs;
        }

        // GET: api/Magazine/5
        [ResponseType(typeof(MAGAZINE))]
        public IHttpActionResult GetMAGAZINE(int id)
        {
            MAGAZINE mAGAZINE = db.MAGAZINEs.Find(id);
            if (mAGAZINE == null)
            {
                return NotFound();
            }

            return Ok(mAGAZINE);
        }

        // PUT: api/Magazine/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMAGAZINE(int id, MAGAZINE mAGAZINE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mAGAZINE.MagazineID)
            {
                return BadRequest();
            }

            db.Entry(mAGAZINE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MAGAZINEExists(id))
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

        // POST: api/Magazine
        [ResponseType(typeof(MAGAZINE))]
        public IHttpActionResult PostMAGAZINE(MAGAZINE mAGAZINE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MAGAZINEs.Add(mAGAZINE);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mAGAZINE.MagazineID }, mAGAZINE);
        }

        // DELETE: api/Magazine/5
        [ResponseType(typeof(MAGAZINE))]
        public IHttpActionResult DeleteMAGAZINE(int id)
        {
            MAGAZINE mAGAZINE = db.MAGAZINEs.Find(id);
            if (mAGAZINE == null)
            {
                return NotFound();
            }

            db.MAGAZINEs.Remove(mAGAZINE);
            db.SaveChanges();

            return Ok(mAGAZINE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MAGAZINEExists(int id)
        {
            return db.MAGAZINEs.Count(e => e.MagazineID == id) > 0;
        }
    }
}
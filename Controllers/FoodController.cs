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
    public class FoodController : ApiController
    {
        private MOVIEDBEntities db = new MOVIEDBEntities();

        // GET: api/Food
        public IQueryable<FOOD> GetFOODs()
        {
            return db.FOODs;
        }

        // GET: api/Food/5
        [ResponseType(typeof(FOOD))]
        public IHttpActionResult GetFOOD(int id)
        {
            FOOD fOOD = db.FOODs.Find(id);
            if (fOOD == null)
            {
                return NotFound();
            }

            return Ok(fOOD);
        }

        // PUT: api/Food/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFOOD(int id, FOOD fOOD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fOOD.FoodID)
            {
                return BadRequest();
            }

            db.Entry(fOOD).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FOODExists(id))
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

        // POST: api/Food
        [ResponseType(typeof(FOOD))]
        public IHttpActionResult PostFOOD(FOOD fOOD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FOODs.Add(fOOD);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fOOD.FoodID }, fOOD);
        }

        // DELETE: api/Food/5
        [ResponseType(typeof(FOOD))]
        public IHttpActionResult DeleteFOOD(int id)
        {
            FOOD fOOD = db.FOODs.Find(id);
            if (fOOD == null)
            {
                return NotFound();
            }

            db.FOODs.Remove(fOOD);
            db.SaveChanges();

            return Ok(fOOD);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FOODExists(int id)
        {
            return db.FOODs.Count(e => e.FoodID == id) > 0;
        }
    }
}
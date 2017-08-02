using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using JobPortal.Data;

namespace JobPortal.Api.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using JobPortal.Data;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Job>("Jobs");
    builder.EntitySet<Company>("Companies"); 
    builder.EntitySet<Location>("Locations"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class JobsController : ODataController
    {
        private JobDatabaseEntities db = new JobDatabaseEntities();

        // GET: odata/Jobs
        [EnableQuery]
        public IQueryable<Job> GetJobs()
        {
            return db.Jobs;
        }

        // GET: odata/Jobs(5)
        [EnableQuery]
        public SingleResult<Job> GetJob([FromODataUri] int key)
        {
            return SingleResult.Create(db.Jobs.Where(job => job.JobId == key));
        }

        // PUT: odata/Jobs(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Job> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Job job = db.Jobs.Find(key);
            if (job == null)
            {
                return NotFound();
            }

            patch.Put(job);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(job);
        }

        // POST: odata/Jobs
        public IHttpActionResult Post(Job job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Jobs.Add(job);
            db.SaveChanges();

            return Created(job);
        }

        // PATCH: odata/Jobs(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Job> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Job job = db.Jobs.Find(key);
            if (job == null)
            {
                return NotFound();
            }

            patch.Patch(job);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(job);
        }

        // DELETE: odata/Jobs(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Job job = db.Jobs.Find(key);
            if (job == null)
            {
                return NotFound();
            }

            db.Jobs.Remove(job);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Jobs(5)/Company
        [EnableQuery]
        public SingleResult<Company> GetCompany([FromODataUri] int key)
        {
            return SingleResult.Create(db.Jobs.Where(m => m.JobId == key).Select(m => m.Company));
        }

        // GET: odata/Jobs(5)/Location
        [EnableQuery]
        public SingleResult<Location> GetLocation([FromODataUri] int key)
        {
            return SingleResult.Create(db.Jobs.Where(m => m.JobId == key).Select(m => m.Location));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JobExists(int key)
        {
            return db.Jobs.Count(e => e.JobId == key) > 0;
        }
    }
}

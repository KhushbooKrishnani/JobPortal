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
    builder.EntitySet<Skill>("Skills");
    builder.EntitySet<User>("Users"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class SkillsController : ODataController
    {
        private JobDatabaseEntities db = new JobDatabaseEntities();

        // GET: odata/Skills
        [EnableQuery]
        public IQueryable<Skill> GetSkills()
        {
            return db.Skills;
        }

        // GET: odata/Skills(5)
        [EnableQuery]
        public SingleResult<Skill> GetSkill([FromODataUri] int key)
        {
            return SingleResult.Create(db.Skills.Where(skill => skill.SkillsId == key));
        }

        // PUT: odata/Skills(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Skill> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Skill skill = db.Skills.Find(key);
            if (skill == null)
            {
                return NotFound();
            }

            patch.Put(skill);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(skill);
        }

        // POST: odata/Skills
        public IHttpActionResult Post(Skill skill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Skills.Add(skill);
            db.SaveChanges();

            return Created(skill);
        }

        // PATCH: odata/Skills(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Skill> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Skill skill = db.Skills.Find(key);
            if (skill == null)
            {
                return NotFound();
            }

            patch.Patch(skill);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(skill);
        }

        // DELETE: odata/Skills(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Skill skill = db.Skills.Find(key);
            if (skill == null)
            {
                return NotFound();
            }

            db.Skills.Remove(skill);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Skills(5)/Users
        [EnableQuery]
        public IQueryable<User> GetUsers([FromODataUri] int key)
        {
            return db.Skills.Where(m => m.SkillsId == key).SelectMany(m => m.Users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SkillExists(int key)
        {
            return db.Skills.Count(e => e.SkillsId == key) > 0;
        }
    }
}

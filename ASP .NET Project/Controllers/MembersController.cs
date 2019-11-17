using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using ASP.NET_Project.Models;

namespace ASP.NET_Project.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MembersController : ApiController
    {
        private readonly MyDbContext _db = new MyDbContext();

        // GET: api/Members
        public IQueryable<Member> GetMembers()
        {
            return _db.Members;
        }

        // GET: api/Members/5
        [ResponseType(typeof(Member))]
        public async Task<IHttpActionResult> GetMember(long id)
        {
            Member member = await _db.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            return Ok(member);
        }

        // PUT: api/Members/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMember(long id, Member member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != member.Id)
            {
                return BadRequest();
            }

            _db.Entry(member).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(id))
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

        // POST: api/Members
        [ResponseType(typeof(Member))]
        public async Task<IHttpActionResult> PostMember(Member member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Members.Add(member);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = member.Id }, member);
        }

        // DELETE: api/Members/5
        [ResponseType(typeof(Member))]
        public async Task<IHttpActionResult> DeleteMember(long id)
        {
            Member member = await _db.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            _db.Members.Remove(member);
            await _db.SaveChangesAsync();

            return Ok(member);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MemberExists(long id)
        {
            return _db.Members.Count(e => e.Id == id) > 0;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using ASP.NET_Project.Models;

namespace ASP.NET_Project.Controllers
{
    public class MemberController : Controller
    {
        private readonly MyDbContext _databaseContext;
        public MemberController()
        {
            _databaseContext = new MyDbContext();
        }
        [HttpGet]
        public ActionResult List()
        {
            var result = new JsonResult()
            {
                Data = _databaseContext.Members.Where(mem => 
                    mem.Status != (int)Member.MemberStatus.Deleted).ToList(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
            return result;

        }

        [HttpPost]
        public ActionResult Store(Member member)
        {
            member.CreatedTimeMls = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            member.MemberId = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            member.Status = (int)Member.MemberStatus.Inactive;
            _databaseContext.Members.Add(member);
            _databaseContext.SaveChanges();
            return new JsonResult()
            {
                Data = member,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [HttpPut]
        public ActionResult UpdateProfile(long id, Member updateMember)
        {
            var memberToUpdate = _databaseContext.Members.SingleOrDefault(
                mem  => mem.MemberId == id && 
                        mem.Status != (int)Member.MemberStatus.Deleted);
            if (memberToUpdate == null)
            {
                Response.StatusCode = (int) HttpStatusCode.NotFound;
                return Json(new
                {
                    success = false,
                    message = "Member is not found"
                }, JsonRequestBehavior.AllowGet);
            }
            memberToUpdate.UpdatedTimeMls = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            memberToUpdate.FirstName = updateMember.FirstName;
            memberToUpdate.LastName = updateMember.LastName;
            memberToUpdate.Email = updateMember.Email;
            memberToUpdate.Address = updateMember.Address;
            memberToUpdate.Avatar = updateMember.Avatar;
            memberToUpdate.Birthday = updateMember.Birthday;
            memberToUpdate.Introduction = updateMember.Introduction;
            memberToUpdate.Phone = updateMember.Phone;
            memberToUpdate.Gender = updateMember.Gender;
            memberToUpdate.Token = updateMember.Token;
            memberToUpdate.SecretToken = updateMember.SecretToken;
            _databaseContext.SaveChanges();
            return new JsonResult()
            {
                Data = updateMember,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        //[HttpPut]
        //public ActionResult UpdatePassword(long id, Member updateMember)
        //{
        //    var memberToUpdate = _databaseContext.Members.SingleOrDefault(
        //        mem  => mem.MemberId == id && 
        //                mem.Status != (int)Member.MemberStatus.Deleted);
        //    if (memberToUpdate == null)
        //    {
        //        Response.StatusCode = (int) HttpStatusCode.NotFound;
        //        return Json(new
        //        {
        //            success = false,
        //            message = "Member is not found"
        //        }, JsonRequestBehavior.AllowGet);
        //    }
        //    memberToUpdate.UpdatedTimeMls = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        //    memberToUpdate.Password = updateMember.Password;
        //    _databaseContext.SaveChanges();
        //    return new JsonResult()
        //    {
        //        Data = updateMember,
        //        JsonRequestBehavior = JsonRequestBehavior.AllowGet
        //    };
        //}
        //[HttpPut]
        //public ActionResult UpdateToken(long id, Member updateMember)
        //{
        //    var memberToUpdate = _databaseContext.Members.SingleOrDefault(
        //        mem => mem.MemberId == id &&
        //               mem.Status != (int)Member.MemberStatus.Deleted);
        //    if (memberToUpdate == null)
        //    {
        //        Response.StatusCode = (int)HttpStatusCode.NotFound;
        //        return Json(new
        //        {
        //            success = false,
        //            message = "Member is not found"
        //        }, JsonRequestBehavior.AllowGet);
        //    }
        //    memberToUpdate.Token = updateMember.Token;
        //    memberToUpdate.SecretToken = updateMember.SecretToken;
        //    _databaseContext.SaveChanges();
        //    return new JsonResult()
        //    {
        //        Data = updateMember,
        //        JsonRequestBehavior = JsonRequestBehavior.AllowGet
        //    };
        //}

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            var memberToDelete = _databaseContext.Members.SingleOrDefault(
                mem => mem.MemberId == id && 
                       mem.Status != (int)Member.MemberStatus.Deleted);
            if (memberToDelete == null)
            {
                Response.StatusCode = (int) HttpStatusCode.NotFound;
                return Json(new
                {
                    success = false,
                    message = "Member is not found"
                }, JsonRequestBehavior.AllowGet);
            }

            memberToDelete.DeletedTimeMls = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            memberToDelete.Status = (int) Member.MemberStatus.Deleted;
            _databaseContext.SaveChanges();
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(new
            {
                success = true,
                message = "Member is deleted"
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP.NET_Project.Models;

namespace ASP.NET_Project.Controllers
{
    public class SongController : Controller
    {
        private readonly MyDbContext _databaseContext;
        
        public SongController()
        {
            _databaseContext = new MyDbContext();
        }
        [HttpGet]
        public ActionResult List()
        {
            var result = new JsonResult()
            {
                Data = _databaseContext.Songs.Where(s =>
                    s.Status != (int)Song.SongStatus.Deleted).ToList(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
            return result;

        }

        [HttpPost]
        public ActionResult Store(Song song)
        {
            song.CreatedTimeMls = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            song.SongId = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            song.Status = (int)Song.SongStatus.Active;
            _databaseContext.Songs.Add(song);
            _databaseContext.SaveChanges();
            return new JsonResult()
            {
                Data = song,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [HttpPut]
        public ActionResult UpdateSong(long id, Song updateSong)
        {
            var songToUpdate = _databaseContext.Songs.SingleOrDefault(
                s => s.SongId == id &&
                       s.Status != (int)Song.SongStatus.Deleted);
            if (songToUpdate == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json(new
                {
                    success = false,
                    message = "Song is not found"
                }, JsonRequestBehavior.AllowGet);
            }
            songToUpdate.UpdatedTimeMls = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            songToUpdate.Name = updateSong.Name;
            songToUpdate.Description = updateSong.Description;
            songToUpdate.Singer = updateSong.Singer;
            songToUpdate.Author = updateSong.Author;
            songToUpdate.Thumbnail = updateSong.Thumbnail;
            songToUpdate.Link = updateSong.Link;
            _databaseContext.SaveChanges();
            return new JsonResult()
            {
                Data = updateSong,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            var songToDelete = _databaseContext.Songs.SingleOrDefault(
                s => s.SongId == id &&
                       s.Status != (int)Song.SongStatus.Deleted);
            if (songToDelete == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json(new
                {
                    success = false,
                    message = "Song is not found"
                }, JsonRequestBehavior.AllowGet);
            }

            songToDelete.DeletedTimeMls = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            songToDelete.Status = (int)Song.SongStatus.Deleted;
            _databaseContext.SaveChanges();
            Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(new
            {
                success = true,
                message = "Song is deleted"
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
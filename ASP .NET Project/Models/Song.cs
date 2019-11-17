using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_Project.Models
{
    public class Song
    {
        public long Id { get; set; }
        public long SongId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Singer { get; set; }
        public string Author { get; set; }
        public string Thumbnail { get; set; }
        public string Link { get; set; }

        public long CreatedTimeMls { get; set; }
        public long UpdatedTimeMls { get; set; }
        public long DeletedTimeMls { get; set; }
        public long ExpiredTimeMls { get; set; }

        public int Status { get; set; }
        public enum SongStatus { Active = 1, Deleted = 0 }
    }
}
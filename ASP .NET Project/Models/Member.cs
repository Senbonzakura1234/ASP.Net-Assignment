using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_Project.Models
{
    public class Member
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public string Birthday { get; set; }
        public string Introduction { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }

        public string Token { get; set; }
        public string SecretToken { get; set; }

        public long MemberId { get; set; }
        public long Id { get; set; }

        public long CreatedTimeMls { get; set; }
        public long UpdatedTimeMls { get; set; }
        public long DeletedTimeMls { get; set; }
        public long ExpiredTimeMls { get; set; }

        public int Status { get; set; }
        public enum MemberStatus { Active = 1, Inactive = 0, Deleted = -1 }
    }
}

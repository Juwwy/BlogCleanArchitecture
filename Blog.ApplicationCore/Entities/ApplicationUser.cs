using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.ApplicationCore.Entities
{
    public class ApplicationUser : IdentityUser
    {
        
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string UserImgUrl { get; set; }
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset DateModified { get; set; } = DateTimeOffset.Now;
        public bool IsDeleted { get; set; }
        public ICollection<Article> Articles { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public string UserRole { get; set; }
    }
}

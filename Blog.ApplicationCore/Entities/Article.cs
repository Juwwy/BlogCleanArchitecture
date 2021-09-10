using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.ApplicationCore.Entities
{
    public class Article : AuditableEntity
    {
        
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public ApplicationUser Author { get; set; }
        public string AuthorId { get; set; }
        public Category Category { get; set; }
        public string CategoryId { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public int NumberOfComments { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.ApplicationCore.Entities
{
    public class Category : AuditableEntity
    {
        
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}

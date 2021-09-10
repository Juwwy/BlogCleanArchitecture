using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.ApplicationCore.Entities
{
    public class Comment : AuditableEntity
    {
        public string Content { get; set; }
        public ApplicationUser Commentator { get; set; }
        public string CommentatorId { get; set; }
        public Article Article { get; set; }
        public string ArticleId { get; set; }
        
    }
}

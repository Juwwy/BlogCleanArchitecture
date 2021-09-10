using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.ApplicationCore.DTOs
{
    public class AddCommentDTO
    {
        public string Content { get; set; }
        public string ArticleId { get; set; }
        public string CommentId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.ApplicationCore.DTOs
{
    public class CommentDTO
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string CommentatorName { get; set; }
        public string CommentatorImageUrl { get; set; }
        public string DateCreated { get; set; }

    }
}

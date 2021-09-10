using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.ApplicationCore.DTOs
{
    public class ArticleDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string Author { get; set; }
        public string AuthorId { get; set; }
        public string Category { get; set; }
        public string CategoryId { get; set; }
        public int NumberOfComments { get; set; }
    }
}

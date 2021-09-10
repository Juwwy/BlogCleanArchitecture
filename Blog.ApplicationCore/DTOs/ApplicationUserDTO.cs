using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.ApplicationCore.DTOs
{
    public class ApplicationUserDTO
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string UserImgUrl { get; set; }
        public string DateCreated { get; set; }
        public string UserRole { get; set; }


    }
}

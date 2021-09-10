using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Presentation.API.ViewModels
{
    public class CategoryViewModel
    {
        [Required(ErrorMessage ="Category name is required")]
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}

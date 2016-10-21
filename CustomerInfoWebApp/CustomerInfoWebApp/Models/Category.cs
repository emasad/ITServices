using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerInfoWebApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CatName { get; set; }
        [NotMapped]
        public SelectList CategoryList { get; set; }
        
    }
}
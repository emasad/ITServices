using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerInfoWebApp.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string RegionName { get; set; }
        [NotMapped]
        public SelectList RegionList { get; set; }

    }
}
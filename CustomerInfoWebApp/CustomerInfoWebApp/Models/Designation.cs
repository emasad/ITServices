using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerInfoWebApp.Models
{
    public class Designation
    {
        public int Id { get; set; }
        public string DesigName { get; set; }
        [NotMapped]
        public SelectList DesignaionList { get; set; }

    }
}
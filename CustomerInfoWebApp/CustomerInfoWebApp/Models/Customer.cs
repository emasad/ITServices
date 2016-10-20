using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerInfoWebApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [Index(IsUnique = true)]
        [MaxLength(20)]
        public string Code { get; set; }
        [Required]
        [DisplayName("Name")]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required]
        public int PostCode { get; set; }


        [Required]
        public string Telephone { get; set; }


        [Required]
        [Index(IsUnique = true)]
        [MaxLength(450)]
        //[Remote("IsEmailExist", "Registration", ErrorMessage = "Email Already Exist.")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        public string ContactPersonName { get; set; }

        [Required]
        public int ContactPersonPositionId { get; set; }

        [Required]
        public int RegionId { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
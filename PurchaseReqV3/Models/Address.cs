using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PurchaseReqV3.Models
{
    [Table("Address", Schema = "PurchaseReq")]
    public class Address : Base
    {
        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string Street { get; set; }

        public ICollection<Campus> Campuses { get; set; }
        public ICollection<Vendor> Vendors { get; set; }
    }
}
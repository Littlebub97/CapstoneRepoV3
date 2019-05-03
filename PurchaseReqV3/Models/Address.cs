using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PurchaseReqV3.Models
{
    [Table("Address", Schema = "PurchaseReq")]
    public class Address : Base
    {
        public string Country { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string Street { get; set; }

        public ICollection<Campus> Campuses { get; set; }
        public ICollection<Vendor> Vendors { get; set; }
    }
}
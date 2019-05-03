using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseReqV3.Models
{
    [Table("Vendor", Schema = "PurchaseReq")]
    public class Vendor : Base
    {
        [DataType(DataType.Text), MaxLength(50)]
        public string Name { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }

        public bool StateContract { get; set; }

        public int? AddressId { get; set; }
        public Address Address { get; set; }
    }
}

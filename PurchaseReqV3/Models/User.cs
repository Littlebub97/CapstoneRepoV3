using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PurchaseReqV3.Models
{
    [Table("User", Schema = "PurchaseReq")]
    public class User 
    {
        [DataType(DataType.Text), MaxLength(30)]
        public string F_name { get; set; }

        [DataType(DataType.Text), MaxLength(30)]
        public string L_name { get; set; }
      
        [DataType(DataType.Text), MaxLength(100)]
        public string Address { get; set; }
    }
}

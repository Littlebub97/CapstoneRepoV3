using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PurchaseReq.Models;

namespace PurchaseReq.Models
{
    [Table("JobRole", Schema = "PurchaseReq")]
    public class JobRole : Base
    {
        [DataType(DataType.Text), MaxLength(50)]
        public string Name { get; set; }

        public DateTime DateHired { get; set; }

        public DateTime? DateTerminated { get; set; }

        public int UserID { get; set; }

       // [ForeignKey(nameof(UserID))]
       // public User User { get; set; }
        //Inverse property to Employee
    }
}

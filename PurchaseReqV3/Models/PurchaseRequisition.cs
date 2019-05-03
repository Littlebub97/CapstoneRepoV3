using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseReqV3.Models
{
    [Table("PurchaseRequisition", Schema = "PurchaseReq")]
    public class PurchaseRequisition : Base
    { 
        public string UserId { get; set; }
        public User User { get; set; }

        public ICollection<Item> Items { get; set; }

        public DateTime Date { get; set; }

        //[DataType(DataType.Currency)]
        //public decimal CalculatedTotal { get; set; }

        [DataType(DataType.Text), MaxLength(500)]
        public string Justification { get; set; }

        public enum APPROVALSTATUS { Approved, Rejected, Cancelled, Shipped, CannotProcess, Delivered, Processing }

        public APPROVALSTATUS ApprovalStatus { get; set; }

        public User Approver { get; set; }

        //Multiple Approvers
    }

}

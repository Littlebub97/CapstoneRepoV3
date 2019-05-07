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

        public DateTime Date { get; set; }

        //[DataType(DataType.Currency)]
        //public decimal CalculatedTotal { get; set; }

        [DataType(DataType.Text), MaxLength(500)]
        public string Justification { get; set; }

        public ICollection<Item> Items { get; set; }

        public User Approver { get; set; }

        public int? BudgetId { get; set; }
        public Budget Budgets { get; set; }
        //Multiple Approvers
    }

}

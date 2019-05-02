using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseReqV3.Models
{
    [Table("Budget", Schema ="PurchaseReqV3")]
    public class Budget : Base
    {
        [DataType(DataType.Text), MaxLength(50)]
        public string Name { get; set; }

        public enum TYPE { Annual, NonExpiring, Grant  }
        
        public TYPE Type { get; set; }

        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        public enum STATUS{ Active, Suspended, Cancelled } 

        public STATUS Status { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateEnded { get; set; }

    }
}
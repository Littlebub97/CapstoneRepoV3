using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PurchaseReqV3.Models
{
    [Table("Item", Schema = "PurchaseReq")]
    public class Item : Base
    {
        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }

        [DataType(DataType.Text), MaxLength(500)]
        public string Description { get; set; }

        [DataType(DataType.Currency)]
        public decimal? ActualPrice { get; set; }

        //Competing item 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseReq.Models
{
    [Table("Division", Schema = "PurchaseReq")]
    public class Divsion : Base
    {
        [DataType(DataType.Text), MaxLength(50)]
        public string Name { get; set; }

        public User DivisionChair { get; set; }
        //Division chair
        //Division above divisions
        //Inverse property User supervisor int Id
    }
}
//
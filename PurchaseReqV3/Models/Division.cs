using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseReqV3.Models
{
    [Table("Division", Schema = "ApplicationDbContext")]
    public class Divsion : Base
    {
        [DataType(DataType.Text), MaxLength(50)]
        public string Name { get; set; }

        [ForeignKey(nameof(UserId))]
        public User DivisionChair { get; set; }
        
        public int UserId { get; set; }
        //Division chair
        //Division above divisions Dont worrry about it
        //Inverse property User supervisor int Id
    }
}
//
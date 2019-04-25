using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseReqV3.Models
{
    [Table("Division", Schema = "PurchaseReq")]
    public class Divsion : Base
    {
        [DataType(DataType.Text), MaxLength(50)]
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }

      //  [InverseProperty(nameof(Department.Divsion))]// 1 to M
       // public ICollection<Department> Departments { get; set; }
        //Budgets
        //public int? DivisionChairId { get; set; }
        //public User DivisionChair { get; set; }
        //Don't get confused by the division object
        
       // public int UserId { get; set; }
        //Division chair
        //Division above divisions Dont worrry about it
        //Inverse property User supervisor int Id
    }
}
//
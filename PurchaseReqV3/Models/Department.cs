using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseReq.Models
{
    [Table("Department", Schema = "PurchaseReq")]
    public class Department : Base
    {
        [DataType(DataType.Text), MaxLength(50)]
        public string Name { get; set; }

        public User DepartmentHead { get; set; }
        //Department head
    }
}

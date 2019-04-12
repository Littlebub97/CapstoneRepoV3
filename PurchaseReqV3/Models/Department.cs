using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseReqV3.Models
{
    [Table("Department", Schema = "PurchaseReqV3")]
    public class Department : Base
    {
        [DataType(DataType.Text), MaxLength(50)]
        public string Name { get; set; }

        public User DepartmentHead { get; set; }
        //Department head
    }
}

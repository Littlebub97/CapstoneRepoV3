using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseReqV3.Models
{
    [Table("Department", Schema = "PurchaseReqV3")]
    public class Department : Base
    {
        [DataType(DataType.Text), MaxLength(50)]
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }

        public User DepartmentHead { get; set; }
        //public int? DepartmentHeadId { get; set; }
        //public User DepartmentHead { get; set; }
        //public int? DivisionId { get; set; }

        //public Divsion Divsion { get; set; }

    }
}
//Division<----department
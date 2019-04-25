using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseReqV3.Models
{
    [Table("Campus", Schema = "PurchaseReqV3")]
    public class Campus : Base
    { 
        [StringLength(50)]
        public string Name { get; set; }

        //Consider changing the length
        //Consider making a model
        [StringLength(100)]
        public string Address { get; set; }

        //One college
        public int? CollegeId { get; set; }
        public College College { get; set; }
        //oof
        //Double oof
        //Triple oof
        //So many oofs

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseReqV3.Models
{
    [Table("College", Schema = "PurchaseReqV3")]
    public class College : Base
    {
        [DataType(DataType.Text),MaxLength(50)]
        public string Name { get; set; }
    }
}

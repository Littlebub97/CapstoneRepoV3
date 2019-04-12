﻿using System;
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

        public User DivisionChair { get; set; }
        //Division chair
        //Division above divisions
        //Inverse property User supervisor int Id
    }
}
//
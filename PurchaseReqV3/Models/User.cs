using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PurchaseReqV3.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;

namespace PurchaseReqV3.Models
{
    [Table("User", Schema = "PurchaseReq")]
    public class User : IdentityUser
    {


        [DataType(DataType.Text), MaxLength(30)]
        public string F_name { get; set; }

        [DataType(DataType.Text), MaxLength(30)]
        public string L_name { get; set; }
      
        [DataType(DataType.Text), MaxLength(100)]
        public string Address { get; set; }

        public bool Active { get; set; }

        public DateTime DateHired { get; set; }

        public DateTime? DateTerminated { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public Division Division { get; set; }

        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}

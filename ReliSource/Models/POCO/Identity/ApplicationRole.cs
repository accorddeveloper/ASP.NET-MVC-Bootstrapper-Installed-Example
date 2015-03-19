using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ReliSource.Models.DesignPattern.Interfaces;
using ReliSource.Models.POCO.IdentityCustomization;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ReliSource.Models.POCO.Identity {
    public class ApplicationRole : IdentityRole<long, ApplicationUserRole>, IDevUserRole {
        [ForeignKey("RoleID")]
        public virtual ICollection<RegisterCode> RegisterCodes { get; set; }

        //[Display(Name="Can be achieive by points.")]
        //public bool CanAchieveByPoints { get; set; }
        //[Display(Name = "Point Required")]
        //public float PointRequired { get; set; }

        [Display(Name = "Priority Level", Description = "Less is more.")]
        public byte PriorityLevel { get; set; }
    }
}
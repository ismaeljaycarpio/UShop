using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UShop.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; } //navigation property
        
        [Display(Name="Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name="Date of Birth")]
        public DateTime? BirthDate { get; set; }
    }
}
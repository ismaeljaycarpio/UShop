using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UShop.Models;

namespace UShop.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }

        [Required]
        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        //[Min18YearsIfAMember] //temp disable
        public DateTime? BirthDate { get; set; }
    }
}
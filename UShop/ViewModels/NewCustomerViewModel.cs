using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UShop.Entities;

namespace UShop.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; } //dont need other functionality of List class -- just iterate
        public Customer Customer { get; set; } //re-use entity
    }
}
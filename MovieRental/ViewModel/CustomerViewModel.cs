using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieRental.Models;

namespace MovieRental.ViewModel
{
    public class CustomerViewModel
    {
        public List<MembershipType> MembershipTypes { get; set; }

        public Customer Customer { get; set; }
    }
}
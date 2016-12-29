using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieRental.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string CustomerName { get; set; }

        public DateTime? DateOfBirth { get; set; } 

        public bool IsSubscribedtoNewsLetter { get; set; }

        // Navigation Property
        public MembershipType CustomerMembershipType { get; set; }

        public byte MembershipTypeId { get; set; }
    }
}
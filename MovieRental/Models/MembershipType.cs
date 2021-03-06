﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRental.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }

        public string Name { get; set; }
        public short SignupFee { get; set; }
        public byte DurationinMonths { get; set; }

        public byte DiscountRate { get; set; }

        public const int unknown = 0;
        public const int PayasyouGo = 1;
    }
}
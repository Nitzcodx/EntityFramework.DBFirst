using System;
using System.Collections.Generic;

#nullable disable

namespace EF.DBFirst.DataAccessLayer.Models
{
    public partial class Policy
    {
        public int PolicyId { get; set; }
        public string PolicyType { get; set; }
    }
}

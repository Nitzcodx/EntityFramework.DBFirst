using System;
using System.Collections.Generic;

#nullable disable

namespace EF.DBFirst.DataAccessLayer.Models
{
    public partial class PolicyStatus
    {
        public int ApprovalId { get; set; }
        public int QuoteId { get; set; }
        public int CustId { get; set; }
        public int BranchId { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }

        public virtual BranchDetail Branch { get; set; }
        public virtual Customer Cust { get; set; }
    }
}

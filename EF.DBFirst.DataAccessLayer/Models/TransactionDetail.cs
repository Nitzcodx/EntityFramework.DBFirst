using System;
using System.Collections.Generic;

#nullable disable

namespace EF.DBFirst.DataAccessLayer.Models
{
    public partial class TransactionDetail
    {
        public int TransactionId { get; set; }
        public int CustId { get; set; }
        public int QuoteId { get; set; }
        public DateTime TransactionDate { get; set; }
        public TimeSpan TransactionTime { get; set; }
        public decimal Amount { get; set; }

        public virtual Customer Cust { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace EF.DBFirst.DataAccessLayer.Models
{
    public partial class ChildCareerPolicy
    {
        public int QuoteId { get; set; }
        public int InsuredId { get; set; }
        public string BeneficiaryName { get; set; }
        public DateTime BeneficiaryDob { get; set; }
        public string PremiumMode { get; set; }
        public string RebateMode { get; set; }
        public decimal SumAssured { get; set; }
        public decimal Term { get; set; }
        public decimal PremiumAmount { get; set; }
        public decimal PercentageRebate { get; set; }
        public decimal PremiumModeBasedRebate { get; set; }
        public decimal TermEndBasedRebate { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string NomineeName { get; set; }
        public string NomineeRelation { get; set; }
        public int BranchId { get; set; }
        public int ClaimsTaken { get; set; }
        public int Status { get; set; }
        public string Comment { get; set; }

        public virtual BranchDetail Branch { get; set; }
        public virtual Customer Insured { get; set; }
    }
}

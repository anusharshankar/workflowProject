using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkflowProject.Models
{
    public class Policy
    {
        [Key]
        public int PolicyId { get; set; }
        [Display(Name ="Policy Title")]
        public string PTitle { get; set; }
        [Display(Name = "Policy Description")]
        public string PDescription { get; set; }
        [Display(Name = "Scope and Responsibilities")]
        public string PScope { get; set; }
        public Review Review { get; set; }
        public ICollection<Amendment> Amendments { get; set; }
        public ICollection<Procedure> Procedures { get; set; }

    }

    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string ApprovalAuthority { get; set; }
        public string AdvisoryCommittee { get; set; }
        public string Administrator { get; set; }
        [DataType(DataType.Date)]
        public DateTime NxtReviewDate { get; set; }
    }

    public class Amendment
    {
        [Key]
        public int AmendmentId { get; set; }
        public string OrigApprAuth { get; set; }
        [DataType(DataType.Date)]
        public DateTime ApprDate { get; set; }
        public string AmendAuth { get; set; }
        [DataType(DataType.Date)]
        public DateTime AmendDate { get; set; }
        public string Notes { get; set; }
    }
}

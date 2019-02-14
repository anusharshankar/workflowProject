using System.ComponentModel.DataAnnotations;

namespace WorkflowProject.Models
{
    public class Action
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Action Title")]
        public string ATitle { get; set; }
        [Display(Name = "Action Decription")]
        public string ADesc { get; set; }
        public Input Inputs { get; set; }
        public Output Outputs { get; set; }
        public string Departments { get; set; }
        public bool IsSRSAffected { get; set; }
        public Process Process { get; set; }
        public int ProcessId { get; set; }
    }
}
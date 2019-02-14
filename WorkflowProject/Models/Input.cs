using System.ComponentModel.DataAnnotations;

namespace WorkflowProject.Models
{
    public class Input
    {
        [Key]
        public int InputId { get; set; }
        public string InputTitle { get; set; }
        public string InputDesc { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace WorkflowProject.Models
{
    public class Output
    {
        [Key]
        public int OutputId { get; set; }
        public string OutputTitle { get; set; }
        public string OutputDesc { get; set; }
    }
}
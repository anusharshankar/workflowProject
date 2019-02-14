﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WorkflowProject.Models;

namespace WorkflowProject.Models
{
    public class Process
    {
        [Key]
        public int ProcessId { get; set; }
        [Display(Name = "Process Title")]
        public string ProcTitle { get; set; }
        [Display(Name = "Process Description")]
        public string ProcDesc { get; set; }
        public ICollection<Action> Actions { get; set; }
        public Procedure Procedure { get; set; }
        public int ProcedureId { get; set; }
    }
}

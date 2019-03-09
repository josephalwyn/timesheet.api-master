using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace timesheet.model
{
    public class Timesheeet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int? TimeSheetId { get; set; }
        
        public int? EmployeeId { get; set; }
        public int? TaskId { get; set; }
       public string Taskname { get; set; }
        public double? Sunday { get; set; }        
        public double? Monday { get; set; }
        public double? Tuesday { get; set; }
        public double? Wednesday { get; set; }
        public double? Thursday { get; set; }
        public double? Friday { get; set; }
        public double? Saturday { get; set; }
        public DateTime? CreatedDate { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee EmployeeDetails { get; set; }
        [ForeignKey("TaskId")]
        public virtual Task TaskDetails { get; set; }
    }
}

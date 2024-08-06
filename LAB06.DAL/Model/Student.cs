using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB06.DAL.Model
{
    [Table("Student")]
    public partial class Student
    {
        [Key]
        [StringLength(10)]
        public string StudentID { get; set; }

        [Required]
        [StringLength(255)]
        public string FullName { get; set; }

        public double AverageScore { get; set; }

        public int? FacultyID { get; set; }

        public int? MajorID { get; set; }

        [StringLength(255)]
        public string Avatar { get; set; }

        public virtual Faculty Faculty { get; set; }

        public virtual Major Major { get; set; }
    }
}

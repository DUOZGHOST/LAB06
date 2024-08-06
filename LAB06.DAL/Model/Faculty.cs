using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB06.DAL.Model
{
    [Table("Faculty")]
    public partial class Faculty
    {
        public Faculty()
        {
            Majors = new HashSet<Major>();
            Students = new HashSet<Student>();
        }

        [Key]
        public int FacultyID { get; set; }

        [Required]
        [StringLength(255)]
        public string FacultyName { get; set; }

        public virtual ICollection<Major> Majors { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}

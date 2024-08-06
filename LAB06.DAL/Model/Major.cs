using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB06.DAL.Model
{
    [Table("Major")]
    public partial class Major
    {
        public Major()
        {
            Students = new HashSet<Student>();
        }

        public int FacultyID { get; set; }

        [Key]
        public int MajorID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public virtual Faculty Faculty { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}

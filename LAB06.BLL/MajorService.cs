using LAB06.DAL;
using LAB06.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB06.BLL
{
    public class MajorService
    {
        public List<Major> GetAllByFaculty(int facultyId)
        {
            StudentModel context = new StudentModel();
            return context.Majors.Where(p => p.FacultyID == facultyId).ToList();
        }
    }
}

using LAB06.BLL;
using LAB06.DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB06.GUI
{
    public partial class frmDKCN : Form
    {
        public frmDKCN()
        {
            InitializeComponent();
        }

        private readonly StudentService studentService = new StudentService();
        private readonly FacultyService facultyService = new FacultyService();
        private readonly MajorService majorService = new MajorService();

        private void frmDKCN_Load(object sender, EventArgs e)
        {
            try
            {
                var listFacultys = facultyService.GetAll();
                FillFacultyCombobox(listFacultys);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillFacultyCombobox(List<Faculty> listFacultys)
        {
            this.cmbFaculty.DataSource = listFacultys;
            this.cmbFaculty.DisplayMember = "FacultyName";
            this.cmbFaculty.ValueMember = "FacultyID";

        }
        private void FillMajorCombobox(List<Major> listMajors)
        {
            this.cmbMajor.DataSource = listMajors;
            this.cmbMajor.DisplayMember = "Name";
            this.cmbMajor.ValueMember = "MajorID";

        }
        private void BindGrid(List<Student> listStudents)
        {
            dgvStudent.Rows.Clear();
            foreach (var item in listStudents)
            {
                int index = dgvStudent.Rows.Add();
                dgvStudent.Rows[index].Cells[1].Value = item.StudentID;
                dgvStudent.Rows[index].Cells[2].Value = item.FullName;
                if (item.Faculty != null)
                {
                    dgvStudent.Rows[index].Cells[3].Value = item.Faculty.FacultyName;
                    dgvStudent.Rows[index].Cells[4].Value = item.AverageScore + "";

                }
                if (item.Major != null)
                {
                    dgvStudent.Rows[index].Cells[5].Value = item.Major.Name + "";

                }

            }
        }
        private void cmbFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            Faculty selectedFaculty = cmbFaculty.SelectedItem as Faculty;
            if (selectedFaculty != null)
            {
                var listMajor = majorService.GetAllByFaculty(selectedFaculty.FacultyID);
                FillMajorCombobox(listMajor);
                var listStudents = studentService.GetAllHasNoMajor(selectedFaculty.FacultyID);
                BindGrid(listStudents);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                StudentModel studentModel = new StudentModel();
                Major selectedFacultyObj = studentModel.Majors.FirstOrDefault(f => f.Name == cmbMajor.Text);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

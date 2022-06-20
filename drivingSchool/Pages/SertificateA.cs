using drivingSchool.AppData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace drivingSchool.Pages
{
    public partial class SertificateA : Form
    {
        DrivingSchoolEntities_ db = new DrivingSchoolEntities_();
        int studentID = 0, Status = 0, Category = 0, StudentID;

        private void dgvSert_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Status == 0)
            {
                var student = db.student.Where(p => p.isDeleted == false).ToList();
                int studentID = 0;
                foreach (var elem in student)
                {
                    if (elem.FIO == textBox1.Text)
                        studentID = elem.id;
                }

                var plan = db.academicPlan.Where(p => p.isDeleted == false).ToList();
                int planID = 0;
                foreach (var elem in plan)
                {
                    if (elem.subject.subjectName == (string)dgvSert.CurrentRow.Cells[0].Value)
                        planID = elem.id;
                }
                //var planID = db.academicPlan.Where(p => p.subject.subjectName == (string)dgvSert.CurrentRow.Cells[0].Value).FirstOrDefault().id;
                certificate certificate = new certificate
                {
                    idStudent = studentID,
                    idPlan = planID,
                    grade = Convert.ToInt32(dgvSert.CurrentRow.Cells[1].Value),
                    isDeleted = false
                };
                db.certificate.Add(certificate);
                db.SaveChanges();
            }
        }

        private void dgvSert_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
           
            
        }



        public SertificateA(int ID, int status, int cat)
        {
            InitializeComponent();
            dgvSert.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSert.AllowUserToAddRows = false;
            studentID = ID;
            Status = status; //статус операции: 0 - добавление, 1 - редактирование
            Category = cat;
            if (Status == 1)
            {
                var student = db.student.Where(p => p.id == ID && p.isDeleted == false).FirstOrDefault();
                textBox1.Text = student.FIO;

                var sub = from certificate in db.certificate
                          join plan in db.academicPlan
                          on certificate.idPlan equals plan.id
                          join subject in db.subject
                          on plan.idSubject equals subject.id
                          where certificate.isDeleted == false && plan.idCategory == Category
                          select new
                          {
                              id = certificate.id,
                              Дисциплина = subject.subjectName,
                              Оценка = certificate.grade
                          };
                dgvSert.DataSource = sub.ToList();
                dgvSert.Columns[0].Visible = false;
                dgvSert.Columns[1].Visible = false;
                dgvSert.Columns[2].Visible = false;
            }
            else
            {
                var student = db.student.Where(p => p.id == studentID && p.isDeleted == false).FirstOrDefault();
                textBox1.Text = student.FIO;
                
                var sub = from academicPlan in db.academicPlan
                          join subject in db.subject
                          on academicPlan.idSubject equals subject.id
                          join category in db.category
                          on academicPlan.idCategory equals category.id
                          where academicPlan.isDeleted == false && academicPlan.idCategory == Category
                          select subject.subjectName;

                foreach (string s in sub)
                    dgvSert.Rows.Add(s);

            }
        }


    }
}

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
    public partial class AcademicPlanAddEdit : Form
    {
        DrivingSchoolEntities_ db = new DrivingSchoolEntities_();
        int planID, Status = 0, Category = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            if (Status == 1)
            {
                try
                {
                    int idCat = 0;
                    if (Category == 1) { idCat = 1; }
                    else if (Category == 2) { idCat = 2; }
                    else if (Category == 3) { idCat = 3; }
                    else if (Category == 4) { idCat = 4; }
                    else { idCat = 5; }
                    var subject = db.subject.Where(p => p.isDeleted == false && p.subjectName == comboBox1.Text).FirstOrDefault();
                    int subjectID = subject.id;
                    var result = db.academicPlan.Where(p => p.id == planID).FirstOrDefault();
                    result.idSubject = subjectID;
                    result.idCategory = idCat;
                    result.hours = Convert.ToInt32(textBox1.Text);
                    db.SaveChanges();
                    this.DialogResult = DialogResult.OK;
                }
                catch
                {
                    MessageBox.Show("Возникло исключение. Проверьте введенные данные", "Ошибка", MessageBoxButtons.OK);
                }
            }
            else
            {
                try
                {
                    int idCat = 0;
                    if (Category == 1) { idCat = 1; }
                    else if (Category == 2) { idCat = 2; }
                    else if (Category == 3) { idCat = 3; }
                    else if (Category == 4) { idCat = 4; }
                    else { idCat = 5; }
                    var subject = db.subject.Where(p => p.isDeleted == false).ToList();
                    int subjectID = 0;
                    foreach (var elem in subject)
                    {
                        if (elem.subjectName == comboBox1.Text)
                            subjectID = elem.id;
                    }
                    academicPlan academicPlan = new academicPlan
                    {
                        idCategory = idCat,
                        idSubject = subjectID,
                        hours = Convert.ToInt32(textBox1.Text),
                        isDeleted = false
                    };
                    db.academicPlan.Add(academicPlan);
                    db.SaveChanges();
                    this.DialogResult = DialogResult.OK;
                }
                catch
                {
                    MessageBox.Show("Возникло исключение. Проверьте введенные данные", "Ошибка", MessageBoxButtons.OK);
                }
            }
        }

        public AcademicPlanAddEdit(int ID, int status, int category)
        {
            InitializeComponent();
            planID = ID; //id плана
            Status = status; //статус операции: 0 - добавление, 1 - редактирование
            Category = category;

            if (Status == 1)
            {
                var result = db.academicPlan.Where(g => g.id == ID && g.isDeleted == false).FirstOrDefault();
                //Вывод названий дисциплин в comboBox
                int idSub = result.idSubject;
                comboBox1.DataSource = db.subject.Where(p => p.isDeleted == false && p.id == idSub).ToList();
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "subjectName";

                textBox1.Text = Convert.ToString(result.hours);
            }
            else
            {
                //Вывод названий дисциплин в comboBox
                comboBox1.DataSource = db.subject.Where(p => p.isDeleted == false).ToList();
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "subjectName";
            }
        }
    }
}

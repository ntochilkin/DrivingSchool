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
    public partial class SubjictAddEdit : Form
    {
        DrivingSchoolEntities_ db = new DrivingSchoolEntities_();
        int subID, Status = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            if (Status == 1)
            {
                try
                {
                    var result = db.subject.Where(p => p.id == subID).FirstOrDefault();
                    result.subjectName = textBox1.Text;
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
                    subject subject = new subject
                    {
                        subjectName = textBox1.Text,
                        isDeleted = false
                    };
                    db.subject.Add(subject);
                    db.SaveChanges();
                    this.DialogResult = DialogResult.OK;
                }
                catch
                {
                    MessageBox.Show("Возникло исключение. Проверьте введенные данные", "Ошибка", MessageBoxButtons.OK);
                }
            }
        }

        public SubjictAddEdit(int ID, int status)
        {
            InitializeComponent();
            subID = ID; //id плана
            Status = status; //статус операции: 0 - добавление, 1 - редактирование

            if (Status == 1)
            {
                var result = db.subject.Where(g => g.id == ID && g.isDeleted == false).FirstOrDefault();
                textBox1.Text = Convert.ToString(result.subjectName);
            }
        }
    }
}

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
    public partial class StudentAddEdit : Form
    {
        DrivingSchoolEntities_ db = new DrivingSchoolEntities_();
        int studentID = 0, Status = 0, Category = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            int idCat = 0;
            if (Status == 1)
            {
                try
                {
                    var result = db.student.Where(g => g.id == studentID && g.isDeleted == false).FirstOrDefault();
                    result.FIO = textBox1.Text;
                    result.bDay = dateTimePicker1.Value;
                    result.passport = textBox2.Text;
                    result.medicalCertificate = textBox3.Text;
                    result.phone = textBox4.Text;
                    result.sex = comboBox1.Text;
                    result.adress = textBox5.Text;
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
                    string p = "";
                    if (comboBox1.SelectedIndex == 0)
                    {
                        p = "мужской";
                    }
                    else
                    {
                        p = "женский";
                    }
                    student s = new student
                    {
                        FIO = textBox1.Text,
                        bDay = dateTimePicker1.Value,
                        sex = p,
                        passport = textBox2.Text,
                        medicalCertificate = textBox3.Text,
                        phone = textBox4.Text,
                        adress = textBox5.Text,
                        isDeleted = false
                    };
                    db.student.Add(s);
                    db.SaveChanges();
                    this.DialogResult = DialogResult.OK;
            }
                catch
            {
                MessageBox.Show("Возникло исключение. Проверьте введенные данные", "Ошибка", MessageBoxButtons.OK);
            }
        }
        }

        public StudentAddEdit(int ID, int status, int category)
        {
            InitializeComponent();
            studentID = ID;
            Status = status; //статус операции: 0 - добавление, 1 - редактирование
            Category = category;
            if (Status == 1)
            {
                var result = db.student.Where(g => g.id == ID && g.isDeleted == false).FirstOrDefault();
                textBox1.Text = result.FIO;
                dateTimePicker1.Value = result.bDay;
                textBox2.Text = result.passport;
                textBox3.Text = result.medicalCertificate;
                textBox4.Text = result.phone;
                comboBox1.Text = result.sex;
                textBox5.Text = result.adress;
            }
        }
    }
}

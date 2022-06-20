using drivingSchool.AppData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace drivingSchool.Pages
{
    public partial class StudentA : Form
    {
        DrivingSchoolEntities_ db = new DrivingSchoolEntities_();
        int Category = 0;
        public StudentA(int category)
        {
            InitializeComponent();
            dgvStudent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudent.AllowUserToAddRows = false;
            Category = category;
            if (Category == 1)
            {
                comboBox1.DataSource = db.group.Where(p => p.isDeleted == false && p.idCategory == Category).ToList();
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "name";
            }
            else if (Category == 2)
            {
                comboBox1.DataSource = db.group.Where(p => p.isDeleted == false && p.idCategory == Category).ToList();
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "name";
            }
            else if (Category == 3)
            {
                comboBox1.DataSource = db.group.Where(p => p.isDeleted == false && p.idCategory == Category).ToList();
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "name";
            }
            else if (Category == 4)
            {
                comboBox1.DataSource = db.group.Where(p => p.isDeleted == false && p.idCategory == Category).ToList();
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "name";
            }
            else
            {
                comboBox1.DataSource = db.group.Where(p => p.isDeleted == false && p.idCategory == Category).ToList();
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "name";
            }
            studentOut();
        }
        public void studentOut()
        {
            var result = from student in db.student                         
                         where student.isDeleted == false
                         select new
                         {
                             id = student.id,
                             ФИО = student.FIO,
                             Дата_рождения = student.bDay,
                             Телефон = student.phone,
                             Паспорт = student.passport,
                             Адрес = student.adress,
                             Мед_сертификат = student.medicalCertificate
                         };
            dgvStudent.DataSource = result.ToList();
            dgvStudent.Columns[0].Visible = false;
        }
        private void добавитьСтудентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentAddEdit studentAddEdit = new StudentAddEdit(0, 0, Category);
            if (studentAddEdit.ShowDialog() == DialogResult.OK)
            {
                var result = from student in db.student
                                 
                                 where student.isDeleted == false 
                                 select new
                                 {
                                     id = student.id,
                                     ФИО = student.FIO,
                                     Дата_рождения = student.bDay,
                                     Телефон = student.phone,
                                     Паспорт = student.passport,
                                     Адрес = student.adress,
                                     Мед_сертификат = student.medicalCertificate
                                 };
                    dgvStudent.DataSource = result.ToList();
                    dgvStudent.Columns[0].Visible = false;
                
            }
        }

        private void редактироватьКурсантаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentAddEdit studentAddEdit = new StudentAddEdit(Convert.ToInt32(dgvStudent.CurrentRow.Cells[0].Value), 1, Category);
            if (studentAddEdit.ShowDialog() == DialogResult.OK)
            {
                studentOut();
            }
        }

        private void удалитьКурсантаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                student student = db.student.Find(dgvStudent.CurrentRow.Cells[0].Value);
                if (MessageBox.Show("Вы уверенны что хотите удалить?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    student.isDeleted = true;
                    db.SaveChanges();
                    studentOut();
                    MessageBox.Show("Данные успешно удалены", "Удаление", MessageBoxButtons.OK);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void СертификатtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            SertificateA sertificate = new SertificateA(Convert.ToInt32(dgvStudent.CurrentRow.Cells[0].Value), 0, Category);
            if (sertificate.ShowDialog() == DialogResult.OK)
            {
                studentOut();
            }
        }

        private void ПросмотрtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SertificateA sertificate = new SertificateA(Convert.ToInt32(dgvStudent.CurrentRow.Cells[0].Value), 1, Category);
            if (sertificate.ShowDialog() == DialogResult.OK)
            {
                studentOut();
            }
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            if (Category == 1) {
                var result = from student in db.student                             
                             where student.isDeleted == false && student.FIO.StartsWith(textSearch.Text)
                             select new
                             {
                                 id = student.id,
                                 ФИО = student.FIO,
                                 Дата_рождения = student.bDay,
                                 Телефон = student.phone,
                                 Паспорт = student.passport,
                                 Адрес = student.adress,
                                 Мед_сертификат = student.medicalCertificate
                             };
                dgvStudent.DataSource = result.ToList();
                dgvStudent.Columns[0].Visible = false;
            }
            else if (Category == 2) {
                var result = from student in db.student
                             where student.isDeleted == false && student.FIO.StartsWith(textSearch.Text)
                             select new
                             {
                                 id = student.id,
                                 ФИО = student.FIO,
                                 Дата_рождения = student.bDay,
                                 Телефон = student.phone,
                                 Паспорт = student.passport,
                                 Адрес = student.adress,
                                 Мед_сертификат = student.medicalCertificate
                             };
                dgvStudent.DataSource = result.ToList();
                dgvStudent.Columns[0].Visible = false;
            }
            else if (Category == 3) { 
                    var result = from student in db.student
                                 where student.isDeleted == false && student.FIO.StartsWith(textSearch.Text)
                                 select new
                                 {
                                     id = student.id,
                                     ФИО = student.FIO,
                                     Дата_рождения = student.bDay,
                                     Телефон = student.phone,
                                     Паспорт = student.passport,
                                     Адрес = student.adress,
                                     Мед_сертификат = student.medicalCertificate
                                 };
                dgvStudent.DataSource = result.ToList();
                dgvStudent.Columns[0].Visible = false;
            }
            else if (Category == 4) {
                var result = from student in db.student
                             where student.isDeleted == false && student.FIO.StartsWith(textSearch.Text)
                             select new
                             {
                                 id = student.id,
                                 ФИО = student.FIO,
                                 Дата_рождения = student.bDay,
                                 Телефон = student.phone,
                                 Паспорт = student.passport,
                                 Адрес = student.adress,
                                 Мед_сертификат = student.medicalCertificate
                             };
                dgvStudent.DataSource = result.ToList();
                dgvStudent.Columns[0].Visible = false;
            }
            else {
                var result = from student in db.student
                             where student.isDeleted == false && student.FIO.StartsWith(textSearch.Text)
                             select new
                             {
                                 id = student.id,
                                 ФИО = student.FIO,
                                 Дата_рождения = student.bDay,
                                 Телефон = student.phone,
                                 Паспорт = student.passport,
                                 Адрес = student.adress,
                                 Мед_сертификат = student.medicalCertificate
                             };
                dgvStudent.DataSource = result.ToList();
                dgvStudent.Columns[0].Visible = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Category == 1)
            {
                var result = from contract in db.contract
                             join student in db.student
                             on contract.idStudent equals student.id
                             join @group in db.@group
                             on contract.idGroup equals @group.id
                             where contract.isDeleted == false && @group.idCategory == 1 && @group.name == comboBox1.Text
                             select new
                             {
                                 id = student.id,
                                 ФИО = student.FIO,
                                 Дата_рождения = student.bDay,
                                 Телефон = student.phone,
                                 Паспорт = student.passport,
                                 Адрес = student.adress,
                                 Мед_сертификат = student.medicalCertificate
                             };
                dgvStudent.DataSource = result.ToList();
                dgvStudent.Columns[0].Visible = false;
            }
            else if (Category == 2)
            {
                var result = from contract in db.contract
                             join student in db.student
                             on contract.idStudent equals student.id
                             join @group in db.@group
                             on contract.idGroup equals @group.id
                             where contract.isDeleted == false && @group.idCategory == 2 && @group.name == comboBox1.Text
                             select new
                             {
                                 id = student.id,
                                 ФИО = student.FIO,
                                 Дата_рождения = student.bDay,
                                 Телефон = student.phone,
                                 Паспорт = student.passport,
                                 Адрес = student.adress,
                                 Мед_сертификат = student.medicalCertificate
                             };
                dgvStudent.DataSource = result.ToList();
                dgvStudent.Columns[0].Visible = false;
            }
            else if (Category == 3)
            {
                var result = from contract in db.contract
                             join student in db.student
                             on contract.idStudent equals student.id
                             join @group in db.@group
                             on contract.idGroup equals @group.id
                             where contract.isDeleted == false && @group.idCategory == 1 && @group.name == comboBox1.Text
                             select new
                             {
                                 id = student.id,
                                 ФИО = student.FIO,
                                 Дата_рождения = student.bDay,
                                 Телефон = student.phone,
                                 Паспорт = student.passport,
                                 Адрес = student.adress,
                                 Мед_сертификат = student.medicalCertificate
                             };
                dgvStudent.DataSource = result.ToList();
                dgvStudent.Columns[0].Visible = false;
            }
            else if (Category == 4)
            {
                var result = from contract in db.contract
                             join student in db.student
                             on contract.idStudent equals student.id
                             join @group in db.@group
                             on contract.idGroup equals @group.id
                             where contract.isDeleted == false && @group.idCategory == 4 && @group.name == comboBox1.Text
                             select new
                             {
                                 id = student.id,
                                 ФИО = student.FIO,
                                 Дата_рождения = student.bDay,
                                 Телефон = student.phone,
                                 Паспорт = student.passport,
                                 Адрес = student.adress,
                                 Мед_сертификат = student.medicalCertificate
                             };
                dgvStudent.DataSource = result.ToList();
                dgvStudent.Columns[0].Visible = false;
            }
            else
            {
                var result = from contract in db.contract
                             join student in db.student
                             on contract.idStudent equals student.id
                             join @group in db.@group
                             on contract.idGroup equals @group.id
                             where contract.isDeleted == false && @group.idCategory == 5 && @group.name == comboBox1.Text
                             select new
                             {
                                 id = student.id,
                                 ФИО = student.FIO,
                                 Дата_рождения = student.bDay,
                                 Телефон = student.phone,
                                 Паспорт = student.passport,
                                 Адрес = student.adress,
                                 Мед_сертификат = student.medicalCertificate
                             };
                dgvStudent.DataSource = result.ToList();
                dgvStudent.Columns[0].Visible = false;
            }
        }
    }
}

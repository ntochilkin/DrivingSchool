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
    public partial class Contract : Form
    {
        DrivingSchoolEntities_ db = new DrivingSchoolEntities_();
        int Category = 0;
        public Contract(int category)
        {
            InitializeComponent();
            dgvStudent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudent.AllowUserToAddRows = false;
            Category = category;
            if (Category == 1) {
                comboBox1.DataSource = db.group.Where(p => p.isDeleted == false && p.idCategory == Category).ToList();
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "name";
            }
            else if (Category == 2) {
                comboBox1.DataSource = db.group.Where(p => p.isDeleted == false && p.idCategory == Category).ToList();
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "name";
            }
            else if (Category == 3) { 
                comboBox1.DataSource = db.group.Where(p => p.isDeleted == false && p.idCategory == Category).ToList();
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "name";
            }
            else if (Category == 4) { 
                comboBox1.DataSource = db.group.Where(p => p.isDeleted == false && p.idCategory == Category).ToList();
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "name";
            }
            else { 
                comboBox1.DataSource = db.group.Where(p => p.isDeleted == false && p.idCategory == Category).ToList();
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "name";
            }
            contractOut();
        }
        public void contractOut()
        {
            var result = from contract in db.contract
                         join @group in db.@group
                         on contract.idGroup equals @group.id
                         join student in db.student
                         on contract.idStudent equals student.id
                         where contract.isDeleted == false
                         select new
                         {
                             id = contract.id,
                             Дата_заключения = student.FIO,
                             Группа = @group.name,
                             Студент = student.FIO,
                             Стоимость = contract.price,
                             Статус_оплаты = contract.status
                         };
            dgvStudent.DataSource = result.ToList();
            dgvStudent.Columns[0].Visible = false;
        }
       
        private void редактироватьКурсантаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContractAddEdit contractAddEdit = new ContractAddEdit(Convert.ToInt32(dgvStudent.CurrentRow.Cells[0].Value), 1, Category);
            if (contractAddEdit.ShowDialog() == DialogResult.OK)
            {
                contractOut();
            }
        }

        private void добавитьСтудентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContractAddEdit contractAddEdit = new ContractAddEdit(0, 0, Category);
            if (contractAddEdit.ShowDialog() == DialogResult.OK)
            {
                contractOut();
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
                    contractOut();
                    MessageBox.Show("Данные успешно удалены", "Удаление", MessageBoxButtons.OK);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Category == 1)
            {
                var result = from contract in db.contract
                             join @group in db.@group
                             on contract.idGroup equals @group.id
                             join student in db.student
                             on contract.idStudent equals student.id
                             where contract.isDeleted == false && @group.idCategory == 1 && @group.name == comboBox1.Text
                             select new
                             {
                                 id = contract.id,
                                 Дата_заключения = student.FIO,
                                 Группа = @group.name,
                                 Студент = student.FIO,
                                 Стоимость = contract.price,
                                 Статус_оплаты = contract.status
                             };
                dgvStudent.DataSource = result.ToList();
                dgvStudent.Columns[0].Visible = false;

            }
            else if (Category == 2)
            {
                var result = from contract in db.contract
                             join @group in db.@group
                             on contract.idGroup equals @group.id
                             join student in db.student
                             on contract.idStudent equals student.id
                             where contract.isDeleted == false && @group.idCategory == 2 && @group.name == comboBox1.Text
                             select new
                             {
                                 id = contract.id,
                                 Дата_заключения = student.FIO,
                                 Группа = @group.name,
                                 Студент = student.FIO,
                                 Стоимость = contract.price,
                                 Статус_оплаты = contract.status
                             };
                dgvStudent.DataSource = result.ToList();
                dgvStudent.Columns[0].Visible = false;
            }
            else if (Category == 3)
            {
                var result = from contract in db.contract
                             join @group in db.@group
                             on contract.idGroup equals @group.id
                             join student in db.student
                             on contract.idStudent equals student.id
                             where contract.isDeleted == false && @group.idCategory == 3 && @group.name == comboBox1.Text
                             select new
                             {
                                 id = contract.id,
                                 Дата_заключения = student.FIO,
                                 Группа = @group.name,
                                 Студент = student.FIO,
                                 Стоимость = contract.price,
                                 Статус_оплаты = contract.status
                             };
                dgvStudent.DataSource = result.ToList();
                dgvStudent.Columns[0].Visible = false;
            }
            else if (Category == 4)
            {
                var result = from contract in db.contract
                             join @group in db.@group
                             on contract.idGroup equals @group.id
                             join student in db.student
                             on contract.idStudent equals student.id
                             where contract.isDeleted == false && @group.idCategory == 4 && @group.name == comboBox1.Text
                             select new
                             {
                                 id = contract.id,
                                 Дата_заключения = student.FIO,
                                 Группа = @group.name,
                                 Студент = student.FIO,
                                 Стоимость = contract.price,
                                 Статус_оплаты = contract.status
                             };
                dgvStudent.DataSource = result.ToList();
                dgvStudent.Columns[0].Visible = false;
            }
            else
            {
                var result = from contract in db.contract
                             join @group in db.@group
                             on contract.idGroup equals @group.id
                             join student in db.student
                             on contract.idStudent equals student.id
                             where contract.isDeleted == false && @group.idCategory == 5 && @group.name == comboBox1.Text
                             select new
                             {
                                 id = contract.id,
                                 Дата_заключения = student.FIO,
                                 Группа = @group.name,
                                 Студент = student.FIO,
                                 Стоимость = contract.price,
                                 Статус_оплаты = contract.status
                             };
                dgvStudent.DataSource = result.ToList();
                dgvStudent.Columns[0].Visible = false;
            }
        }

        private void textSearch_TextChanged_1(object sender, EventArgs e)
        {
            if (Category == 1)
            {
                var result = from contract in db.contract
                             join @group in db.@group
                             on contract.idGroup equals @group.id
                             join student in db.student
                             on contract.idStudent equals student.id
                             where contract.isDeleted == false && @group.idCategory == 1 && student.FIO.StartsWith(textSearch.Text)
                             select new
                             {
                                 id = contract.id,
                                 Дата_заключения = student.FIO,
                                 Группа = @group.name,
                                 Студент = student.FIO,
                                 Стоимость = contract.price,
                                 Статус_оплаты = contract.status
                             };
                dgvStudent.DataSource = result.ToList();
                dgvStudent.Columns[0].Visible = false;

            }
            else if (Category == 2)
            {
                var result = from contract in db.contract
                             join @group in db.@group
                             on contract.idGroup equals @group.id
                             join student in db.student
                             on contract.idStudent equals student.id
                             where contract.isDeleted == false && @group.idCategory == 2 && student.FIO.StartsWith(textSearch.Text)
                             select new
                             {
                                 id = contract.id,
                                 Дата_заключения = student.FIO,
                                 Группа = @group.name,
                                 Студент = student.FIO,
                                 Стоимость = contract.price,
                                 Статус_оплаты = contract.status
                             };
                dgvStudent.DataSource = result.ToList();
                dgvStudent.Columns[0].Visible = false;
            }
            else if (Category == 3)
            {
                var result = from contract in db.contract
                             join @group in db.@group
                             on contract.idGroup equals @group.id
                             join student in db.student
                             on contract.idStudent equals student.id
                             where contract.isDeleted == false && @group.idCategory == 3 && student.FIO.StartsWith(textSearch.Text)
                             select new
                             {
                                 id = contract.id,
                                 Дата_заключения = student.FIO,
                                 Группа = @group.name,
                                 Студент = student.FIO,
                                 Стоимость = contract.price,
                                 Статус_оплаты = contract.status
                             };
                dgvStudent.DataSource = result.ToList();
                dgvStudent.Columns[0].Visible = false;
            }
            else if (Category == 4)
            {
                var result = from contract in db.contract
                             join @group in db.@group
                             on contract.idGroup equals @group.id
                             join student in db.student
                             on contract.idStudent equals student.id
                             where contract.isDeleted == false && @group.idCategory == 4 && student.FIO.StartsWith(textSearch.Text)
                             select new
                             {
                                 id = contract.id,
                                 Дата_заключения = student.FIO,
                                 Группа = @group.name,
                                 Студент = student.FIO,
                                 Стоимость = contract.price,
                                 Статус_оплаты = contract.status
                             };
                dgvStudent.DataSource = result.ToList();
                dgvStudent.Columns[0].Visible = false;
            }
            else
            {
                var result = from contract in db.contract
                             join @group in db.@group
                             on contract.idGroup equals @group.id
                             join student in db.student
                             on contract.idStudent equals student.id
                             where contract.isDeleted == false && @group.idCategory == 5 && student.FIO.StartsWith(textSearch.Text)
                             select new
                             {
                                 id = contract.id,
                                 Дата_заключения = student.FIO,
                                 Группа = @group.name,
                                 Студент = student.FIO,
                                 Стоимость = contract.price,
                                 Статус_оплаты = contract.status
                             };
                dgvStudent.DataSource = result.ToList();
                dgvStudent.Columns[0].Visible = false;
            }
        }
    }
}

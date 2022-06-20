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
    public partial class AcademicPlan : Form
    {
        DrivingSchoolEntities_ db = new DrivingSchoolEntities_();
        int Category = 0;
        public AcademicPlan(int category)
        {
            InitializeComponent();
            dgvPlan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPlan.AllowUserToAddRows = false;
            Category = category;
            if (Category == 5) { planDOut(); }
            else if (Category == 2) { planBOut(); }
            else if (Category == 3) { planCOut(); }
            else if (Category == 4) { planEOut(); }
            else { planAOut(); }
        }

        public void planAOut()
        {
            var result = from academicPlan in db.academicPlan
                         join subject in db.subject
                         on academicPlan.idSubject equals subject.id
                         where academicPlan.isDeleted == false && academicPlan.idCategory == 1
                         select new
                         {
                             id = academicPlan.id,
                             Дисциплина = subject.subjectName,
                             Количество_часов = academicPlan.hours
                         };
            dgvPlan.DataSource = result.ToList();
            dgvPlan.Columns[0].Visible = false;
        }
        public void planBOut()
        {
            var result = from academicPlan in db.academicPlan
                         join subject in db.subject
                         on academicPlan.idSubject equals subject.id
                         where academicPlan.isDeleted == false && academicPlan.idCategory == 2
                         select new
                         {
                             id = academicPlan.id,
                             Дисциплина = subject.subjectName,
                             Количество_часов = academicPlan.hours
                         };
            dgvPlan.DataSource = result.ToList();
            dgvPlan.Columns[0].Visible = false;
        }
        public void planCOut()
        {
            var result = from academicPlan in db.academicPlan
                         join subject in db.subject
                         on academicPlan.idSubject equals subject.id
                         where academicPlan.isDeleted == false && academicPlan.idCategory == 3
                         select new
                         {
                             id = academicPlan.id,
                             Дисциплина = subject.subjectName,
                             Количество_часов = academicPlan.hours
                         };
            dgvPlan.DataSource = result.ToList();
            dgvPlan.Columns[0].Visible = false;
        }
        public void planDOut()
        {
            var result = from academicPlan in db.academicPlan
                         join subject in db.subject
                         on academicPlan.idSubject equals subject.id
                         where academicPlan.isDeleted == false && academicPlan.idCategory == 4
                         select new
                         {
                             id = academicPlan.id,
                             Дисциплина = subject.subjectName,
                             Количество_часов = academicPlan.hours
                         };
            dgvPlan.DataSource = result.ToList();
            dgvPlan.Columns[0].Visible = false;
        }
        public void planEOut()
        {
            var result = from academicPlan in db.academicPlan
                         join subject in db.subject
                         on academicPlan.idSubject equals subject.id
                         where academicPlan.isDeleted == false && academicPlan.idCategory == 5
                         select new
                         {
                             id = academicPlan.id,
                             Дисциплина = subject.subjectName,
                             Количество_часов = academicPlan.hours
                         };
            dgvPlan.DataSource = result.ToList();
            dgvPlan.Columns[0].Visible = false;
        }

        private void добавитьдисциплинуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcademicPlanAddEdit academicPlanAddEdit = new AcademicPlanAddEdit(0, 0, Category);
            if (academicPlanAddEdit.ShowDialog() == DialogResult.OK)
            {
                if (Category == 1) { planAOut(); }
                else if (Category == 2) { planBOut(); }
                else if (Category == 3) { planCOut(); }
                else if (Category == 4) { planEOut(); }
                else { planDOut(); }
            }
        }

        private void редактироватьдисциплинуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcademicPlanAddEdit academicPlanAddEdit = new AcademicPlanAddEdit(Convert.ToInt32(dgvPlan.CurrentRow.Cells[0].Value), 0, Category);
            if (academicPlanAddEdit.ShowDialog() == DialogResult.OK)
            {
                if (Category == 1) { planAOut(); }
                else if (Category == 2) { planBOut(); }
                else if (Category == 3) { planCOut(); }
                else if (Category == 4) { planEOut(); }
                else { planDOut(); }
            }
        }

        private void удалитьдисциплинуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                academicPlan academicPlan = db.academicPlan.Find(dgvPlan.CurrentRow.Cells[0].Value);
                if (MessageBox.Show("Вы уверенны что хотите удалить?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    academicPlan.isDeleted = true;
                    db.SaveChanges();
                    if (Category == 1) { planAOut(); }
                    else if (Category == 2) { planBOut(); }
                    else if (Category == 3) { planCOut(); }
                    else if (Category == 4) { planEOut(); }
                    else { planDOut(); }
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
            var result = from academicPlan in db.academicPlan
                         join subject in db.subject
                         on academicPlan.idSubject equals subject.id
                         where academicPlan.isDeleted == false && subject.subjectName.StartsWith(textSearch.Text + "")
                         select new
                         {
                             id = academicPlan.id,
                             Дисциплина = subject.subjectName,
                             Количество_часов = academicPlan.hours
                         };

            dgvPlan.DataSource = result.ToList();
            dgvPlan.Columns[0].Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

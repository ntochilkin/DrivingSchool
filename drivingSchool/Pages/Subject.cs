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
    public partial class Subject : Form
    {
        DrivingSchoolEntities_ db = new DrivingSchoolEntities_();
        public Subject()
        {
            InitializeComponent();
            dgvSubject.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSubject.AllowUserToAddRows = false;
            subjectOut();
        }
        public void subjectOut()
        {
            var result = from subject in db.subject
                         where subject.isDeleted == false
                         select new
                         {
                             id = subject.id,
                             Название = subject.subjectName,
                         };
            dgvSubject.DataSource = result.ToList();
            dgvSubject.Columns[0].Visible = false;
        }

        private void удалитьКурсантаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                subject subject = db.subject.Find(dgvSubject.CurrentRow.Cells[0].Value);
                if (MessageBox.Show("Вы уверенны что хотите удалить?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    subject.isDeleted = true;
                    db.SaveChanges();
                    subjectOut();
                    MessageBox.Show("Данные успешно удалены", "Удаление", MessageBoxButtons.OK);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void редактироватьКурсантаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubjictAddEdit subjictAddEdit = new SubjictAddEdit(Convert.ToInt32(dgvSubject.CurrentRow.Cells[0].Value), 1);
            if (subjictAddEdit.ShowDialog() == DialogResult.OK)
            {
                subjectOut();
            }
        }

        private void добавитьСтудентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubjictAddEdit subjictAddEdit = new SubjictAddEdit(Convert.ToInt32(dgvSubject.CurrentRow.Cells[0].Value), 0);
            if (subjictAddEdit.ShowDialog() == DialogResult.OK)
            {
                subjectOut();
            }
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            var result = from subject in db.subject
                         where subject.isDeleted == false && subject.subjectName.StartsWith(textSearch.Text + "")
                         select new
                         {
                             id = subject.id,
                             Название = subject.subjectName,
                         };
            dgvSubject.DataSource = result.ToList();
            dgvSubject.Columns[0].Visible = false;
        }
    }
}

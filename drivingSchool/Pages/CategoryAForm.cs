using drivingSchool.AppData;
using drivingSchool.CategoryA;
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
    public partial class CategoryAForm : Form
    {
        DrivingSchoolEntities_ db = new DrivingSchoolEntities_();
        int Category = 0;

        private Button currentButton; //Передаваемая кнопка меню
        private Form activeForm; //Активная дочерняя форма

        //Нажатие на кнопку меню
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = Color.FromArgb(0, 73, 106);
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        //Возврат кнопки меню в исходное состояние
        private void DisableButton()
        {
            foreach (Control previousBtn in panelNav.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(0, 118, 174);
                    previousBtn.ForeColor = Color.White;
                    previousBtn.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        //Открытие дочерней кнопки, в зависимости от выбранного меню
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null) activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelMain.Controls.Add(childForm);
            this.panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        public CategoryAForm(int category)
        {
            InitializeComponent();
            dgvGroup.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGroup.AllowUserToAddRows = false;
            Category = category;
            if (Category == 1) { groupAOut(); }
            else if (Category == 2) { groupBOut(); }
            else if (Category == 3) { groupCOut(); }
            else if (Category == 4) { groupDOut(); }
            else { groupEOut(); }
        }

        public void groupAOut()
        {
            var result = from g in db.@group
                         join category in db.category
                         on g.idCategory equals category.id
                         where g.isDeleted == false && category.category1 == "A"
                         select new
                         {
                             id = g.id,
                             Группа = g.name,
                             Начало_обучения = g.dateStart,
                             Окончание_обучения = g.dateEnd
                         };
            dgvGroup.DataSource = result.ToList();
            dgvGroup.Columns[0].Visible = false;
        }

        public void groupBOut()
        {
            var result = from g in db.@group
                         join category in db.category
                         on g.idCategory equals category.id
                         where g.isDeleted == false && category.category1 == "B"
                         select new
                         {
                             id = g.id,
                             Группа = g.name,
                             Начало_обучения = g.dateStart,
                             Окончание_обучения = g.dateEnd
                         };
            dgvGroup.DataSource = result.ToList();
            dgvGroup.Columns[0].Visible = false;
        }

        public void groupCOut()
        {
            var result = from g in db.@group
                         join category in db.category
                         on g.idCategory equals category.id
                         where g.isDeleted == false && category.category1 == "C"
                         select new
                         {
                             id = g.id,
                             Группа = g.name,
                             Начало_обучения = g.dateStart,
                             Окончание_обучения = g.dateEnd
                         };
            dgvGroup.DataSource = result.ToList();
            dgvGroup.Columns[0].Visible = false;
        }

        public void groupDOut()
        {
            var result = from g in db.@group
                         join category in db.category
                         on g.idCategory equals category.id
                         where g.isDeleted == false && category.category1 == "D"
                         select new
                         {
                             id = g.id,
                             Группа = g.name,
                             Начало_обучения = g.dateStart,
                             Окончание_обучения = g.dateEnd
                         };
            dgvGroup.DataSource = result.ToList();
            dgvGroup.Columns[0].Visible = false;
        }

        public void groupEOut()
        {
            var result = from g in db.@group
                         join category in db.category
                         on g.idCategory equals category.id
                         where g.isDeleted == false && category.category1 == "E"
                         select new
                         {
                             id = g.id,
                             Группа = g.name,
                             Начало_обучения = g.dateStart,
                             Окончание_обучения = g.dateEnd
                         };
            dgvGroup.DataSource = result.ToList();
            dgvGroup.Columns[0].Visible = false;
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                group group = db.group.Find(dgvGroup.CurrentRow.Cells[0].Value);
                if (MessageBox.Show("Вы уверенны что хотите удалить?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    group.isDeleted = true;
                    db.SaveChanges();
                    if (Category == 1) { groupAOut(); }
                    else if (Category == 2) { groupBOut(); }
                    else if (Category == 3) { groupCOut(); }
                    else if (Category == 4) { groupDOut(); }
                    else { groupEOut(); }
                    MessageBox.Show("Данные успешно удалены", "Удаление", MessageBoxButtons.OK);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            GroupAddEdit groupAddEdit = new GroupAddEdit(Convert.ToInt32(dgvGroup.CurrentRow.Cells[0].Value), 1, Category);
            if (groupAddEdit.ShowDialog() == DialogResult.OK)
            {
                if (Category == 1) { groupAOut(); }
                else if (Category == 2) { groupBOut(); }
                else if (Category == 3) { groupCOut(); }
                else if (Category == 4) { groupDOut(); }
                else { groupEOut(); }
            }
        }

        private void добавитьГруппуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GroupAddEdit groupAddEdit = new GroupAddEdit(0, 0, Category);
            if (groupAddEdit.ShowDialog() == DialogResult.OK)
            {
                if (Category == 1) { groupAOut(); }
                else if (Category == 2) { groupBOut(); }
                else if (Category == 3) { groupCOut(); }
                else if (Category == 4) { groupDOut(); }
                else { groupEOut(); }
            }
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            OpenChildForm(new StudentA(Category), sender);
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            dgvGroup.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGroup.AllowUserToAddRows = false;
            if (Category == 1) { groupAOut(); }
            else if (Category == 2) { groupBOut(); }
            else if (Category == 3) { groupCOut(); }
            else if (Category == 4) { groupDOut(); }
            else { groupEOut(); }
        }

        private void btnAcademPlan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AcademicPlan(Category), sender);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Contract(Category), sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Subject(), sender);
        }
    }
}

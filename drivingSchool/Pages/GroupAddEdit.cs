using drivingSchool.AppData;
using drivingSchool.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace drivingSchool.CategoryA
{
    public partial class GroupAddEdit : Form
    {
        DrivingSchoolEntities_ db = new DrivingSchoolEntities_();
        int groupID, Status = 0, Category = 0;
        public GroupAddEdit(int ID, int status, int category)
        {
            InitializeComponent();
            groupID = ID; //id группы
            Status = status; //статус операции: 0 - добавление, 1 - редактирование
            Category = category;

            if (Status == 1)
            {
                var result = db.group.Where(g => g.id == ID && g.isDeleted == false).FirstOrDefault();
                textBox1.Text = result.name;
                dateTimePicker1.Value = result.dateStart;
                dateTimePicker2.Value = result.dateEnd;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idCat = 0;
            if (Status == 1)
            {
                try
                {
                    var result = db.group.Where(g => g.id == groupID && g.isDeleted == false).FirstOrDefault();
                    result.name = textBox1.Text;
                    result.dateStart = dateTimePicker1.Value;
                    result.dateEnd = dateTimePicker2.Value;
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
                    if (Category == 1) { idCat = 1; }
                        else if (Category == 2) { idCat = 2; }
                            else if (Category == 3) { idCat = 3; }
                                else if (Category == 4) { idCat = 4; }
                                    else { idCat = 5; }
                    group group = new group
                    {
                        name = textBox1.Text,
                        dateStart = dateTimePicker1.Value,
                        dateEnd = dateTimePicker2.Value,
                        idCategory = idCat,
                        isDeleted = false
                    };
                    db.group.Add(group);
                    db.SaveChanges();
                    this.DialogResult = DialogResult.OK;
                }
                catch
                {
                    MessageBox.Show("Возникло исключение. Проверьте введенные данные", "Ошибка", MessageBoxButtons.OK);
                }
            }
        }
    }
}

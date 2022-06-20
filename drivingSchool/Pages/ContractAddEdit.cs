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
    public partial class ContractAddEdit : Form
    {
        DrivingSchoolEntities_ db = new DrivingSchoolEntities_();
        int contractID, Status = 0, Category = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            if (Status == 1)
            {
                try
                {
                    var st = db.student.Where(p => p.isDeleted == false && p.FIO == comboBox1.Text).FirstOrDefault();
                    int stID = st.id;
                    var gr = db.group.Where(p => p.isDeleted == false && p.name == comboBox2.Text).FirstOrDefault();
                    int grID = gr.id;
                    var result = db.contract.Where(p => p.id == contractID).FirstOrDefault();
                    result.idStudent = stID;
                    result.idGroup = grID;
                    result.price = float.Parse(textBox1.Text);
                    result.data = dateTimePicker1.Value;
                    if (comboBox3.SelectedIndex == 1)
                    {
                        result.status = false;
                    }
                    else
                    {
                        result.status = true;
                    }
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
                    var st = db.student.Where(p => p.isDeleted == false).ToList();
                    int stID = 0;
                    foreach (var elem in st)
                    {
                        if (elem.FIO == comboBox1.Text)
                            stID = elem.id;
                    }
                    var gr = db.group.Where(p => p.isDeleted == false).ToList();
                    int grID = 0;
                    foreach (var elem in gr)
                    {
                        if (elem.name == comboBox2.Text)
                            grID = elem.id;
                    }
                    bool pr = false;
                    if (comboBox3.SelectedIndex == 1)
                    {
                        pr = false;
                    }
                    else
                    {
                        pr = true;
                    }
                    contract contract = new contract
                    {
                        idStudent = stID,
                        idGroup = grID,
                        price = float.Parse(textBox1.Text),
                        data = dateTimePicker1.Value,
                        status =pr,
                        isDeleted = false
                    };
                    db.contract.Add(contract);
                    db.SaveChanges();
                    this.DialogResult = DialogResult.OK;
                }
                catch
                {
                    MessageBox.Show("Возникло исключение. Проверьте введенные данные", "Ошибка", MessageBoxButtons.OK);
                }
            }
        }

        public ContractAddEdit(int ID, int status, int category)
        {
            InitializeComponent();
            contractID = ID; //id 
            Status = status; //статус операции: 0 - добавление, 1 - редактирование
            Category = category;

            if (Status == 1)
            {
                var result = db.contract.Where(g => g.id == ID && g.isDeleted == false).FirstOrDefault();
                
                int idSt = result.idStudent;
                comboBox1.DataSource = db.student.Where(p => p.isDeleted == false && p.id == idSt).ToList();
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "FIO";

                int idGr = result.idGroup;
                comboBox2.DataSource = db.group.Where(p => p.isDeleted == false && p.id == idGr && p.idCategory == Category).ToList();
                comboBox2.ValueMember = "id";
                comboBox2.DisplayMember = "name";

                if (result.status == true)
                {
                    comboBox3.SelectedIndex = 0;
                }
                else
                {
                    comboBox3.SelectedIndex = 1;
                }

                textBox1.Text = Convert.ToString(result.price);
                dateTimePicker1.Value = result.data;


            }
            else
            {
                comboBox1.DataSource = db.student.Where(p => p.isDeleted == false).ToList();
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "FIO";

                comboBox2.DataSource = db.group.Where(p => p.isDeleted == false && p.idCategory == Category).ToList();
                comboBox2.ValueMember = "id";
                comboBox2.DisplayMember = "name";
            }
        }

    
    }
}

using drivingSchool.CategoryA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace drivingSchool
{
    public partial class MainForm : Form
    {
        private Button currentButton; //Передаваемая кнопка меню
        private Form activeForm; //Активная дочерняя форма
        public MainForm()
        {
            InitializeComponent();
        }
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
                    currentButton.Font = new System.Drawing.Font("Georgia", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        //Возврат кнопки меню в исходное состояние
        private void DisableButton()
        {
            foreach (Control previousBtn in panelNavigate.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(0, 118, 174);
                    previousBtn.ForeColor = Color.White;
                    previousBtn.Font = new System.Drawing.Font("Georgia", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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

        private void btnA_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Pages.CategoryAForm(1), sender);
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Pages.CategoryAForm(2), sender);
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Pages.CategoryAForm(3), sender);
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Pages.CategoryAForm(4), sender);
        }

        private void btnE_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Pages.CategoryAForm(5), sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
        }
    }
}

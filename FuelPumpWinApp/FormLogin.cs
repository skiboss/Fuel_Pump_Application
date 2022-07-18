using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FuelPumpWinApp.Models;

namespace FuelPumpWinApp
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        public static User user;

        private void FormLogin_Load(object sender, EventArgs e)
        {
            User user = new User();
            user.Username = "Admin";
            user.Firstname = "Administrator";
            user.Lastname = "System";
            user.Password = "admin";
            user.Status = "Active";
            user.Position = "Admin";
            user.Email = "";
            user.PhoneNumber = "";

            user.Add();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string msg = User.ValidateUser(textBoxUsername.Text, textBoxPassword.Text);
            if (msg == "Successful")
            {
                Form1 form = new Form1();
                user = User.GetDetails(textBoxUsername.Text);
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(msg);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            string msg = "Exit Now?";
            string exit = "Are you sure you want to perform this action?";
            MessageBoxButtons button = MessageBoxButtons.YesNo;
            MessageBoxIcon icon = MessageBoxIcon.Question;
            DialogResult result;

            result = MessageBox.Show(msg, exit, button, icon);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }
        }
    }
}

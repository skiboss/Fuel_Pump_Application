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
    public partial class FormRegisterUser : Form
    {
        public FormRegisterUser()
        {
            InitializeComponent();
        }

        public static User user;

        public void Clear()
        {
            textBoxUsername.Clear();
            textBoxFirstname.Clear();
            textBoxLastName.Clear();
            textBoxPassword.Clear();
            textBoxPhoneNumber.Clear();
            textBoxEmail.Clear();
            textBoxStatus.Clear();
            comboBoxPosition.Text = "";

        }
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (textBoxUsername.Text == "")
            {
                MessageBox.Show("Enter Username");
                textBoxUsername.Focus();
                return;
            }

            User user = new User();
            user.Username = textBoxUsername.Text;
            user.Firstname = textBoxFirstname.Text;
            user.Lastname = textBoxLastName.Text;
            user.Position = comboBoxPosition.Text;
            user.PhoneNumber = textBoxPhoneNumber.Text;
            user.Email = textBoxEmail.Text;
            user.Password = textBoxPassword.Text;
            user.Status = textBoxStatus.Text;

            string msg = "";
            string info = "created";

            if(buttonSubmit.Text == "Add")
            {
                msg = user.Add();
            }
            else
            {
                msg = user.Update();
                info = "updated";
            }

            if (msg == "Successful")
            {
                MessageBox.Show($"User {info} Successfully");
            }
            else
            {
                MessageBox.Show(msg);
            }

            Clear();

            user = null;
        }

        private void FormRegisterUser_Load(object sender, EventArgs e)
        {
            if (user != null)
            {
                textBoxUsername.Text = user.Username;
                textBoxUsername.Enabled = false;
                textBoxFirstname.Text = user.Firstname;
                textBoxLastName.Text = user.Lastname;
                textBoxPhoneNumber.Text = user.PhoneNumber;
                comboBoxPosition.Text = user.Position;
                textBoxStatus.Text = user.Status;
                textBoxPassword.Text = user.Password;
                textBoxPassword.Enabled = false;
                buttonSubmit.Text = "Update";
            }
            else
            {
                textBoxUsername.Text = "";
                textBoxUsername.Enabled = true;
                textBoxFirstname.Text = "";
                textBoxLastName.Text = "";
                textBoxPhoneNumber.Text = "";
                comboBoxPosition.Text = "";
                textBoxStatus.Text = "";
                textBoxPassword.Text = "";
                buttonSubmit.Text = "Add";
            }
        }
    }
}

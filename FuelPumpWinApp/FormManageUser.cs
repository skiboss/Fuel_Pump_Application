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
    public partial class FormManageUser : Form
    {
        public FormManageUser()
        {
            InitializeComponent();
        }

        private void FormManageUser_Load(object sender, EventArgs e)
        {
            FillUserGrid();
            dataGridViewUsers.AlternatingRowsDefaultCellStyle.BackColor = Color.Honeydew;
            dataGridViewUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSeaGreen;
        }

        private void FillUserGrid()
        {
            dataGridViewUsers.DataSource = User.GetUsers();
        }

        private void buttonBlockUser_Click(object sender, EventArgs e)
        {
            string user = dataGridViewUsers.CurrentRow.Cells[0].Value.ToString();
            if (user != null)
            {
                User.BlockUser(user);
                FillUserGrid();
            }
        }

        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            FormRegisterUser form = new FormRegisterUser();
            form.ShowDialog();
            FillUserGrid();

        }

        private void buttonUnblockUser_Click(object sender, EventArgs e)
        {
            string user = dataGridViewUsers.CurrentRow.Cells[0].Value.ToString();
            if (user != null)
            {
                User.UnblockUser(user);
                FillUserGrid();
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string username = dataGridViewUsers.CurrentRow.Cells[0].Value.ToString();
            if (username != null)
            {
                FormRegisterUser.user = User.GetDetails(username);
                FormRegisterUser form = new FormRegisterUser();
                form.ShowDialog();
                dataGridViewUsers.DataSource = User.GetUsers();
            }

        }
    }
}

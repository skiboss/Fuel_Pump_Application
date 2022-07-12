using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuelPumpWinApp
{
    public partial class FormInput : Form
    {
        public FormInput()
        {
            InitializeComponent();
        }

        private void FormInput_Load(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            textBoxValue.Text = "0";
        }

        private void buttonPeriod_Click(object sender, EventArgs e)
        {
            if (textBoxValue.Text.Contains(".")) return;
            textBoxValue.Text += ".";
        }

        private void DisplayNumber(string val)
        {
            if (textBoxValue.Text == "0")
            {
                textBoxValue.Text = val;
            }
            else
            {
                textBoxValue.Text += val;
            }
        }
        private void buttonZero_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            DisplayNumber(button.Text);
        }

        private void buttonZeroZero_Click(object sender, EventArgs e)
        {
            textBoxValue.Text = Convert.ToDecimal(textBoxValue.Text).ToString("N2");
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxValue.Text))
            {
                if (radioButtonSales.Checked)
                {
                    Form1.SalesInput = Convert.ToDecimal(textBoxValue.Text);
                    Form1.LitresInput = 0;
                }
                if (radioButtonLitre.Checked)
                {
                    Form1.LitresInput = Convert.ToDecimal(textBoxValue.Text);
                    Form1.SalesInput = 0;
                }
                if (radioButtonPrice.Checked)
                {
                    Form1.PriceInput = Convert.ToDecimal(textBoxValue.Text);
                    RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\FuelPumpSettings");
                    key.SetValue("Price", Form1.PriceInput.ToString());
                    key.Close();
                }
                this.Close();
            }
        }

        private void buttonOne_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            DisplayNumber(button.Text);
        }

        private void buttonTwo_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            DisplayNumber(button.Text);
        }

        private void buttonThree_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            DisplayNumber(button.Text);
        }

        private void buttonFour_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            DisplayNumber(button.Text);
        }

        private void buttonFive_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            DisplayNumber(button.Text);
        }

        private void buttonSix_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            DisplayNumber(button.Text);
        }

        private void buttonSeven_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            DisplayNumber(button.Text);
        }

        private void buttonEight_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            DisplayNumber(button.Text);
        }

        private void buttonNine_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            DisplayNumber(button.Text);
        }
    }
}

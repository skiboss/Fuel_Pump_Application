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
using Microsoft.Win32;

namespace FuelPumpWinApp
{
    public partial class Form1 : Form
    {
        public static decimal SalesInput { get; set; }
        public static decimal LitresInput { get; set; }
        public static decimal PriceInput { get; set; }

        private decimal sales = 0;
        private decimal litre = 0;
        private decimal price = 0;
        public static int SalesCount = 1;
        private bool isLitre;
        private bool paused;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\FuelPumpSettings");
            if(key != null)
            {
                PriceInput = Convert.ToDecimal(key.GetValue("Price"));
                SalesCount = Convert.ToInt32(key.GetValue("SalesCount")); 
            }
            key.Close();
            textBoxPrice.Text = PriceInput.ToString("N2");
        }

        private void linkLabelInputs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormInput form = new FormInput();
            form.ShowDialog();
            textBoxSales.Text = SalesInput.ToString("N2");
            textBoxLitre.Text = LitresInput.ToString("N2");
            textBoxPrice.Text = PriceInput.ToString("N2");
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            litre = Convert.ToDecimal(textBoxLitre.Text);
            sales = Convert.ToDecimal(textBoxSales.Text);
            price = Convert.ToDecimal(textBoxPrice.Text);
            if (!paused)
            {
                if (litre > 0)
                {                 
                    isLitre = true;
                }
                else
                {
                    isLitre = false;
                }
                paused = false;
            }
            timer1.Enabled = true;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            paused = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isLitre)
            {
                if (sales >= price * litre) return;
                sales += 1;
                textBoxSales.Text = sales.ToString("N2");
            }
            else
            {
                if (litre >= sales / price) return;
                litre += (decimal)0.1;
                textBoxLitre.Text = litre.ToString("N2");
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Sales newSale = new Sales();
            newSale.Date = DateTime.UtcNow.AddHours(1);
            newSale.SalesId = DateTime.UtcNow.AddHours(1).ToString("yy/MM/dd/") + SalesCount;
            newSale.SalesPerson = "Danny";
            newSale.Litres = litre;
            newSale.Amount = sales;
            newSale.Pump = "Pump 1";
            newSale.Shift = "Morning";
            string msg = newSale.Add();
            if (msg == "Successful")
            {
                SalesCount++;
                textBoxSales.Text = "0";
                textBoxLitre.Text = "0";
                SalesInput = 0;
                LitresInput = 0;

                //To enable salesId continuation without the primary key conflict
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\FuelPumpSettings");
                key.SetValue("SalesCount", SalesCount);
                key.Close();
            }
            else
            {
                MessageBox.Show(msg);
            }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormSalesView form = new FormSalesView();
            form.ShowDialog();
        }
    }
}

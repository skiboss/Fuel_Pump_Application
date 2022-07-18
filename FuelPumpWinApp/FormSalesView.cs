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
    public partial class FormSalesView : Form
    {
        public FormSalesView()
        {
            InitializeComponent();
        }

        private void FormSalesView_Load(object sender, EventArgs e)
        {
            FillSalesGrid();
            dataGridViewSales.Columns[4].DefaultCellStyle.Format = "N2";
            dataGridViewSales.AlternatingRowsDefaultCellStyle.BackColor = Color.Honeydew;


            GetSalesTotal();
        }
        private void FillSalesGrid()
        {
            dataGridViewSales.DataSource = Sales.GetSales();
        }

        private void checkBoxDate_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePickerFrom.Enabled = checkBoxDate.Checked;
            dateTimePickerTo.Enabled = checkBoxDate.Checked;
        }

        private void checkBoxCriteria_CheckedChanged(object sender, EventArgs e)
        {
            textBoxCriteria.Enabled = checkBoxCriteria.Checked;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            List<Sales> sales = Sales.GetSales();
            DateTime from = Convert.ToDateTime(dateTimePickerFrom.Value.ToShortDateString());
            DateTime to = Convert.ToDateTime(dateTimePickerTo.Value.ToShortDateString());
            to = to.AddHours(23);
            to = to.AddMinutes(59);
            if (checkBoxCriteria.Checked)
            {
                if (checkBoxDate.Checked)
                {
                    
                    sales = sales.Where(x => x.Date <= to && x.Date >= from && (x.SalesPerson.ToLower() == textBoxCriteria.Text.ToLower() || 
                    x.Pump.ToLower() == textBoxCriteria.Text.ToLower() || x.Shift.ToLower() == textBoxCriteria.Text.ToLower() || 
                    x.Amount == Convert.ToDecimal(textBoxCriteria.Text) || x.Litres == Convert.ToDecimal(textBoxCriteria.Text))).ToList();
                    
                } else
                {
                    
                    sales = sales.Where(x => x.SalesPerson.ToLower() == textBoxCriteria.Text.ToLower() ||
                    x.Pump.ToLower() == textBoxCriteria.Text.ToLower() || x.Shift.ToLower() == textBoxCriteria.Text.ToLower() ||
                    x.Amount == Convert.ToDecimal(textBoxCriteria.Text) || x.Litres == Convert.ToDecimal(textBoxCriteria.Text)).ToList();
                    
                }
            } else if (checkBoxDate.Checked)
            {
                
                sales = sales.Where(x => x.Date <= to && x.Date >= from).ToList();

            }

            

            dataGridViewSales.DataSource = sales;
            GetSalesTotal();
        }

        private void GetSalesTotal()
        {
            decimal total = 0;
            decimal litre = 0;
            List<Sales> sales = (List<Sales>)dataGridViewSales.DataSource;
            foreach (Sales s in sales)
            {
                total += s.Amount;
                litre += s.Litres;
            }

            labelTotalSales.Text = total.ToString("N2");
            labelTotalLitre.Text = litre.ToString("N2");
        }
    }
}

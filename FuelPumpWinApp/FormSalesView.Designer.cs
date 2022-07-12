
namespace FuelPumpWinApp
{
    partial class FormSalesView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewSales = new System.Windows.Forms.DataGridView();
            this.checkBoxDate = new System.Windows.Forms.CheckBox();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.checkBoxCriteria = new System.Windows.Forms.CheckBox();
            this.textBoxCriteria = new System.Windows.Forms.TextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(704, 73);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sales Report";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewSales
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Honeydew;
            this.dataGridViewSales.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewSales.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSales.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewSales.Location = new System.Drawing.Point(0, 113);
            this.dataGridViewSales.Name = "dataGridViewSales";
            this.dataGridViewSales.RowTemplate.Height = 25;
            this.dataGridViewSales.Size = new System.Drawing.Size(704, 337);
            this.dataGridViewSales.TabIndex = 2;
            // 
            // checkBoxDate
            // 
            this.checkBoxDate.AutoSize = true;
            this.checkBoxDate.Location = new System.Drawing.Point(12, 85);
            this.checkBoxDate.Name = "checkBoxDate";
            this.checkBoxDate.Size = new System.Drawing.Size(66, 19);
            this.checkBoxDate.TabIndex = 3;
            this.checkBoxDate.Text = "By Date";
            this.checkBoxDate.UseVisualStyleBackColor = true;
            this.checkBoxDate.CheckedChanged += new System.EventHandler(this.checkBoxDate_CheckedChanged);
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Enabled = false;
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(84, 80);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(89, 23);
            this.dateTimePickerFrom.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "to";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Enabled = false;
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTo.Location = new System.Drawing.Point(203, 80);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(81, 23);
            this.dateTimePickerTo.TabIndex = 4;
            // 
            // checkBoxCriteria
            // 
            this.checkBoxCriteria.AutoSize = true;
            this.checkBoxCriteria.Location = new System.Drawing.Point(330, 85);
            this.checkBoxCriteria.Name = "checkBoxCriteria";
            this.checkBoxCriteria.Size = new System.Drawing.Size(80, 19);
            this.checkBoxCriteria.TabIndex = 3;
            this.checkBoxCriteria.Text = "By Criteria";
            this.checkBoxCriteria.UseVisualStyleBackColor = true;
            this.checkBoxCriteria.CheckedChanged += new System.EventHandler(this.checkBoxCriteria_CheckedChanged);
            // 
            // textBoxCriteria
            // 
            this.textBoxCriteria.Enabled = false;
            this.textBoxCriteria.Location = new System.Drawing.Point(416, 83);
            this.textBoxCriteria.Name = "textBoxCriteria";
            this.textBoxCriteria.Size = new System.Drawing.Size(211, 23);
            this.textBoxCriteria.TabIndex = 6;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.White;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.buttonSearch.Location = new System.Drawing.Point(633, 83);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(59, 23);
            this.buttonSearch.TabIndex = 7;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // FormSalesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(704, 450);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxCriteria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.checkBoxCriteria);
            this.Controls.Add(this.checkBoxDate);
            this.Controls.Add(this.dataGridViewSales);
            this.Controls.Add(this.label1);
            this.Name = "FormSalesView";
            this.Text = "Sales Report";
            this.Load += new System.EventHandler(this.FormSalesView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewSales;
        private System.Windows.Forms.CheckBox checkBoxDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.CheckBox checkBoxCriteria;
        private System.Windows.Forms.TextBox textBoxCriteria;
        private System.Windows.Forms.Button buttonSearch;
    }
}
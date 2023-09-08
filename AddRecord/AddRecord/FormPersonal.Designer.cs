
namespace AddRecord
{
    partial class FormPersonal
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
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_save2 = new System.Windows.Forms.Button();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txt_surname = new System.Windows.Forms.TextBox();
            this.txt_phone = new System.Windows.Forms.TextBox();
            this.txt_city = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_degree = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_salary = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button_clear = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_tc = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(20, 420);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(853, 263);
            this.dataGridView2.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "City:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "PhoneNo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Surname:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Name:";
            // 
            // button_save2
            // 
            this.button_save2.Location = new System.Drawing.Point(30, 356);
            this.button_save2.Name = "button_save2";
            this.button_save2.Size = new System.Drawing.Size(132, 38);
            this.button_save2.TabIndex = 23;
            this.button_save2.Text = "SAVE";
            this.button_save2.UseVisualStyleBackColor = true;
            this.button_save2.Click += new System.EventHandler(this.button_save2_Click);
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(100, 22);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(111, 20);
            this.txt_name.TabIndex = 15;
            // 
            // txt_surname
            // 
            this.txt_surname.Location = new System.Drawing.Point(100, 64);
            this.txt_surname.Name = "txt_surname";
            this.txt_surname.Size = new System.Drawing.Size(111, 20);
            this.txt_surname.TabIndex = 16;
            // 
            // txt_phone
            // 
            this.txt_phone.Location = new System.Drawing.Point(100, 182);
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.Size = new System.Drawing.Size(111, 20);
            this.txt_phone.TabIndex = 19;
            // 
            // txt_city
            // 
            this.txt_city.Location = new System.Drawing.Point(100, 265);
            this.txt_city.Name = "txt_city";
            this.txt_city.Size = new System.Drawing.Size(111, 20);
            this.txt_city.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "BirthDate:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Degree:";
            // 
            // txt_degree
            // 
            this.txt_degree.Location = new System.Drawing.Point(100, 225);
            this.txt_degree.Name = "txt_degree";
            this.txt_degree.Size = new System.Drawing.Size(111, 20);
            this.txt_degree.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 306);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Salary:";
            // 
            // txt_salary
            // 
            this.txt_salary.Location = new System.Drawing.Point(100, 306);
            this.txt_salary.Name = "txt_salary";
            this.txt_salary.Size = new System.Drawing.Size(111, 20);
            this.txt_salary.TabIndex = 22;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(100, 143);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(111, 20);
            this.dateTimePicker1.TabIndex = 18;
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(203, 356);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(132, 38);
            this.button_clear.TabIndex = 34;
            this.button_clear.Text = "CLEAR";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "TCNO:";
            // 
            // txt_tc
            // 
            this.txt_tc.Location = new System.Drawing.Point(100, 101);
            this.txt_tc.Name = "txt_tc";
            this.txt_tc.Size = new System.Drawing.Size(111, 20);
            this.txt_tc.TabIndex = 17;
            // 
            // FormPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 720);
            this.Controls.Add(this.txt_tc);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_salary);
            this.Controls.Add(this.txt_degree);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_save2);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.txt_surname);
            this.Controls.Add(this.txt_phone);
            this.Controls.Add(this.txt_city);
            this.Name = "FormPersonal";
            this.Text = "Personal";
            this.Load += new System.EventHandler(this.FormPersonal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_save2;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_surname;
        private System.Windows.Forms.TextBox txt_phone;
        private System.Windows.Forms.TextBox txt_city;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_degree;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_salary;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_tc;
    }
}
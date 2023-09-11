
namespace AddRecord
{
    partial class FormSelection
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button_rapor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(248, 100);
            this.button1.TabIndex = 0;
            this.button1.Text = "ÖĞRENCİ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(302, 109);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(248, 100);
            this.button2.TabIndex = 1;
            this.button2.Text = "ÖĞRETMEN";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(585, 109);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(248, 100);
            this.button3.TabIndex = 5;
            this.button3.Text = "DERSLER";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(861, 109);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(248, 100);
            this.button4.TabIndex = 6;
            this.button4.Text = "SINAVLAR";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button_rapor
            // 
            this.button_rapor.Location = new System.Drawing.Point(1152, 109);
            this.button_rapor.Name = "button_rapor";
            this.button_rapor.Size = new System.Drawing.Size(248, 100);
            this.button_rapor.TabIndex = 7;
            this.button_rapor.Text = "RAPORLAR";
            this.button_rapor.UseVisualStyleBackColor = true;
            this.button_rapor.Click += new System.EventHandler(this.button_rapor_Click);
            // 
            // FormSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1415, 350);
            this.Controls.Add(this.button_rapor);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.IsMdiContainer = true;
            this.Name = "FormSelection";
            this.Text = "FormSelection";
            this.Load += new System.EventHandler(this.FormSelection_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button_rapor;
    }
}
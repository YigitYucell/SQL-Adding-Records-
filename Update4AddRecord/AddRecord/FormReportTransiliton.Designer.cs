
namespace AddRecord
{
    partial class FormReportTransiliton
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
            this.button_ogrenci_rapor = new System.Windows.Forms.Button();
            this.button_ogretmen_rapor = new System.Windows.Forms.Button();
            this.button_sinav_rapor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_ogrenci_rapor
            // 
            this.button_ogrenci_rapor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_ogrenci_rapor.Location = new System.Drawing.Point(22, 101);
            this.button_ogrenci_rapor.Name = "button_ogrenci_rapor";
            this.button_ogrenci_rapor.Size = new System.Drawing.Size(287, 135);
            this.button_ogrenci_rapor.TabIndex = 0;
            this.button_ogrenci_rapor.Text = "Öğrenci Raporu";
            this.button_ogrenci_rapor.UseVisualStyleBackColor = true;
            this.button_ogrenci_rapor.Click += new System.EventHandler(this.button_ogrenci_rapor_Click);
            // 
            // button_ogretmen_rapor
            // 
            this.button_ogretmen_rapor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_ogretmen_rapor.Location = new System.Drawing.Point(460, 101);
            this.button_ogretmen_rapor.Name = "button_ogretmen_rapor";
            this.button_ogretmen_rapor.Size = new System.Drawing.Size(287, 135);
            this.button_ogretmen_rapor.TabIndex = 1;
            this.button_ogretmen_rapor.Text = "Öğretmen Raporu";
            this.button_ogretmen_rapor.UseVisualStyleBackColor = true;
            this.button_ogretmen_rapor.Click += new System.EventHandler(this.button_ogretmen_rapor_Click);
            // 
            // button_sinav_rapor
            // 
            this.button_sinav_rapor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_sinav_rapor.Location = new System.Drawing.Point(910, 101);
            this.button_sinav_rapor.Name = "button_sinav_rapor";
            this.button_sinav_rapor.Size = new System.Drawing.Size(287, 135);
            this.button_sinav_rapor.TabIndex = 2;
            this.button_sinav_rapor.Text = "Sınav Raporu";
            this.button_sinav_rapor.UseVisualStyleBackColor = true;
            this.button_sinav_rapor.Click += new System.EventHandler(this.button_sinav_rapor_Click);
            // 
            // FormReportTransiliton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 363);
            this.Controls.Add(this.button_sinav_rapor);
            this.Controls.Add(this.button_ogretmen_rapor);
            this.Controls.Add(this.button_ogrenci_rapor);
            this.Name = "FormReportTransiliton";
            this.Text = "FormReportTransiliton";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_ogrenci_rapor;
        private System.Windows.Forms.Button button_ogretmen_rapor;
        private System.Windows.Forms.Button button_sinav_rapor;
    }
}
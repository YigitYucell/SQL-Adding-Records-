using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddRecord
{
    public partial class FormReportTransiliton : Form
    {
        public FormReportTransiliton()
        {
            InitializeComponent();
        }

        private void button_ogrenci_rapor_Click(object sender, EventArgs e)
        {
            FormStudentReport srpt = new FormStudentReport();
            srpt.ShowDialog();
        }

        private void button_ogretmen_rapor_Click(object sender, EventArgs e)
        {
            FormTeacherReport trpt = new FormTeacherReport();
            trpt.ShowDialog();

        }

        private void button_sinav_rapor_Click(object sender, EventArgs e)
        {
            FormExamReport erpt = new FormExamReport();
            erpt.ShowDialog();
        }
    }
}

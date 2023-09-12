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
    public partial class FormSelection : Form
    {
        public FormSelection()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {

            
            FormStudent std = new FormStudent();
            std.ShowDialog();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            FormTeacher prs = new FormTeacher();
            prs.ShowDialog();
            

        }

        private void FormSelection_Load(object sender, EventArgs e)
        {

        }

        private void button_rapor_Click(object sender, EventArgs e)
        {
            FormReportTransiliton rpt = new FormReportTransiliton();
            rpt.ShowDialog();
        }

        private void button_lesson_Click(object sender, EventArgs e)
        {
            FormLesson lsn = new FormLesson();
            lsn.ShowDialog();
        }
    }
    
}

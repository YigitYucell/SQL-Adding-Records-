using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AddRecord
{
    public partial class FormSoruGiris : Form
    {

        public FormSoruGiris()
        {
            InitializeComponent();

        }
        int timer = 3000;
        int dogru = 0;
        int yanlis = 0;

        public void results(RadioButton selected)
        {
            if (selected.Checked == true)
            {
                dogru++;
                selected.BackColor = Color.Blue;
            }
            else
            {
                yanlis++;
            }

            lbldogrusayisi.Text = dogru.ToString();
            a.Text = yanlis.ToString();
        }

        public void gruptrue()
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
            groupBox4.Enabled = true;
            groupBox5.Enabled = true;
            groupBox6.Enabled = true;
            groupBox7.Enabled = true;
            groupBox8.Enabled = true;

        }

        public void grupfalse()
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;
            groupBox6.Enabled = false;
            groupBox7.Enabled = false;
            groupBox8.Enabled = false;
        }
        private void FormSoruGiris_Load(object sender, EventArgs e)
        {
            grupfalse();

        }

        private void button_next_Click_1(object sender, EventArgs e)
        {
            FormSoruGiris2 sr2 = new FormSoruGiris2();
            sr2.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer--;
            lbltime.Text = timer.ToString();

            if (timer == 0)
            {
                timer1.Enabled = false;
                grupfalse();

                MessageBox.Show("Süre Doldu");
                btnstart.Enabled = false;
                btnfinish.Enabled = false;

                results(radioButton15);
                results(radioButton2);
                results(radioButton7);
                results(radioButton19);
                results(radioButton34);
                results(radioButton23);
                results(radioButton25);
                results(radioButton29);
            }
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            if ((txt_tc.Text == "") || (txt_adsoyad.Text == ""))
            {
                MessageBox.Show("Lütden alanları doldurunuz.");
            }
            else if (txt_tc.Text.Length != 11)
            {
                MessageBox.Show("TC no 11 hane olmalıdır.");
            }
            else
            {
                timer1.Enabled = true;
                gruptrue();
                lbltcno.Text = txt_tc.Text;
                lbladsoyad.Text = txt_adsoyad.Text;
                btnstart.Enabled = false;
            }
        }

        private void btnfinish_Click(object sender, EventArgs e)
        {
            grupfalse();
            btnfinish.Enabled = false;
            timer1.Enabled = false;

            results(radioButton15);
            results(radioButton2);
            results(radioButton7);
            results(radioButton19);
            results(radioButton34);
            results(radioButton23);
            results(radioButton25);
            results(radioButton29);
        }
    }
}

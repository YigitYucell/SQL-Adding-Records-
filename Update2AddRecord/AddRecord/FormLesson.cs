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
    public partial class FormLesson : Form
    {
        public FormLesson()
        {
            InitializeComponent();
        }
        static string constring = "Data Source=DESKTOP-D0IQCCP\\SQLEXPRESS;Initial Catalog = school; Integrated Security = True";
        SqlConnection connect = new SqlConnection(constring);

        public void kayitlari_getir()
        {

            string getir = "select * from Lesson";
            SqlCommand komut = new SqlCommand(getir, connect);
            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void FormLesson_Load(object sender, EventArgs e)
        {
            kayitlari_getir();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            txt_dersad.Clear();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txt_dersad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            
        }

        private void button_update_Click(object sender, EventArgs e)
        {

        }
    }
}

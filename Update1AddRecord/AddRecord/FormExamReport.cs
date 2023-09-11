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
    public partial class FormExamReport : Form
    {
        public FormExamReport()
        {
            InitializeComponent();
        }
        static string constring = "Data Source=DESKTOP-D0IQCCP\\SQLEXPRESS;Initial Catalog = school; Integrated Security = True";
        SqlConnection connect = new SqlConnection(constring);

        public void kayitlari_getir()
        {

            string getir = "select * from StudentLesson";
            SqlCommand komut = new SqlCommand(getir, connect);
            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void FormExamReport_Load(object sender, EventArgs e)
        {
            kayitlari_getir();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                string register = "insert into TeacherReport (Studentıd,Lessonıd,Exam1,Exam2,Exam3) values(@Studentıd,@Lessonıd,@Exam1,@Exam2,@Exam3)";
                SqlCommand command = new SqlCommand(register, connect);

                command.Parameters.AddWithValue("@Studentıd", txt_ogrıd.Text);
                command.Parameters.AddWithValue("@Lessonıd", txt_dersıd.Text);
                command.Parameters.AddWithValue("@Exam1", txt_sinav1.Text);
                command.Parameters.AddWithValue("@Exam2", txt_sinav2.Text);
                command.Parameters.AddWithValue("@Exam3", txt_sinav3.Text);

                command.ExecuteNonQuery();
                kayitlari_getir();
                connect.Close();
                MessageBox.Show("Kayıt eklendi");


            }
            catch (Exception error)
            {

                MessageBox.Show("hata meydana geldi " + error.Message);

            }
        }
        private void button_delete_Click(object sender, EventArgs e)
        {
            txt_ogrıd.Clear();
            txt_dersıd.Clear();
            txt_sinav1.Clear();
            txt_sinav2.Clear();
            txt_sinav3.Clear();
        }

        private void button_update_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txt_ogrıd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_dersıd.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_sinav1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_sinav2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_sinav3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

        }
    }
}

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

                string register = "insert into TeacherReport (Studentıd,Lessonıd,Exam1,Exam2,Exam3,CreatedUserName,ModifiedUserName,CreatedTime,ModifiedTime) values(@Studentıd,@Lessonıd,@Exam1,@Exam2,@Exam3,@CreatedUserName,@ModifiedUserName,@CreatedTime,@ModifiedTime)";
                SqlCommand command = new SqlCommand(register, connect);

                
                command.Parameters.AddWithValue("@Exam1", txt_sinav1.Text);
                command.Parameters.AddWithValue("@Exam2", txt_sinav2.Text);
                command.Parameters.AddWithValue("@Exam3", txt_sinav3.Text);
                command.Parameters.AddWithValue("@CreatedUserName", txt_kullaniciadi.Text);
                command.Parameters.AddWithValue("@ModifiedUserName", txt_guncelkullaniciadi.Text);
                command.Parameters.AddWithValue("@CreatedTime", Convert.ToDateTime(dateTimePicker1.Text));
                command.Parameters.AddWithValue("@ModifiedTime", Convert.ToDateTime(dateTimePicker3.Text));

                Dictionary<string, int> nvarcharToIntMapping = new Dictionary<string, int>
                {
                    { "Economics", 1 },
                    { "Physics", 2 },
                    { "History", 3 },
                    { "Maths", 4 },
                    { "Sociology", 5 }
                };

                if (nvarcharToIntMapping.ContainsKey(comboBox1.Text))
                {
                    int selectedStudentıd = nvarcharToIntMapping[comboBox1.Text];
                    command.Parameters.AddWithValue("@Studentıd", selectedStudentıd);
                }
                else
                {
                    Console.WriteLine("Eşleşen bir int değeri bulunamadı.");
                }

                Dictionary<string, int> nvarcharToIntMapping2 = new Dictionary<string, int>
                {
                    { "Yiğit", 1 },
                    { "Ali", 2 },
                    { "Burak", 3 },
                    { "Berk", 4 },
                    { "Barış", 5 }
                };

                if (nvarcharToIntMapping2.ContainsKey(comboBox2.Text))
                {
                    int selectedLessonıd = nvarcharToIntMapping2[comboBox2.Text];
                    command.Parameters.AddWithValue("@Lessonıd", selectedLessonıd);
                }
                else
                {
                    Console.WriteLine("Eşleşen bir int değeri bulunamadı.");
                }


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
            
            txt_sinav1.Clear();
            txt_sinav2.Clear();
            txt_sinav3.Clear();
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Sadece seçilen satırı güncelle
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    int selectedStudentLessonID = Convert.ToInt32(selectedRow.Cells["StudentLessonID"].Value); // Örnek olarak StudentLessonID kullanıldı, sizin tablonuzdaki benzersiz kimlik alanını kullanmalısınız


                    string updateQuery = "UPDATE StudentLesson SET Studentıd = @Studentıd, Lessonıd = @Lessonıd, Exam1 = @Exam1 , Exam2 = @Exam2, Exam3 = @Exam3 WHERE StudentLessonID = @StudentLessonID";
                    SqlCommand command = new SqlCommand(updateQuery, connect);

                    command.Parameters.AddWithValue("@Studentıd", comboBox1.SelectedValue); // ComboBox'tan gelen öğrenci ID'sini kullanarak güncelleme
                    command.Parameters.AddWithValue("@Lessonıd", comboBox2.SelectedValue); // ComboBox'tan gelen ders ID'sini kullanarak güncelleme
                    command.Parameters.AddWithValue("@Exam1", txt_sinav1.Text);
                    command.Parameters.AddWithValue("@Exam2", txt_sinav2.Text);
                    command.Parameters.AddWithValue("@Exam3", txt_sinav3.Text);
                    command.Parameters.AddWithValue("@StudentLessonID", selectedStudentLessonID); // Güncellenecek kaydın benzersiz kimlik numarası

                    command.ExecuteNonQuery();
                    kayitlari_getir();
                    connect.Close();
                    MessageBox.Show("Kayıt güncellendi");
                }
                else
                {
                    MessageBox.Show("Güncellenecek bir kayıt seçilmedi.");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Hata meydana geldi: " + error.Message);
            }

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //txt_ogrıd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            //txt_dersıd.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_sinav1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_sinav2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_sinav3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

        }

        
    }
}

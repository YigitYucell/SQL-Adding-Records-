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
    public partial class FormTeacher : Form 
    {
        public FormTeacher()
        {
            InitializeComponent();
        }
        static string constring = "Data Source=DESKTOP-D0IQCCP\\SQLEXPRESS;Initial Catalog = school; Integrated Security = True";
        SqlConnection connect = new SqlConnection(constring);

        public void kayitlari_getir()
        {

            string getir = "select * from Teacher";
            SqlCommand komut = new SqlCommand(getir, connect);
            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView2.DataSource = dt;

        }




        private void button_save2_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                string tcNumber = txt_tc.Text;

                if (tcNumber.Length != 11 || !IsNumeric(tcNumber))
                {
                    MessageBox.Show("Geçerli bir TC kimlik numarası giriniz.");
                    return;
                }

                string register = "insert into Personal (Name,Surname,TCNO,BirthDate,PhoneNo,Degree,City,Salary,CreatedUserName,ModifiedUserName,CreatedTime,ModifiedTime) values(@Name,@Surname,@TCNO,@BirthDate,@PhoneNo,@Degree,@City,@Salary,@CreatedUserName,@ModifiedUserName,@CreatedTime,@ModifiedTime)";
                SqlCommand command = new SqlCommand(register, connect);

                
                command.Parameters.AddWithValue("@Name", txt_name.Text);
                command.Parameters.AddWithValue("@Surname", txt_surname.Text);
                command.Parameters.AddWithValue("@TCNO", txt_tc.Text);
                command.Parameters.AddWithValue("@BirthDate",Convert.ToDateTime (dateTimePicker1.Text));
                command.Parameters.AddWithValue("@PhoneNo", txt_phone.Text);
                command.Parameters.AddWithValue("@Degree", txt_degree.Text);
                command.Parameters.AddWithValue("@City", txt_city.Text);
                command.Parameters.AddWithValue("@Salary", txt_salary.Text);
                command.Parameters.AddWithValue("@CreatedUserName", txt_kullaniciadi.Text);
                command.Parameters.AddWithValue("@ModifiedUserName", txt_guncelkullaniciadi.Text);
                command.Parameters.AddWithValue("@CreatedTime", Convert.ToDateTime(dateTimePicker2.Text));
                command.Parameters.AddWithValue("@ModifiedTime", Convert.ToDateTime(dateTimePicker3.Text));

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
        private void FormPersonal_Load(object sender, EventArgs e)

        {
            kayitlari_getir();
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            txt_name.Clear();
            txt_surname.Clear();
            txt_tc.Clear();
            txt_phone.Clear();
            txt_degree.Clear();
            txt_city.Clear();
            txt_salary.Clear();
            
        }
        private bool IsNumeric(string text)
        {
            return text.All(char.IsDigit);
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txt_name.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            txt_surname.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            txt_tc.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            txt_phone.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            txt_degree.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            txt_city.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
            txt_salary.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();

        }

        private void button_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                if (dataGridView2.SelectedRows.Count > 0)
                {
                    // Sadece seçilen satırı güncelle
                    DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];

                    int selectedTeacherID = Convert.ToInt32(selectedRow.Cells["TeacherID"].Value); 

                    string updateQuery = "UPDATE Teacher SET Name = @Name, Surname = @Surname, TCNO = @TCNO, BirthDate = @BirthDate, PhoneNo = @PhoneNo, Degree = @Degree, City = @City, Salary = @Salary, CreatedUserName = @CreatedUserName, ModifiedUserName = @ModifiedUserName, CreatedTime = @CreatedTime, ModifiedTime = @ModifiedTime WHERE TeacherID = @TeacherID";
                    SqlCommand command = new SqlCommand(updateQuery, connect);

                    command.Parameters.AddWithValue("@Name", txt_name.Text);
                    command.Parameters.AddWithValue("@Surname", txt_surname.Text);
                    command.Parameters.AddWithValue("@TCNO", txt_tc.Text);
                    command.Parameters.AddWithValue("@BirthDate", Convert.ToDateTime(dateTimePicker1.Text));
                    command.Parameters.AddWithValue("@PhoneNo", txt_phone.Text);
                    command.Parameters.AddWithValue("@Degree", txt_degree.Text);
                    command.Parameters.AddWithValue("@City", txt_city.Text);
                    command.Parameters.AddWithValue("@Salary", txt_salary.Text);
                    command.Parameters.AddWithValue("@CreatedUserName", txt_kullaniciadi.Text);
                    command.Parameters.AddWithValue("@ModifiedUserName", txt_guncelkullaniciadi.Text);
                    command.Parameters.AddWithValue("@CreatedTime", Convert.ToDateTime(dateTimePicker2.Text));
                    command.Parameters.AddWithValue("@ModifiedTime", Convert.ToDateTime(dateTimePicker3.Text));
                    command.Parameters.AddWithValue("@TeacherID", selectedTeacherID); // Güncellenecek kaydın benzersiz kimlik numarası

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
    }
    
}

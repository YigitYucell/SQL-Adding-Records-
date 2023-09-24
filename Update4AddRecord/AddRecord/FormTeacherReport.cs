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
    public partial class FormTeacherReport : Form
    {
        public FormTeacherReport()
        {
            InitializeComponent();
        }
        static string constring = "Data Source=DESKTOP-D0IQCCP\\SQLEXPRESS;Initial Catalog = school; Integrated Security = True";
        SqlConnection connect = new SqlConnection(constring);

        public void kayitlari_getir()
        {
            string getir = "SELECT * FROM Teacher WHERE IsDeleted = 0";
            //string getir = "select * from TeacherReport";
            SqlCommand komut = new SqlCommand(getir, connect);
            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView2.DataSource = dt;

        }

        private void FormTeacherReport_Load(object sender, EventArgs e)
        {
            kayitlari_getir();
        }
        /*private void button_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                string register = "insert into Teacher (Name,Surname,Lessons,IsActive,IsDeleted) values(@Name,@Surname,@Lessons,@IsActive,@IsDeleted)";
                SqlCommand command = new SqlCommand(register, connect);

                command.Parameters.AddWithValue("@Name", txt_name.Text);
                command.Parameters.AddWithValue("@Surname", txt_surname.Text);
                command.Parameters.AddWithValue("@Lessons", txt_lesson.Text);

                bool isActive = comboBox2.Text == "Evet" ? true : false;
                command.Parameters.AddWithValue("@IsActive", isActive);

                bool isDeleted = comboBox1.Text == "Evet" ? true : false;
                command.Parameters.AddWithValue("@IsDeleted", isDeleted);

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

        private void button_clear_Click(object sender, EventArgs e)
        {
            txt_name.Clear();
            txt_surname.Clear();
            txt_lesson.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txt_name.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            txt_surname.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            txt_lesson.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            comboBox2.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            comboBox1.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
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

                    // Seçili satırın TeacherID değerini alabilirsiniz
                    int selectedTeacherID = Convert.ToInt32(selectedRow.Cells["TeacherID"].Value);

                    string updateQuery = "UPDATE Teacher SET Name = @Name, Surname = @Surname, Lessons = @Lessons, IsActive = @IsActive, IsDeleted = @IsDeleted WHERE TeacherID = @TeacherID";
                    SqlCommand command = new SqlCommand(updateQuery, connect);

                    command.Parameters.AddWithValue("@Name", txt_name.Text);
                    command.Parameters.AddWithValue("@Surname", txt_surname.Text);
                    command.Parameters.AddWithValue("@Lessons", txt_lesson.Text);
                    command.Parameters.AddWithValue("@TeacherID", selectedTeacherID); // Seçilen öğretmenin ID'si

                    bool isActive = comboBox2.Text == "Evet" ? true : false;
                    command.Parameters.AddWithValue("@IsActive", isActive);

                    bool isDeleted = comboBox1.Text == "Evet" ? true : false;
                    command.Parameters.AddWithValue("@IsDeleted", isDeleted);

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

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Seçili kaydı silmek istediğinizden emin misiniz?", "Kayıt Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (connect.State == ConnectionState.Closed)
                            connect.Open();

                        DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
                        int selectedTeacherID = Convert.ToInt32(selectedRow.Cells["TeacherID"].Value);

                        // Önce öğrenciyi pasif yap
                        string deactivateQuery = "UPDATE TeacherReport SET IsActive = @IsActive WHERE TeacherID = @TeacherID";
                        SqlCommand deactivateCommand = new SqlCommand(deactivateQuery, connect);
                        deactivateCommand.Parameters.AddWithValue("@TeacherID", selectedTeacherID);
                        deactivateCommand.Parameters.AddWithValue("@IsActive", false);
                        deactivateCommand.ExecuteNonQuery();

                        // Sonra öğrenciyi sil (IsDeleted=True)
                        string deleteQuery = "UPDATE TeacherReport SET IsDeleted = @IsDeleted WHERE TeacherID = @TeacherID";
                        SqlCommand deleteCommand = new SqlCommand(deleteQuery, connect);
                        deleteCommand.Parameters.AddWithValue("@TeacherID", selectedTeacherID);
                        deleteCommand.Parameters.AddWithValue("@IsDeleted", true);
                        deleteCommand.ExecuteNonQuery();

                        connect.Close();
                        kayitlari_getir();
                        MessageBox.Show("Kayıt silindi");
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Hata meydana geldi: " + error.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Silinecek bir kayıt seçilmedi");
            }
        }*/
    }
}

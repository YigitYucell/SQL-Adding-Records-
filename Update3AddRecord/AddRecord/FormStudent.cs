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
    public partial class FormStudent : Form
    {
        public FormStudent()
        {
            InitializeComponent();
        }
        static string constring = "Data Source=DESKTOP-D0IQCCP\\SQLEXPRESS;Initial Catalog = school; Integrated Security = True";
        SqlConnection connect = new SqlConnection(constring);

        public void kayitlari_getir()
        {
            string getir = "SELECT * FROM Student WHERE IsDeleted = 0";
            //string getir = "select * from Student";
            SqlCommand komut = new SqlCommand(getir, connect);
            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            
        }

        private void button_save_Click(object sender, EventArgs e)
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

                if(dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    int selectedStudentID = Convert.ToInt32(selectedRow.Cells["StudentID"].Value);
                    
                    string register = "insert into Student (Name,Surname,TCNO,BirthDate,PhoneNo,City,DepartmentID,IsActive,IsDeleted) values(@Name,@Surname,@TCNO,@BirthDate,@PhoneNo,@City,@DepartmentID,@IsActive,@IsDeleted)";
                    SqlCommand command = new SqlCommand(register, connect);

                    command.Parameters.AddWithValue("@Name", txt_name.Text);
                    command.Parameters.AddWithValue("@Surname", txt_surname.Text);
                    command.Parameters.AddWithValue("@TCNO", txt_tc.Text);
                    command.Parameters.AddWithValue("@BirthDate", Convert.ToDateTime(dateTimePicker2.Text));
                    command.Parameters.AddWithValue("@PhoneNo", txt_phone.Text);
                    command.Parameters.AddWithValue("@City", txt_city.Text);




                    Dictionary<string, int> nvarcharToIntMapping = new Dictionary<string, int>
                {
                    { "Engineer", 1 },
                    { "Economics", 2 },
                    { "Physics", 3 },
                    { "History", 4 },
                    { "Sociology", 5 },
                    { "Biology", 6 }
                };

                    if (nvarcharToIntMapping.ContainsValue(Convert.ToInt32(comboBox1.Text)))
                    {
                        command.Parameters.AddWithValue("@DepartmentID", Convert.ToInt32(comboBox1.Text));
                    }
                    else
                    {
                        Console.WriteLine("Eşleşen bir int değeri bulunamadı.");
                    }

                    bool isActive = comboBox2.Text == "Evet" ? true : false;
                    command.Parameters.AddWithValue("@IsActive", isActive);

                    bool isDeleted = comboBox3.Text == "Evet" ? true : false;
                    command.Parameters.AddWithValue("@IsDeleted", isDeleted);

                    command.ExecuteNonQuery();
                    kayitlari_getir();
                    connect.Close();
                    MessageBox.Show("Kayıt eklendi");

                }
                else
                {
                    MessageBox.Show("Eklenecek bir kayıt seçilmedi");
                }

            }
            catch (Exception error)
            {

                MessageBox.Show("hata meydana geldi " + error.Message);

            }

        }

        private void Student_Load(object sender, EventArgs e)
        {
            
            kayitlari_getir();
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            txt_name.Clear();
            txt_surname.Clear();
            txt_tc.Clear();
            txt_phone.Clear();
            txt_city.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;

            dateTimePicker2.Value = DateTimePicker.MinimumDateTime;
        }

        private bool IsNumeric(string text)
        {
            return text.All(char.IsDigit);
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txt_name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_surname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_tc.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_phone.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txt_city.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Geçerli bir hücre seçilmiş mi kontrolü
            {
                // DataGridView'da seçilen hücrenin değerini alın
                object cellValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                // Eğer hücre değeri DateTime türünde bir değerse, DateTimePicker'a ayarlayın
                if (cellValue != null && cellValue != DBNull.Value && cellValue is DateTime)
                {
                    dateTimePicker2.Value = (DateTime)cellValue;
                }
            }


        }

        private void button_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();
                if(dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    int selectedStudentID = Convert.ToInt32(selectedRow.Cells["StudentID"].Value);
                    string updateQuery = "UPDATE Student SET Name = @Name, Surname = @Surname, TCNO = @TCNO, BirthDate = @BirthDate, PhoneNo = @PhoneNo, City = @City, DepartmentID = @DepartmentID, IsActive = @IsActive, IsDeleted = @IsDeleted WHERE StudentID = @StudentID";
                    SqlCommand command = new SqlCommand(updateQuery, connect);

                    command.Parameters.AddWithValue("@Name", txt_name.Text);
                    command.Parameters.AddWithValue("@Surname", txt_surname.Text);
                    command.Parameters.AddWithValue("@TCNO", txt_tc.Text);
                    command.Parameters.AddWithValue("@BirthDate", Convert.ToDateTime(dateTimePicker2.Text));
                    command.Parameters.AddWithValue("@PhoneNo", txt_phone.Text);
                    command.Parameters.AddWithValue("@City", txt_city.Text);
                    command.Parameters.AddWithValue("@StudentID", selectedStudentID); 

                    Dictionary<string, int> nvarcharToIntMapping = new Dictionary<string,int>
                    {
                        { "Engineer", 1 },
                        { "Economics", 2 },
                        { "Physics", 3 },
                        { "History", 4 },
                        { "Sociology", 5 },
                        { "Biology", 6 }
                    };

                    if(nvarcharToIntMapping.ContainsValue(Convert.ToInt32(comboBox1.Text)))
                    {
                        command.Parameters.AddWithValue("@DepartmentID", Convert.ToInt32(comboBox1.Text));
                    }
                    else
                    {
                        Console.WriteLine("Eşleşen bir int değeri bulunamadı.");
                    }

                    bool isActive = comboBox2.Text == "Evet" ? true : false;
                    command.Parameters.AddWithValue("@IsActive", isActive);

                    bool isDeleted = comboBox3.Text == "Evet" ? true : false;
                    command.Parameters.AddWithValue("@IsDeleted", isDeleted);

                    command.ExecuteNonQuery();
                    kayitlari_getir();
                    connect.Close();
                    MessageBox.Show("Kayıtlar güncellendi");
                }
                else
                {
                    MessageBox.Show("Güncellenecek bir kayıt seçilmedi");
                }


            }
            catch (Exception error)
            {

                MessageBox.Show("Hata meydana geldi:" + error.Message);
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Seçili kaydı silmek istediğinizden emin misiniz?", "Kayıt Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (connect.State == ConnectionState.Closed)
                            connect.Open();

                        DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                        int selectedStudentID = Convert.ToInt32(selectedRow.Cells["StudentID"].Value);

                        // Önce öğrenciyi pasif yap
                        string deactivateQuery = "UPDATE Student SET IsActive = @IsActive WHERE StudentID = @StudentID";
                        SqlCommand deactivateCommand = new SqlCommand(deactivateQuery, connect);
                        deactivateCommand.Parameters.AddWithValue("@StudentID", selectedStudentID);
                        deactivateCommand.Parameters.AddWithValue("@IsActive", false);
                        deactivateCommand.ExecuteNonQuery();

                        // Sonra öğrenciyi sil (IsDeleted=True)
                        string deleteQuery = "UPDATE Student SET IsDeleted = @IsDeleted WHERE StudentID = @StudentID";
                        SqlCommand deleteCommand = new SqlCommand(deleteQuery, connect);
                        deleteCommand.Parameters.AddWithValue("@StudentID", selectedStudentID);
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
        }
    }
}

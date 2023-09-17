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

            string getir = "SELECT * FROM Student WHERE IsDeleted = 0";
            //string getir = "select * from Lesson";
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

        private void button_clear_Click(object sender, EventArgs e)
        {
            txt_dersad.Clear();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txt_dersad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    if (connect.State == ConnectionState.Closed)
                        connect.Open();

                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    int selectedLessonID = Convert.ToInt32(selectedRow.Cells["LessonID"].Value);

                    string updateQuery = "UPDATE Lesson SET LessonName = @LessonName, Exam1Date = @Exam1Date, Exam2Date = @Exam2Date, Exam3Date = @Exam3Date WHERE LessonID = @LessonID";
                    SqlCommand command = new SqlCommand(updateQuery, connect);

                    command.Parameters.AddWithValue("@LessonName", txt_dersad.Text);
                    command.Parameters.AddWithValue("@Exam1Date", Convert.ToDateTime(dateTimePicker1.Text));
                    command.Parameters.AddWithValue("@Exam2Date", Convert.ToDateTime(dateTimePicker2.Text));
                    command.Parameters.AddWithValue("@Exam3Date", Convert.ToDateTime(dateTimePicker3.Text));
                    command.Parameters.AddWithValue("@LessonID", selectedLessonID);

                    command.ExecuteNonQuery();

                    connect.Close();
                    kayitlari_getir();
                    MessageBox.Show("Kayıt güncellendi");
                }
                catch (Exception error)
                {
                    MessageBox.Show("Hata meydana geldi: " + error.Message);
                }
            }
            else
            {
                MessageBox.Show("Güncellenecek bir kayıt seçilmedi");
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                try
                {
                    if (connect.State == ConnectionState.Closed)
                        connect.Open();

                    int selectedColumnIndex = dataGridView1.SelectedCells[0].ColumnIndex;
                    string columnName = dataGridView1.Columns[selectedColumnIndex].Name;

                    // Sütun adını kullanarak kaydı silme sorgusunu oluşturun
                    string deleteQuery = "DELETE FROM Lesson WHERE " + columnName + " = @ValueToDelete";
                    SqlCommand command = new SqlCommand(deleteQuery, connect);

                    // Sütunun değerini alın
                    string valueToDelete = dataGridView1.CurrentCell.Value.ToString();
                    command.Parameters.AddWithValue("@ValueToDelete", valueToDelete);

                    command.ExecuteNonQuery();

                    connect.Close();
                    kayitlari_getir();
                    MessageBox.Show("Seçili sütun silindi");
                }
                catch (Exception error)
                {
                    MessageBox.Show("Hata meydana geldi: " + error.Message);
                }
            }
            else
            {
                MessageBox.Show("Silinecek bir sütun seçilmedi");
            }
        }

        private void button_clear_Click_1(object sender, EventArgs e)
        {
            txt_dersad.Clear();
            dateTimePicker1.Value = DateTimePicker.MinimumDateTime;
            dateTimePicker2.Value = DateTimePicker.MinimumDateTime;
            dateTimePicker3.Value = DateTimePicker.MinimumDateTime;
        }
    }
}

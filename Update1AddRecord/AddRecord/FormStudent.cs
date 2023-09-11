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
            
            string getir = "select * from Student";
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

                string register = "insert into Student (Name,Surname,TCNO,BirthDate,PhoneNo,City,DepartmentID) values(@Name,@Surname,@TCNO,@BirthDate,@PhoneNo,@City,@DepartmentID)";
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

                if (nvarcharToIntMapping.ContainsKey(comboBox1.Text))
                {
                    int selectedDepartmentID = nvarcharToIntMapping[comboBox1.Text];
                    command.Parameters.AddWithValue("@DepartmentID", selectedDepartmentID);
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

        }

        private bool IsNumeric(string text)
        {
            return text.All(char.IsDigit);
        }
    }
}

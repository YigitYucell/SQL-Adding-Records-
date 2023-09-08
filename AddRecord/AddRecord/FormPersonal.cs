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
    public partial class FormPersonal : Form //FormSelection
    {
        public FormPersonal()
        {
            InitializeComponent();
        }
        static string constring = "Data Source=DESKTOP-D0IQCCP\\SQLEXPRESS;Initial Catalog = school; Integrated Security = True";
        SqlConnection connect = new SqlConnection(constring);

        public void kayitlari_getir()
        {

            string getir = "select * from Personal";
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

                string register = "insert into Personal (Name,Surname,TCNO,BirthDate,PhoneNo,Degree,City,Salary) values(@Name,@Surname,@TCNO,@BirthDate,@PhoneNo,@Degree,@City,@Salary)";
                SqlCommand command = new SqlCommand(register, connect);

                
                command.Parameters.AddWithValue("@Name", txt_name.Text);
                command.Parameters.AddWithValue("@Surname", txt_surname.Text);
                command.Parameters.AddWithValue("@TCNO", txt_tc.Text);
                command.Parameters.AddWithValue("@BirthDate",Convert.ToDateTime (dateTimePicker1.Text));
                command.Parameters.AddWithValue("@PhoneNo", txt_phone.Text);
                command.Parameters.AddWithValue("@Degree", txt_degree.Text);
                command.Parameters.AddWithValue("@City", txt_city.Text);
                command.Parameters.AddWithValue("@Salary", txt_salary.Text);

                
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

    }
    
}

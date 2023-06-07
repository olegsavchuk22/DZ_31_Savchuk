using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DZ_31_Savchuk
{
    public partial class Form1 : Form
    {
        private SqlDataAdapter dataAdapter = null;
        private DataSet dataSet = null;
        string connString;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection())
                {
                    connString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
                    connection.ConnectionString = connString;
                    string query = "SELECT * FROM Students";

                    dataAdapter = new SqlDataAdapter(query, connection);

                    dataSet = new DataSet();

                    dataAdapter.Fill(dataSet, "Students");

                    listBox1.DataSource = dataSet.Tables["Students"];
                    listBox1.DisplayMember = "Name";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Опаньки... помилка\nШуруй шукати, де вона)\n" + ex.Message);
            }
        }
        private void listBox1_Click(object sender, EventArgs e)
        {
            DataRowView selectedRow = listBox1.SelectedItem as DataRowView;

            int studentId = Convert.ToInt32(selectedRow["id"]);

            MessageBox.Show($"Код студента: {studentId}");
        }
    }
}

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

namespace ATMuto
{
    public partial class ChangePIN : Form
    {
        public ChangePIN()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Poonam\Documents\ATMdb.mdf;Integrated Security=True;Connect Timeout=30");
        string Acc = login.AccNumber;
        private void label4_Click(object sender, EventArgs e)
        {
            thanks thanks = new thanks();
            thanks.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            if (pin1tb.Text == " " || pin2tb.Text == " ")
            {
                MessageBox.Show("Enter and confirm the new pin");
            }
            else if(pin2tb.Text != pin1tb.Text )
            {
                MessageBox.Show("PIN 1 and PIN 2 are different , please confirm the pin");
            }
            else
            {
                string Acc = login.AccNumber;
                //newbalance = oldbalance + Convert.ToInt32(DepoAmtTb.Text);
                try
                {
                    Con.Open();
                    string query = "update AccountTb1 set pintbl=" + pin1tb.Text + "where AccNumTbl='" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("PIN Updated Successfully");
                    Con.Close();
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void ChangePIN_Load(object sender, EventArgs e)
        {

        }
    }
}

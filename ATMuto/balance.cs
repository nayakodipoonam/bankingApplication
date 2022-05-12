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
    public partial class balance : Form
    {
        public balance()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Poonam\Documents\ATMdb.mdf;Integrated Security=True;Connect Timeout=30");
        private void getbalance()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select balanceTbl from AccountTb1 where AccNumTbl ='" + AccNumTbl.Text + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);  
            balancetbl.Text = "Rs " + dt.Rows[0][0].ToString();
            Con.Close(); 
        }
        private void balance_Load(object sender, EventArgs e)
        {
            AccNumTbl.Text = Home.AccNumber;
            getbalance();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            thanks thanks = new thanks();
            thanks.Show();
            this.Hide();


        }

        private void balancetbl_Click(object sender, EventArgs e)
        {

        }
    }
}

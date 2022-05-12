using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMuto
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            account acc = new account();
            acc.Show();
            this.Hide();
        }
        public static String AccNumber;
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Poonam\Documents\ATMdb.mdf;Integrated Security=True;Connect Timeout=30");
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from AccountTb1 where AccNumTbl ='" + AccNumTbl.Text + "' and pintbl =" + pintbl.Text + "", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (AccNumTbl.Text == "" || pintbl.Text == "")
            {
                MessageBox.Show("Missing Information");

            }
            else if(dt.Rows[0][0].ToString() == "1")
            {
                AccNumber = AccNumTbl.Text;
                Home home = new Home();
                home.Show();
                this.Hide();
                Con.Close();
            }else
            {
                MessageBox.Show("Please Enter valid account number or PIN");
            }
            Con.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            thanks thanks = new thanks();
            thanks.Show();
            this.Hide();

        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}

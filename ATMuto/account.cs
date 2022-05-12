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
    public partial class account : Form
    {
        public account()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Poonam\Documents\ATMdb.mdf;Integrated Security=True;Connect Timeout=30");
        private void Label6_Click(object sender, EventArgs e)
        {
            
        }

        internal static void show()
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click()
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            int bal = 0;
            if (AccNametbl.Text == "" || AccNumTbl.Text == "" || FanameTbl.Text == ""  || PhoneTbl.Text == "" || Addresstbl.Text == "" || pintbl.Text == "")
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into AccountTb1 values('" + AccNumTbl.Text + "','" + AccNametbl.Text + "','" + FanameTbl.Text + "','" + dobdatel.Value.Date + "','" + PhoneTbl.Text + "','" + Addresstbl.Text + "','" + pintbl.Text + "','" + bal + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account Created Successfully");
                    Con.Close();
                    login log = new login();
                    log.Show();
                    this.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label20_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();
        }

        private void label21_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label21_Click_1(object sender, EventArgs e)
        {
            thanks thanks = new thanks();
            thanks.Show();
            this.Hide();
        }

        private void account_Load(object sender, EventArgs e)
        {

        }
    }
}

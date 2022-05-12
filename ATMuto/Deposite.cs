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
    public partial class Deposite : Form
    {
        public Deposite()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Poonam\Documents\ATMdb.mdf;Integrated Security=True;Connect Timeout=30");
        string Acc = login.AccNumber;
        private void label2_Click(object sender, EventArgs e)
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
        private void addtransaction()
        {
            string TrType = "Deposit";
            try
            {
                Con.Open();
                string query = "insert into TransactionTbl values('" + Acc + "','" + TrType + "','" + DepoAmtTb.Text + "','" + DateTime.Today.Date.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                
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
        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            if(DepoAmtTb.Text == " " || Convert.ToInt32(DepoAmtTb.Text) <=0)
            {
                MessageBox.Show("Enter the amount to deposit");
            }
            else
            {
                string Acc = login.AccNumber;
                newbalance = oldbalance + Convert.ToInt32(DepoAmtTb.Text);
                try
                {
                    Con.Open();
                    string query = "update AccountTb1 set balancetbl=" + newbalance + "where AccNumTbl='" +Acc+ "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your Amount Deposit Successfully");
                    Con.Close();
                    addtransaction();
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int oldbalance,newbalance;
        private void getbalance()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select balanceTbl from AccountTb1 where AccNumTbl ='" + Acc + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            oldbalance = Convert.ToInt32(dt.Rows[0][0].ToString());
            Con.Close();
        }
        private void Deposite_Load(object sender, EventArgs e)
        {
            getbalance();
        }
    }
}

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
    public partial class withdraw : Form
    {
        public withdraw()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Poonam\Documents\ATMdb.mdf;Integrated Security=True;Connect Timeout=30");
        string Acc = login.AccNumber;
        int bal;
        private void getbalance()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select balanceTbl from AccountTb1 where AccNumTbl ='" + Acc + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            balancelbl.Text = "Rs " + dt.Rows[0][0].ToString();
            bal = Convert.ToInt32(dt.Rows[0][0].ToString());
            Con.Close();
        }

        private void addtransaction()
        {
            string TrType = "Withdraw";
            try
            {
                Con.Open();
                string query = "insert into TransactionTbl values('" + Acc + "','" + TrType + "','" + wdamtTb.Text + "','" + DateTime.Today.Date.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Account Created Successfully");
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



        private void withdraw_Load(object sender, EventArgs e)
        {
            getbalance();
        }
        int newbalance;
        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (wdamtTb.Text == " ")
            {
                MessageBox.Show("Enter amount for withdrawing");
            }
            else if (Convert.ToInt32(wdamtTb.Text) <= 0)
            {
                MessageBox.Show("Enter valid amount");
            }
            else if (Convert.ToInt32(wdamtTb.Text) > bal)
            {
                MessageBox.Show("Balance can not be Negative");
            }
            else
            {
                try
                {

                    newbalance = bal - Convert.ToInt32(wdamtTb.Text);
                    try
                    {
                        Con.Open();
                        string query = "update AccountTb1 set balancetbl=" + newbalance + "where AccNumTbl='" + Acc + "'";
                        SqlCommand cmd = new SqlCommand(query, Con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("withdraw Successfully");
                        Con.Close();
                        addtransaction();
                        Home home = new Home();
                        home.Show();
                        this.Hide();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

            }
        }

        
    }
}

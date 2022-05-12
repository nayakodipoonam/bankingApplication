using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMuto
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            balance bal = new balance();
            bal.Show();
            this.Hide();


        }
        public static String AccNumber;
        private void Home_Load(object sender, EventArgs e)
        {
            AccNumTbl.Text = "Account Number:"+ login.AccNumber;
            AccNumber = login.AccNumber;
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            Deposite deposite = new Deposite();
            deposite.Show();
            this.Hide();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            withdraw withdraw = new withdraw();
            withdraw.Show();
            this.Hide();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            ChangePIN changePIN = new ChangePIN();
            changePIN.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            thanks thanks = new thanks();
            thanks.Show();
            this.Hide();

        }
    }
}

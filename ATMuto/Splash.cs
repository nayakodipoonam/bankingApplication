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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer2.Start();
        }

        
        int starting = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            starting += 1;
            Myprogress.Value = starting;
            percentage.Text = "" + starting;
            if(Myprogress.Value==100)
            {
                Myprogress.Value = 0;
                timer2.Stop();
                login log = new login();
                log.Show();
                this.Hide();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SM
{
    public partial class Form1 : Form
    {
        public int i = 10; // Seconds before form  prompts
        
        public Form1()
        {    
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // NULL
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            //NULL
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized; // intial state of form when loaded
            this.ShowInTaskbar = false; // should not be visible in taskbar
            timer2.Start(); // timer for the form to prompt
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            { 
                progressBar1.Value += 3; // for every second make 3 % progress
            }
            catch
            {
                progressBar1.Value += 1; // when value = 99% , only increase 1% 
                if (progressBar1.Value == 100)
                {
                    System.Diagnostics.Process.Start("Shutdown.exe ", "-s -f -t 0"); //shutdown commmad with 0 second delay, and forcing all apps to close.
                }

                timer1.Stop(); // turn off the timers when job done 
            }
           }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;          //For postpone 
            timer1.Stop();                   //next value of i will be seconds of delay 
            timer2.Start();
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            if (comboBox1.Text == "1 minute")
            {
                i = 60 ;
            }
            else if (comboBox1.Text == "10 minutes")
            {
                i = 600;
            } 
            else if (comboBox1.Text == "20 minutes")
            {
                i = 1200;
            }
            else if (comboBox1.Text == "30 minutes")
            {
                i = 1800;
            }


        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            i--; //decrease one second
            if (i == 0)
            {
                this.WindowState = FormWindowState.Normal; //prompt up
                this.ShowInTaskbar = true;
                timer1.Start();
                timer2.Stop();
            }

        }
    }
}

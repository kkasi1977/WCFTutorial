using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsClient
{
    public partial class Form1 : Form
    {
        /*testing Part28
           1. build project 
         * 2. go to bin directory
         * 3. execute Form1.exe  2 instance
         * 4. testing click button at 2 instance
         */
        SimpleService.SimpleServiceClient client;
        public Form1()
        {
            InitializeComponent();
            client = new SimpleService.SimpleServiceClient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Number = " + client.IncrementNumber().ToString());
        }
    }
}

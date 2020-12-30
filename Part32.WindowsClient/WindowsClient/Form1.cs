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
        SampleService.SampleServiceClient client;
        public Form1()
        {
            InitializeComponent();
            client = new SampleService.SampleServiceClient();
        }

 
        private void btnRequestReplyOperation_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Request-Reply Operation Started @ " + DateTime.Now.ToString());
            btnRequestReplyOperation.Enabled = false;
            listBox1.Items.Add(client.RequestReplyOperation());
            btnRequestReplyOperation.Enabled = true;
            listBox1.Items.Add("Request-Reply Operation Completed @ " + DateTime.Now.ToString());
            listBox1.Items.Add("");
        }
    }
}

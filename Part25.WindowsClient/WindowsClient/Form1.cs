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

        HelloService.HelloServiceClient client;

        public Form1()
        {
            InitializeComponent();
            client = new HelloService.HelloServiceClient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                try
                {
                    //통신결함이 있을시 통신서비스를 재 할당한다.
                    if (client.State == System.ServiceModel.CommunicationState.Faulted)
                    {
                        client = new HelloService.HelloServiceClient();
                    }
                    label1.Text = client.GetMessage(textBox1.Text);
                }
                catch(Exception ex)
                {
                    label1.Text = ex.Message;
                }
        }
    }
}

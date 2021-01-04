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

        SimpleService.SimpleServiceClient client;
        public Form1()
        {
            InitializeComponent();
            client = new SimpleService.SimpleServiceClient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Number = " + client.IncrementNumber().ToString() + "\n Session Id: " + client.InnerChannel.SessionId);
            }
            catch (System.ServiceModel.CommunicationException)
            {
                if (client.State == System.ServiceModel.CommunicationState.Faulted)
                {
                    string strMessage = "Session timed out. Your existing session will be lost.";
                    strMessage += " A new session will now be created.";
                    MessageBox.Show(strMessage);
                    client = new SimpleService.SimpleServiceClient();
                }
            }
           
        }
    }
}

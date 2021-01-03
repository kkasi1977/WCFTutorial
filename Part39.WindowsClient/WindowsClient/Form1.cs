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
            /*
             Part 39 
             * How to fix, The communication channel is in a faulted state exception
                1. Put the line that calls the service should in the try block
                2. Catch the CommunicationException
                3. Check if the communication channel is in a faulted state and create a new instance of the proxy class. 
             */
            try
            {
                MessageBox.Show("Number = " + client.IncrementNumber().ToString());
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

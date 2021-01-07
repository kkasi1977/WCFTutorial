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

        private void btnGetMessage_Click(object sender, EventArgs e)
        {
            MessageBox.Show(client.GetMessageWithoutAnyProtection());
        }

        private void btnGetSignedMessage_Click(object sender, EventArgs e)
        {
            MessageBox.Show(client.GetSignedMessage());
        }

        private void btnGetSignedEncryptedMessage_Click(object sender, EventArgs e)
        {
            MessageBox.Show(client.GetSignedAndEncryptedMessage());
        }
    }
}

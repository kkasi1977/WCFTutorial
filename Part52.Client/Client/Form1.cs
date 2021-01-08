﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCallService_Click(object sender, EventArgs e)
        {
            SimpleService.SimpleServiceClient client = new SimpleService.SimpleServiceClient();
            client.ClientCredentials.UserName.UserName = "username";
            client.ClientCredentials.UserName.Password = "password";
            MessageBox.Show(client.GetMessage("man"));
        }
    }
}
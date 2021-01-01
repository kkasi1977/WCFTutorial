using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Client
{

    //http://localhost/DownloadService/DownloadService.svc
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DownloadService.DownloadServiceClient client = new DownloadService.DownloadServiceClient();
            DownloadService.File file = client.DownloadDocument();

            if (System.IO.Directory.Exists(@"C:\DownloadedFiles") == false)
            {
                System.IO.Directory.CreateDirectory(@"C:\DownloadedFiles");
            }
            System.IO.File.WriteAllBytes(@"C:\DownloadedFiles\" + file.Name, file.Content);
            MessageBox.Show(file.Name + " is Downloaded");
        }
    }
}

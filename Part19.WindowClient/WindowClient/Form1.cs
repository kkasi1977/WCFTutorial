using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;

namespace WindowClient
{
    public partial class Form1 : Form
    {
        CalculatorService.CalculatorServiceClient client = null;

        public Form1()
        {
            InitializeComponent();
            client = new CalculatorService.CalculatorServiceClient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int numerator = Convert.ToInt32(textBox1.Text);
                int denominator = Convert.ToInt32(textBox2.Text);

                lblResult.Text = client.Divide(numerator, denominator).ToString();
            }
            catch (FaultException<CalculatorService.DivideByZeroFault> faultException)
            {
                /*Part 19 Stongly Typed SOAP Faults*/
                lblResult.Text = faultException.Detail.Error + " - " +faultException.Detail.Details;
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
            }

        }

        private void btnCreateNewProxy_Click(object sender, EventArgs e)
        {
            client = new CalculatorService.CalculatorServiceClient();
            MessageBox.Show("A new instance of the porxy class is created");
        }
    }
}

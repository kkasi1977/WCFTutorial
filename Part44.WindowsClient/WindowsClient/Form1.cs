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

        private void btnGetEvenNumbers_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void btnGetOddNumbers_Click(object sender, EventArgs e)
        {
            backgroundWorker2.RunWorkerAsync();
        }

        private void btnClearResults_Click(object sender, EventArgs e)
        {
            listBoxEvenNumbers.DataSource = null;
            listBoxOddNumbers.DataSource = null;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = client.GetEvenNumbers();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            listBoxEvenNumbers.DataSource = (int[])e.Result;
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = client.GetOddNumbers();
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            listBoxOddNumbers.DataSource = (int[])e.Result;
        }
    }
}


/*Part 43 Single concurrency mode in WCF 
 * 
 * Where a WCF service handles client requests concurrently or not depends on 3 things
 * 1. Service Instance Context Mode
 * 2. Service Concurrency Mode and 
 * 3. Where if the binding supports session or not 
 * 
 * Setting service
 *  [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.PerCall)]
 *  [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.PerSession)]
 *  
 * Test 1
 * Instance Context Mode        : PerCAll 
 * Concurrency Mode              : Single
 * Binding supports session     : No    -> ex) basicHttpBinding
 * Concurrent Calls processed  : Yes    -> 쓰레드가 서비스의 메소드를 동시적으로 호출 처리된다.
 * Throughput Impact               : Positive
 * 
 * Test 2
 * Instance Context Mode        : PerCAll 
 * Concurrency Mode              : Single
 * Binding supports session     : Yes    -> ex) netTcpBinding
 * Concurrent Calls processed  : No     -> 쓰레드가 서비스의 메소드를 동시적으로 호출하지 않고 잠금이 발생한다.  처리중인 쓰레드가 완료될때가지 기다리다가 잠금이 풀리면 호출 처리된다.
 * Throughput Impact              : Negative
 * 
 * Test 3
 * Instance Context Mode        : PerSession 
 * Concurrency Mode              : Single
 * Binding supports session     : No -> ex) basicHttpBinding
 * Concurrent Calls processed  : Yes
 * Throughput Impact             : Positive
 * 
 * Test 4
 * Instance Context Mode        : PerSession 
 * Concurrency Mode              : Single
 * Binding supports session     : Yes   -> ex) netTcpBinding
 * Concurrent Calls processed  : Yes - Between Different client requests   No - For the request from the same client
 * Throughput Impact             : Positive - Between clients    Negative - For the same client request
 * 
 * Test 5
 * Instance Context Mode        : Single 
 * Concurrency Mode              : Single
 * Binding supports session     : No -> ex) basicHttpBinding
 * Concurrent Calls processed  : No
 * Throughput Impact             : Negative - Between clients and for the requests from the same client 
 * 
 * Test 6
 * Instance Context Mode        : Single 
 * Concurrency Mode              : Single
 * Binding supports session     : YES -> ex) netTcpBinding
 * Concurrent Calls processed  : No
 * Throughput Impact             : Negative - Between clients and for the requests from the same client 
*/
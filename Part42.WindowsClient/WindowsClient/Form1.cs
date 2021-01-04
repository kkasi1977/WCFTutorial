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

    /*
     Part 42 SessinMode Enumeration in WCF 
     *   Update Service References
     *   Build Project 
     *   Find target file at bin fonder
     *   Execute target file by 2 instance 
     *  
     * Example 1 Set the service InstanceContextMode to Single and SessionMode to Allowed 
     * 
     * setting
     *          ServiceBehavior InstanceContextMode -> Single
     *          ServiceContract SessionMode -> SessionMode.Allowed   (Default) 
     * 
     * test1 : 
     *          Binding -> basicHttpBinding
     *          
     *          : If we use basicHttpBinding that does not support sessions, the service still works as a singleton service but without session. 
     *            세션을 지원하지 않는 basicHttpBinding을 사용하는 경우 서비스는 여전히 단일 서비스로 작동하지만 세션은 없습니다.
     * test2 : 
     *          Binding -> netTcpBinding
     *          
     *          : One the other hand if we use, netTcpBinding that support sessions, the service gets a session, and continue to work as a singleton service.  
     *            다른 한편으로 세션을 지원하는 netTcpBinding을 사용하면 서비스가 세션을 가져 와서 싱글 톤 서비스로 계속 작동합니다.
     * 
     * Example 2 Now change SessionMode to Required. 
     * setting 
     *          ServiceBehavior InstanceContextMode -> Single
     *          ServiceContract SessionMode -> SessionMode.Required   
     * test1 : 
     *           Binding -> netTcpBinding 
     *          ->  If we use, netTcpBinding that support sessions, the service gets a session, and continue to work as a singleton service. 
     *              세션을 지원하는 netTcpBinding을 사용하면 서비스가 세션을 가져 와서 싱글 톤 서비스로 계속 작동합니다
     * test2 : 
     *           Binding -> basicHttpBinding
     *          ->On the other hand, if we use basicHttpBinding that does not support sessions, the following exception is thrown 
     *              반면 세션을 지원하지 않는 basicHttpBinding을 사용하면 다음과 같은 예외가 발생합니다.
     *               System.InvalidOperationException: Contract requires Session, but Binding 'BasicHttpBinding' doesn't support it or isn't configured properly to support it.          
     *  
     */





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

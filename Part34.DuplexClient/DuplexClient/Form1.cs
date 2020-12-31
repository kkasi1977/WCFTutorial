using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using System.Threading;

namespace DuplexClient
{
    //[CallbackBehavior(UseSynchronizationContext = false)] //Step2 교착상태해결하려면 CallbackBehavior UseSynchronizationContext 를 false로 설정한다
    public partial class Form1 : Form, ReportService.IReportServiceCallback
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void btnProcessReport_Click(object sender, EventArgs e)
        {

            //어떤 절이 콜백 계약을 구현하고 있는지 확인하라
            //ReportServiceClient 인스턴스 생성시 콜백 계약을 구현하는 클래스 인스턴스를 전달해야 한다. 
            InstanceContext instanceContext = new InstanceContext(this);
            ReportService.ReportServiceClient client = new ReportService.ReportServiceClient(instanceContext);
            client.ProcessReport();

            //교착상태(서비스서버가 바빠서 클라이언트가 응답을 받을 수 없는 상태) 예외가 발생될것임.
            //서버단에서 동시성 모드를  Reentrant로 설정해야한다.  
        }

        #region IReportServiceCallback 멤버

        public void Progress(int percentageCompleted)
        {
            textBox1.Text = percentageCompleted.ToString() + " % completed";
        }
        #endregion

 
        

    }
}



/*방법: 스레드로부터 안전한 호출을 Windows Forms 컨트롤 만들기 
 https://docs.microsoft.com/ko-kr/dotnet/desktop/winforms/controls/how-to-make-thread-safe-calls-to-windows-forms-controls?view=netframeworkdesktop-4.8
 
 */
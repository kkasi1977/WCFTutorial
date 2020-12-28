using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Dispatcher;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace CalculatorService
{
    /*Part 20 Centralized Exception Handling in WCF
   
     GlobalErrorHandler -> 디스패처 채널에 연결될 오류처리기
        - ProvideFault 가 먼저 호출되고 난 후 HandleError가 비동기적으로 호출된다. 
     */
    public class GlobalErrorHandler : IErrorHandler
    {
        #region IErrorHandler 멤버


        //비동기적으로 호출된다
        //실제 예외사항을 기록한다.
        public bool HandleError(Exception error)
        {
            return true;
        }

        public void ProvideFault(Exception error, System.ServiceModel.Channels.MessageVersion version, ref System.ServiceModel.Channels.Message fault)
        {
            if (error is FaultException)
                return;

            FaultException faultException = new FaultException("A general service error occured"); // a message of manual define.
            MessageFault messageFault = faultException.CreateMessageFault();
            fault = Message.CreateMessage(version, messageFault, null);
         }

        #endregion
    }
}

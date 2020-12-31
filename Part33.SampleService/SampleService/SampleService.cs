using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace SampleService
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 클래스 이름 "SampleService"을 변경할 수 있습니다.
    public class SampleService : ISampleService
    {


        #region ISampleService 멤버

        string ISampleService.RequestReplyOperation()
        {
            DateTime dtStart = DateTime.Now;
            Thread.Sleep(2000);
            DateTime dtEnd = DateTime.Now;

            return dtEnd.Subtract(dtStart).Seconds.ToString() + " seconds processing time";
        }

        string ISampleService.RequestReplyOperation_ThrowsException()
        {
            throw new NotImplementedException();
        }

 


        public void OneWayOperation()
        {
            Thread.Sleep(2000);
            return;
        }

        public void OneWayOperation_ThrowsException()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

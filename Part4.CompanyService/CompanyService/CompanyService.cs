using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CompanyService
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 클래스 이름 "CompanyService"을 변경할 수 있습니다.
    public class CompanyService : ICompanyPublicService, ICompanyConfidentialService
    {
         public string GetPublicInformation()
        {
            return "This is public information and available over HTTP to all general public outside the FireWall";
        }


        public string GetConfidentialInformation()
        {
            return "This is confidential information and only available over TCP behind the company FireWall";
        }

    }
}

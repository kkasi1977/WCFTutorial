using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DownloadService
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 클래스 이름 "DownloadService"을 변경할 수 있습니다.
    public class DownloadService : IDownloadService
    {
        //C:\git\WCFTutorial\Data\OpenAPIGuide.pdf
 
        public File DownloadDocument()
        {
            File file = new File();
            file.Content = System.IO.File.ReadAllBytes(@"C:\git\WCFTutorial\Data\OpenAPIGuide.pdf");
            file.Name = "OpenAPIGuide.pdf";

            return file;
        }
 
    }
}

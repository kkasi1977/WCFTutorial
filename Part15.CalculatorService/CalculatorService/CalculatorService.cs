﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CalculatorService
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 클래스 이름 "CalculatorService"을 변경할 수 있습니다.
    public class CalculatorService : ICalculatorService
    {

        public int Divide(int Numerator, int Denominator)
        {
            return Numerator / Denominator;
        }

    }
}

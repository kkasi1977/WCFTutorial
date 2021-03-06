﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SimpleService
{
    // 참고: "리팩터링" 메뉴에서 "이름 바꾸기" 명령을 사용하여 코드 및 config 파일에서 인터페이스 이름 "ISimpleService"을 변경할 수 있습니다.
    [ServiceContract]
    public interface ISimpleService
    {
        [OperationContract(IsOneWay = true)]
        void DoWork();
    }
}


/*Part 46 WCF throttling

What is throughtput?
Throuhtput is the amount of work done in a given time. 
In addition to Service Instance Context Mode and Concurrency Mode, Throttling settings also infulence the throught put of a WCF service. 

Throttling setting s can be specified either in the config file or in code. 

Throttling settings in config file. 
<behaviors>
   <serviceBehaviors>
      <behavior name="throttlingBehavior">
         <serviceThrottling
            mexConcurrentCalls="3" 
            mexConcurrentInstances="3" 
            mexConcurrentSessions="100" /> 
      </behavior>
   </serviceBehaviors>
</behaviors>

Throttling settings in code

using (ServiceHost host = new ....)
{
    ServiceThrottlingBehavior throttlingBehavior = new...
    {
            mexConcurrentCalls="3",  
            mexConcurrentInstances="3",  
            mexConcurrentSessions="100"
    };
   host.Description.Behaviors.Add(throttlingBehavior);
   host.Open();
   ...
}
 
Please Note:ServiceThrottlingBehavior class is present in System.ServiceModel.Description namespace

With the above throttling settings a maximum of 3 concurrent calls are processed. 

IN addition to maxConcurrentCalls property, maxConcurrentInstances and maxConcurrentSessions may also impact the number of calls processed concurrently

For example, if we set maxConcurrentCall="3", maxConcurrentInstances="2", and maxConcurrentSessions="100", 

With a PerCall instance context mode, only 2 calls are processed concurrently. 
This is because every call requires a new service instance, and here we are allowing only a maximum of 2 concurrent instances to be created. 

With a Single instance context mode, 3 calls are processed concurrently. 
This is because with a singleton service there is only one service instance which handles all the requests from all the clients. 
With singleton maxConcurrentInstances property does not have any influence. 

Please note:maxConcurrentSessions is the sum of all types of sessions, that is 
1. Application sessions
2. Transport sessions 
3. Reliable sessions 
4. Secure sessions

Default: 
Before WCF 4.0 
    MaxConcurrentCalls:16
    MaxConcurrentSessions:10
    MaxConcurrentInstances:MaxConcurrentCalls + MaxConcurrentSessions(26)

Before WCF 4.0 and later
    MaxConcurrentCalls:16 * processor count
    MaxConcurrentSessions:100 * processor count
    MaxConcurrentInstances:MaxConcurrentCalls + MaxConcurrentSessions


46 부 WCF 조절

처리량이란 무엇입니까?
Throuhtput은 주어진 시간에 수행 된 작업량입니다.
서비스 인스턴스 컨텍스트 모드 및 동시성 모드 외에도 제한 설정은 WCF 서비스의 처리에 영향을줍니다.

제한 설정은 구성 파일 또는 코드에서 지정할 수 있습니다.

구성 파일의 제한 설정.
<behaviors>
   <serviceBehaviors>
      <behavior name="throttlingBehavior">
         <serviceThrottling
            mexConcurrentCalls="3" 
            mexConcurrentInstances="3" 
            mexConcurrentSessions="100" /> 
      </behavior>
   </serviceBehaviors>
</behaviors>

코드의 제한 설정

(ServiceHost 호스트 = new ....) 사용
{
    ServiceThrottlingBehavior throttlingBehavior = 신규 ...
    {
            mexConcurrentCalls = "3",
            mexConcurrentInstances = "3",
            mexConcurrentSessions = "100"
    };
   host.Description.Behaviors.Add (throttlingBehavior);
   host.Open ();
   ...
}
 
참고 : ServiceThrottlingBehavior 클래스는 System.ServiceModel.Description 네임 스페이스에 있습니다.

위의 제한 설정을 사용하면 최대 3 개의 동시 호출이 처리됩니다.

maxConcurrentCalls 속성 외에도 maxConcurrentInstances 및 maxConcurrentSessions는 동시에 처리되는 호출 수에 영향을 줄 수 있습니다.

예를 들어 maxConcurrentCall = "3", maxConcurrentInstances = "2"및 maxConcurrentSessions = "100"를 설정하면

PerCall 인스턴스 컨텍스트 모드에서는 2 개의 호출 만 동시에 처리됩니다.
이는 모든 호출에 새 서비스 인스턴스가 필요하고 여기서는 최대 2 개의 동시 인스턴스 만 생성 할 수 있기 때문입니다.

단일 인스턴스 컨텍스트 모드에서는 3 개의 호출이 동시에 처리됩니다.
싱글 톤 서비스에는 모든 클라이언트의 모든 요청을 처리하는 서비스 인스턴스가 하나만 있기 때문입니다.
싱글 톤의 경우 maxConcurrentInstances 속성은 영향을 미치지 않습니다.

참고 : maxConcurrentSessions는 모든 세션 유형의 합계입니다.
1. 신청 세션
2. 운송 세션
3. 안정적인 세션
4. 보안 세션

기본:
WCF 4.0 이전
    MaxConcurrentCalls : 16
    MaxConcurrentSessions : 10
    MaxConcurrentInstances : MaxConcurrentCalls + MaxConcurrentSessions (26)

WCF 4.0 이상 이전
    MaxConcurrentCalls : 16 * 프로세서 수
    MaxConcurrentSessions : 100 * 프로세서 수
    MaxConcurrentInstances : MaxConcurrentCalls + MaxConcurrentSessions

*/
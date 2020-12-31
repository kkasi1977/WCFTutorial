using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ReportService
{

    [ServiceContract(CallbackContract = typeof(IReportServiceCollback))]
    public interface IReportService
    {
        [OperationContract(IsOneWay=true)]
        void ProcessReport();
    }

    public interface IReportServiceCollback
    {
        [OperationContract(IsOneWay=true)]
        void Progress(int percentageCompleted);
    }

}

/*
Part 34
단방향 작업은 작업상태를 클라이언트에게 다시 보낼 방법이 없다는 것.
 클라이언트의 요구사항은  처리상황에 대하여 알아야한다는 것 
즉 단방향은 클라이언트에게 상태를 다시보내는것이 불가능하므로 이중 메시징 패턴을 사용하여 이를 해결할 수 있다. 

wcf는 클라이언트가 사용할 수 있도록 메시지를 호출하고 보낼 수 있다. 
CallbackContract을 사용한다.
  
 단 방향 으로 하면 이중 메시징 패턴은 아주 간단하다.
 * 서비스단의 동시성모드, 클라이언트의 동기화 컨텍스트도 필요하지 않다. 
 * 단 방향 계약을 수행하려면,, IsOneWay = true 처리하면 된다. 
 * 서비스 메소드 , 콜백 메소드 모두 처리해준다. 
 * 
 단방향 작업을 사용하여 이중 메시징 패턴을 구현하려면  
 *동시성 모드가 필요하지 않다. 
 *동기화가 필요하지 않다.
*/

/*Part 34 Duplex Message Exchange Pattern 

Duplex messaging pattern can be implemented using Request/Reply or OneWay operations. 

Part 32-Request/Reply operations
Part 33-OneWay operations

In this video, we will first discuss implementing duplex messaging pattern using Request/Reply operations. 
We will then modify the example to implement duplex messaging pattern using oneway operations. 

Step 1.
service side :
Get the callback channel to send messages to the client

client side :
1. Implement the callback interface in the client application
2. Pass the instance of the type that implements callback interface, to the constructor of the client proxy

Step 2. 
To resolve the deadlock that arises when using Reqeust/Reply operations to implement Duplex Messaging pattern

1. In the service set ConcurrencyMode  to Reentrant
[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
public class ReportService : IReportService
{
  ....
}



2. In the client project, set UseSynchronizationContext to false 
[CallbackBehavior(UseSynchronizationContext = false)] 
public partial class Form1 : Form, ReportService.IReportServiceCalback
{
  ....
}

Step 3. 
To implement Duplex messaging pattern using OneWay operations

1. Remove ServiceBehavior attribute that sets ConcurrencyMode to Reetrant from WCF service

2. Remove CallbackBehavior attribute that sets UseSynchronizationContext to false in the client project 

3. Set ProcessReport() and Progress() operation contracts to OneWay in the service
[OperationContract(IsOneWay=true)]
void ProcessReport();


Part 34 이중 메시지 교환 패턴

요청 / 응답 또는 OneWay 작업을 사용하여 이중 메시징 패턴을 구현할 수 있습니다.

32 부 요청 / 응답 작업
33 부 -OneWay 작업

이 비디오에서는 먼저 요청 / 응답 작업을 사용하여 이중 메시징 패턴을 구현하는 방법에 대해 설명합니다.
그런 다음 단방향 작업을 사용하여 이중 메시징 패턴을 구현하도록 예제를 수정합니다.

1 단계.
서비스 측 :
클라이언트에 메시지를 보낼 콜백 채널 가져 오기

고객 입장에서 :
1. 클라이언트 애플리케이션에서 콜백 인터페이스 구현
2. 콜백 인터페이스를 구현하는 유형의 인스턴스를 클라이언트 프록시의 생성자에 전달합니다.

2 단계.
Reqeust / Reply 작업을 사용하여 이중 메시징 패턴을 구현할 때 발생하는 교착 상태를 해결하려면

1. 서비스에서 ConcurrencyMode를 재진입으로 설정합니다.
[ServiceBehavior (ConcurrencyMode = ConcurrencyMode.Reentrant)]
공용 클래스 ReportService : IReportService
{
  ....
}



2. 클라이언트 프로젝트에서 UseSynchronizationContext를 false로 설정합니다.
[CallbackBehavior (UseSynchronizationContext = false)]
공용 부분 클래스 Form1 : Form, ReportService.IReportServiceCalback
{
  ....
}

3 단계.
OneWay 작업을 사용하여 이중 메시징 패턴을 구현하려면

1. WCF 서비스에서 ConcurrencyMode를 Reetrant로 설정하는 ServiceBehavior 특성 제거

2. 클라이언트 프로젝트에서 UseSynchronizationContext를 false로 설정하는 CallbackBehavior 속성을 제거합니다.

3. 서비스에서 ProcessReport () 및 Progress () 작업 계약을 OneWay로 설정합니다.
[OperationContract (IsOneWay = true)]
void ProcessReport ();

동시성 모드가 필요하지 않습니다. 동기화가 필요하지 않습니다.



*/
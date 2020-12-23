using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
 
namespace EmployeeService 
{


    [DataContract(Namespace="http://pragimtech.com/2013/07/07/Employee")]
    public class Employee : IExtensibleDataObject
    {
        [DataMember(Name="ID", Order=1)]
        public int Id { get; set; }

        [DataMember(Order=2)]
        public string Name { get; set; }

        //[DataMember(Order=3)]
        //public string Gender { get; set; }

        [DataMember(Order=4)]
        public DateTime DateOfBirth { get; set; }

        [DataMember(Order=5)]
        public EmployeeType Type { get; set; }

        [DataMember(Order = 6, IsRequired = false)]
        public string City { get; set; }



        #region IExtensibleDataObject 멤버
        //서비스에서 수신 된 xml내의 알 수 없는 데이터 요소는 이 확장 개체에 저장된다.
        //클라이언트는 데이터 개체를 찾은 다음 해당 데이터를 다시 xml로 직렬화해야한다는 것을 알고 있다.
        //직렬화 프로세스에서 할 일은 알려지지 않은 요소(ExtensionDataObject)를  xml형식으로 저장하는 것이다.
        //서비스가 처음 호출되었을 때  클라이언트는 xml형식으로 해당 데이터를 가져오는 방법을 알고 있다.
        //서비스 측의 알려지지 않은 요소에 대한 데이터 저장소를 사용하여 클라이언트에서도 양방향으로 작동한다.

        public ExtensionDataObject ExtensionData { get; set; }
        #endregion
    }

    public enum EmployeeType
    {
        FullTimeEmployee = 1,
        PartTimeEmployee = 2
    }


}

#region Part13 , Part14  Concept
//## Part13 , Part14  Concept
//EmployeeService 측에서 DataContract에 Gender 요소를 주석처리하고 서비스 메소드에서 Gender 요소 서비스를 주석처리한다.
//그리고 Client에서 서비스 업데이트를 하지 않은 상태로 Part 13, Part 14 테스트를 진행한다. 
//Client측에는 Gender를 요청하지만 서비스에는 없는 상황일경우  클라이언트에서 저장시점에서
//성별을 입력하여 저장 요청시 서비스측은 역직렬화할때 IExtensibleDataObject에 unKnown 요소를 저장처리하게된다. 
//이러한 기능에 대한 사용방법과 위험에 대비하여 Web.config에 behaviors에 기능을 제어할 수 있는 옵션도 소개한다. 
#endregion

#region Part 13 ExtensionDataObject
//## Part13 ExtensionDataObject 
//In short, use IExtensibleDataObject to preserve unknown elements during serialization and deserialization of DataContracts. 
//On the service side, at the time of deserialization the unknown elements from the client are stored in ExtensionDataObject. 
//To send data to the client, the servide has to serialize data into XML. 
//During this serialization process the data from ExtensionDataObject is serialized into XML as it was provided at the time of service call.

//## 파트 13 ExtensionDataObject
//간단히 말해, IExtensibleDataObject를 사용하여 DataContract의 직렬화 및 역 직렬화 중에 알 수없는 요소를 보존합니다. 
//서비스 측에서는 역 직렬화 할 때 클라이언트의 알 수없는 요소가 ExtensionDataObject에 저장됩니다. 
//클라이언트에 데이터를 보내려면 서비스가 데이터를 XML로 직렬화해야합니다. 
//이 직렬화 프로세스 동안 ExtensionDataObject의 데이터는 서비스 호출시 제공된대로 XML로 직렬화됩니다.
#endregion

#region Part 14 IExtensibleDataObject Rists
//## Part 14 IExtensibleDataObject Rists
//In Part 13, we discussed, how to implement IExtensibleDataObject to preserve unknown elements during serialization and deserialization of DataContracts.

//The downside of implementing IExtensibleDataObject inserface is the risk of Denial of Service attack. 
//Since, the extension data is stored in memory, the attacker may flood the server with requests that contains large number of unknown elements which can lead to system out of memory and DoS.

//How to turn off IExtensibleDataObject feature?
//One way is to remove the implementation of IExtensibleDataObject interface from all the DataContracts. 
//This should work fine as long as we have a few data contracts on which IExtensibleDataObject interface is implemented.

//What if there are larege number of DataContracts that have implemented IExtensibleDataObject interface?
//IExtensibleDataObject can be enabled or disabled using service behavior configuration. 
//With this option later if we want to enable support, all we need to do is set ignoreExtensionDataObject to false.

//This can also be done programatically using ServiceBehaviorAttribute.
//Set IgnoreExtensionDataObject property to ture.
//When IExtensibleDataObject feature is turned off, the deserializer will not populate the ExtensionData property.

//## 파트 14 IExtensibleDataObject Rists
//Part 13에서는 DataContract의 직렬화 및 역 직렬화 중에 알 수없는 요소를 보존하기 위해 IExtensibleDataObject를 구현하는 방법에 대해 설명했습니다.

//IExtensibleDataObject 내부 구현의 단점은 서비스 거부 공격의 위험입니다. 
//확장 데이터가 메모리에 저장되기 때문에 공격자는 시스템의 메모리 부족 및 DoS로 이어질 수있는 알 수없는 요소가 많이 포함 된 요청으로 서버를 넘길 수 있습니다.

//IExtensibleDataObject 기능을 해제하는 방법은 무엇입니까?
//한 가지 방법은 모든 DataContract에서 IExtensibleDataObject 인터페이스의 구현을 제거하는 것입니다. 
//IExtensibleDataObject 인터페이스가 구현 된 몇 가지 데이터 계약이있는 한 제대로 작동합니다.

//IExtensibleDataObject 인터페이스를 구현 한 DataContract가 너무 많으면 어떻게됩니까?
//IExtensibleDataObject는 서비스 동작 구성을 사용하여 활성화 또는 비활성화 할 수 있습니다. 
//나중에이 옵션을 사용하여 지원을 활성화하려면 ignoreExtensionDataObject를 false로 설정하기 만하면됩니다.

//ServiceBehaviorAttribute를 사용하여 프로그래밍 방식으로 수행 할 수도 있습니다.
//IgnoreExtensionDataObject 속성을 ture로 설정합니다.
//IExtensibleDataObject 기능이 꺼져 있으면 deserializer가 ExtensionData 속성을 채우지 않습니다.
#endregion
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

//Part13 ExtensionDataObject 
//In short, use IExtensibleDataObject to preserve unknown elements during serialization and deserialization of DataContracts. 
//On the service side, at the time of deserialization the unknown elements from the client are stored in ExtensionDataObject. 
//To send data to the client, the servide has to serialize data into XML. 
//During this serialization process the data from ExtensionDataObject is serialized into XML as it was provided at the time of service call.

//ExtensionDataObject
//간단히 말해, IExtensibleDataObject를 사용하여 DataContract의 직렬화 및 역 직렬화 중에 알 수없는 요소를 보존합니다. 
//서비스 측에서는 역 직렬화 할 때 클라이언트의 알 수없는 요소가 ExtensionDataObject에 저장됩니다. 
//클라이언트에 데이터를 보내려면 서비스가 데이터를 XML로 직렬화해야합니다. 
//이 직렬화 프로세스 동안 ExtensionDataObject의 데이터는 서비스 호출시 제공된대로 XML로 직렬화됩니다.




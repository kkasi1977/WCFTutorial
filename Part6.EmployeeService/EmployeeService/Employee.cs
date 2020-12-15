using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


//WCF DataContract 및 DataMember
//.NET 3.5SP1 이상에서는 DataContractor DataMember 특성을 명시 적으로 사용할 필요가 없습니다. 
//데이터 계약 직렬 변환기는 복합 유형의 모든 공용 속성을 알파벳 순서로 직렬화합니다. 
//기본적으로 개인 필드 및 속성은 직렬화되지 않습니다.

//복잡한 유형을 꾸미면 [Serializable] 속성이있는 DataContractSerializer는 모든 필드를 직렬화합니다. 
//[Serializable] 속성을 사용하면 직렬화 된 데이터에 포함 및 제외 할 필드를 명시 적으로 제어 할 수 없습니다.

//[Datacontract] 속성을 사용하여 복합 유형을 장식하면 DataContractSerializer는 [DataMember] 속성으로 표시된 필드를 직렬화합니다. 
//[DataMember] 특성은 개인 필드 또는 공용 속성에 적용 할 수 있습니다.

//WCF에서 가장 일반적인 직렬화 방법은 유형을 DataContract 특성으로 표시하고 직렬화해야하는 각 멤버를 DtaMember 특성으로 표시하는 것입니다.

//직렬화되는 필드 및 속성을 명시 적으로 제어하려면 DataContract 및 DataMember 특성을 사용합니다.
//1. DataContractAttribute를 사용하여 데이터에 대한 XML 네임 스페이스를 정의 할 수 있습니다.
//2. DataMemberAttribute를 사용하여 다음을 수행 할 수 있습니다.
//  a) 이름, 순서 및 속성 또는 필드가 필수인지 여부를 정의합니다.
//  b) 또한 비공개 필드와 속성을 직렬화합니다.


namespace EmployeeService
{
   
    [KnownType(typeof(FullTimeEmployee))]
    [KnownType(typeof(PartTimeEmployee))]
    [DataContract(Namespace="http://pragimtech.com/2013/07/07/Employee")]
    public class Employee
    {
        [DataMember(Name="ID", Order=1)]
        public int Id { get; set; }

        [DataMember(Order=2)]
        public string Name { get; set; }

        [DataMember(Order=3)]
        public string Gender { get; set; }

        [DataMember(Order=4)]
        public DateTime DateOfBirth { get; set; }

        public EmployeeType Type { get; set; }
    }

    public enum EmployeeType
    {
        FullTimeEmployee = 1,
        PartTimeEmployee = 2
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
 
namespace EmployeeService
{


    [DataContract(Namespace="http://pragimtech.com/2013/07/07/Employee")]
    public class Employee
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
    }

    public enum EmployeeType
    {
        FullTimeEmployee = 1,
        PartTimeEmployee = 2
    }


}

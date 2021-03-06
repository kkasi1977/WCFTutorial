﻿//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.EmployeeService {
    using System.Runtime.Serialization;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EmployeeType", Namespace="http://schemas.datacontract.org/2004/07/EmployeeService")]
    public enum EmployeeType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        FullTimeEmployee = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        PartTimeEmployee = 2,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EmployeeService.IEmployeeService")]
    public interface IEmployeeService {
        
        // CODEGEN: EmployeeRequest 메시지의 래퍼 네임스페이스(http://MyCompany.com/Employee)가 기본값(http://tempuri.org/)과 일치하지 않으므로 메시지 계약을 생성합니다.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/GetEmployee", ReplyAction="http://tempuri.org/IEmployeeService/GetEmployeeResponse")]
        Client.EmployeeService.EmployeeInfo GetEmployee(Client.EmployeeService.EmployeeRequest request);
        
        // CODEGEN: SaveEmployee 작업이 RPC 또는 문서 래핑이 아니므로 메시지 계약을 생성합니다.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmployeeService/SaveEmployee", ReplyAction="http://tempuri.org/IEmployeeService/SaveEmployeeResponse")]
        Client.EmployeeService.SaveEmployeeResponse SaveEmployee(Client.EmployeeService.EmployeeInfo request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="EmployeeRequestObject", WrapperNamespace="http://MyCompany.com/Employee", IsWrapped=true)]
    public partial class EmployeeRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://MyCompany.com/Employee")]
        public string LicenseKey;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://MyCompany.com/Employee", Order=0)]
        public int EmployeeId;
        
        public EmployeeRequest() {
        }
        
        public EmployeeRequest(string LicenseKey, int EmployeeId) {
            this.LicenseKey = LicenseKey;
            this.EmployeeId = EmployeeId;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="EmployeeInfoObject", WrapperNamespace="http://MyCompany.com/Employee", IsWrapped=true)]
    public partial class EmployeeInfo {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://MyCompany.com/Employee", Order=0)]
        public int Id;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://MyCompany.com/Employee", Order=1)]
        public string Name;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://MyCompany.com/Employee", Order=2)]
        public string Gender;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://MyCompany.com/Employee", Order=3)]
        public System.DateTime DOB;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://MyCompany.com/Employee", Order=4)]
        public Client.EmployeeService.EmployeeType Type;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://MyCompany.com/Employee", Order=5)]
        public int AnnualSalary;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://MyCompany.com/Employee", Order=6)]
        public int HourlyPay;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://MyCompany.com/Employee", Order=7)]
        public int HoursWorked;
        
        public EmployeeInfo() {
        }
        
        public EmployeeInfo(int Id, string Name, string Gender, System.DateTime DOB, Client.EmployeeService.EmployeeType Type, int AnnualSalary, int HourlyPay, int HoursWorked) {
            this.Id = Id;
            this.Name = Name;
            this.Gender = Gender;
            this.DOB = DOB;
            this.Type = Type;
            this.AnnualSalary = AnnualSalary;
            this.HourlyPay = HourlyPay;
            this.HoursWorked = HoursWorked;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SaveEmployeeResponse {
        
        public SaveEmployeeResponse() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEmployeeServiceChannel : Client.EmployeeService.IEmployeeService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EmployeeServiceClient : System.ServiceModel.ClientBase<Client.EmployeeService.IEmployeeService>, Client.EmployeeService.IEmployeeService {
        
        public EmployeeServiceClient() {
        }
        
        public EmployeeServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EmployeeServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmployeeServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmployeeServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Client.EmployeeService.EmployeeInfo Client.EmployeeService.IEmployeeService.GetEmployee(Client.EmployeeService.EmployeeRequest request) {
            return base.Channel.GetEmployee(request);
        }
        
        public int GetEmployee(string LicenseKey, int EmployeeId, out string Name, out string Gender, out System.DateTime DOB, out Client.EmployeeService.EmployeeType Type, out int AnnualSalary, out int HourlyPay, out int HoursWorked) {
            Client.EmployeeService.EmployeeRequest inValue = new Client.EmployeeService.EmployeeRequest();
            inValue.LicenseKey = LicenseKey;
            inValue.EmployeeId = EmployeeId;
            Client.EmployeeService.EmployeeInfo retVal = ((Client.EmployeeService.IEmployeeService)(this)).GetEmployee(inValue);
            Name = retVal.Name;
            Gender = retVal.Gender;
            DOB = retVal.DOB;
            Type = retVal.Type;
            AnnualSalary = retVal.AnnualSalary;
            HourlyPay = retVal.HourlyPay;
            HoursWorked = retVal.HoursWorked;
            return retVal.Id;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Client.EmployeeService.SaveEmployeeResponse Client.EmployeeService.IEmployeeService.SaveEmployee(Client.EmployeeService.EmployeeInfo request) {
            return base.Channel.SaveEmployee(request);
        }
        
        public void SaveEmployee(int Id, string Name, string Gender, System.DateTime DOB, Client.EmployeeService.EmployeeType Type, int AnnualSalary, int HourlyPay, int HoursWorked) {
            Client.EmployeeService.EmployeeInfo inValue = new Client.EmployeeService.EmployeeInfo();
            inValue.Id = Id;
            inValue.Name = Name;
            inValue.Gender = Gender;
            inValue.DOB = DOB;
            inValue.Type = Type;
            inValue.AnnualSalary = AnnualSalary;
            inValue.HourlyPay = HourlyPay;
            inValue.HoursWorked = HoursWorked;
            Client.EmployeeService.SaveEmployeeResponse retVal = ((Client.EmployeeService.IEmployeeService)(this)).SaveEmployee(inValue);
        }
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SecureClient.InSecureServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="InSecureServiceReference.IInSecureService")]
    public interface IInSecureService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInSecureService/DoSomethingInsecure", ReplyAction="http://tempuri.org/IInSecureService/DoSomethingInsecureResponse")]
        string DoSomethingInsecure(string s);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IInSecureService/DoSomethingInsecure", ReplyAction="http://tempuri.org/IInSecureService/DoSomethingInsecureResponse")]
        System.Threading.Tasks.Task<string> DoSomethingInsecureAsync(string s);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IInSecureServiceChannel : SecureClient.InSecureServiceReference.IInSecureService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class InSecureServiceClient : System.ServiceModel.ClientBase<SecureClient.InSecureServiceReference.IInSecureService>, SecureClient.InSecureServiceReference.IInSecureService {
        
        public InSecureServiceClient() {
        }
        
        public InSecureServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public InSecureServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public InSecureServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public InSecureServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string DoSomethingInsecure(string s) {
            return base.Channel.DoSomethingInsecure(s);
        }
        
        public System.Threading.Tasks.Task<string> DoSomethingInsecureAsync(string s) {
            return base.Channel.DoSomethingInsecureAsync(s);
        }
    }
}

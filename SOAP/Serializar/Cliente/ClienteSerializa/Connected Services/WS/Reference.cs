﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClienteSerializa.WS {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ArrayOfPessoa", Namespace="http://www.ipca.pt/ws/", ItemName="Pessoa")]
    [System.SerializableAttribute()]
    public class ArrayOfPessoa : System.Collections.Generic.List<ClienteSerializa.WS.Pessoa> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Pessoa", Namespace="http://www.ipca.pt/ws/Pessoa")]
    [System.SerializableAttribute()]
    public partial class Pessoa : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NomePessoaField;
        
        private int IdadePessoaField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string NomePessoa {
            get {
                return this.NomePessoaField;
            }
            set {
                if ((object.ReferenceEquals(this.NomePessoaField, value) != true)) {
                    this.NomePessoaField = value;
                    this.RaisePropertyChanged("NomePessoa");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=1)]
        public int IdadePessoa {
            get {
                return this.IdadePessoaField;
            }
            set {
                if ((this.IdadePessoaField.Equals(value) != true)) {
                    this.IdadePessoaField = value;
                    this.RaisePropertyChanged("IdadePessoa");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MyPessoas", Namespace="http://www.ipca.pt/ws/Pessoa")]
    [System.SerializableAttribute()]
    public partial class MyPessoas : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ClienteSerializa.WS.Pessoa[] pessoasField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public ClienteSerializa.WS.Pessoa[] pessoas {
            get {
                return this.pessoasField;
            }
            set {
                if ((object.ReferenceEquals(this.pessoasField, value) != true)) {
                    this.pessoasField = value;
                    this.RaisePropertyChanged("pessoas");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MyPessoasII", Namespace="http://www.ipca.pt/ws/Pessoa")]
    [System.SerializableAttribute()]
    public partial class MyPessoasII : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ClienteSerializa.WS.Pessoa[] ListaPessoasField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public ClienteSerializa.WS.Pessoa[] ListaPessoas {
            get {
                return this.ListaPessoasField;
            }
            set {
                if ((object.ReferenceEquals(this.ListaPessoasField, value) != true)) {
                    this.ListaPessoasField = value;
                    this.RaisePropertyChanged("ListaPessoas");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Book", Namespace="http://www.ipca.pt/ws/")]
    [System.SerializableAttribute()]
    public partial class Book : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ISBNField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string ISBN {
            get {
                return this.ISBNField;
            }
            set {
                if ((object.ReferenceEquals(this.ISBNField, value) != true)) {
                    this.ISBNField = value;
                    this.RaisePropertyChanged("ISBN");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.ipca.pt/ws/", ConfigurationName="WS.ServiceSoap")]
    public interface ServiceSoap {
        
        // CODEGEN: Generating message contract since element name GetAllPessoasResult from namespace http://www.ipca.pt/ws/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ipca.pt/ws/GetAllPessoas", ReplyAction="*")]
        ClienteSerializa.WS.GetAllPessoasResponse GetAllPessoas(ClienteSerializa.WS.GetAllPessoasRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ipca.pt/ws/GetAllPessoas", ReplyAction="*")]
        System.Threading.Tasks.Task<ClienteSerializa.WS.GetAllPessoasResponse> GetAllPessoasAsync(ClienteSerializa.WS.GetAllPessoasRequest request);
        
        // CODEGEN: Generating message contract since element name SetPessoas from namespace http://www.ipca.pt/ws/Pessoa is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ipca.pt/ws/GetAllPessoasII", ReplyAction="*")]
        ClienteSerializa.WS.GetAllPessoasIIResponse GetAllPessoasII(ClienteSerializa.WS.GetAllPessoasIIRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ipca.pt/ws/GetAllPessoasII", ReplyAction="*")]
        System.Threading.Tasks.Task<ClienteSerializa.WS.GetAllPessoasIIResponse> GetAllPessoasIIAsync(ClienteSerializa.WS.GetAllPessoasIIRequest request);
        
        // CODEGEN: Generating message contract since message part namespace (http://www.ipca.pt/ws/Pessoa) does not match the default value (http://www.ipca.pt/ws/)
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ipca.pt/ws/GetAllPessoasIII", ReplyAction="*")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="MuitasPessoas")]
        ClienteSerializa.WS.GetAllPessoasIIIResponse GetAllPessoasIII(ClienteSerializa.WS.GetAllPessoasIIIRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ipca.pt/ws/GetAllPessoasIII", ReplyAction="*")]
        System.Threading.Tasks.Task<ClienteSerializa.WS.GetAllPessoasIIIResponse> GetAllPessoasIIIAsync(ClienteSerializa.WS.GetAllPessoasIIIRequest request);
        
        // CODEGEN: Generating message contract since element name Humano from namespace http://www.ipca.pt/ws/Pessoa is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ipca.pt/ws/ShowPessoa", ReplyAction="*")]
        ClienteSerializa.WS.ShowPessoaResponse ShowPessoa(ClienteSerializa.WS.ShowPessoaRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ipca.pt/ws/ShowPessoa", ReplyAction="*")]
        System.Threading.Tasks.Task<ClienteSerializa.WS.ShowPessoaResponse> ShowPessoaAsync(ClienteSerializa.WS.ShowPessoaRequest request);
        
        // CODEGEN: Generating message contract since element name ShowBookResult from namespace http://www.ipca.pt/ws/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ipca.pt/ws/ShowBook", ReplyAction="*")]
        ClienteSerializa.WS.ShowBookResponse ShowBook(ClienteSerializa.WS.ShowBookRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.ipca.pt/ws/ShowBook", ReplyAction="*")]
        System.Threading.Tasks.Task<ClienteSerializa.WS.ShowBookResponse> ShowBookAsync(ClienteSerializa.WS.ShowBookRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetAllPessoasRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetAllPessoas", Namespace="http://www.ipca.pt/ws/", Order=0)]
        public ClienteSerializa.WS.GetAllPessoasRequestBody Body;
        
        public GetAllPessoasRequest() {
        }
        
        public GetAllPessoasRequest(ClienteSerializa.WS.GetAllPessoasRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class GetAllPessoasRequestBody {
        
        public GetAllPessoasRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetAllPessoasResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetAllPessoasResponse", Namespace="http://www.ipca.pt/ws/", Order=0)]
        public ClienteSerializa.WS.GetAllPessoasResponseBody Body;
        
        public GetAllPessoasResponse() {
        }
        
        public GetAllPessoasResponse(ClienteSerializa.WS.GetAllPessoasResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.ipca.pt/ws/")]
    public partial class GetAllPessoasResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public ClienteSerializa.WS.ArrayOfPessoa GetAllPessoasResult;
        
        public GetAllPessoasResponseBody() {
        }
        
        public GetAllPessoasResponseBody(ClienteSerializa.WS.ArrayOfPessoa GetAllPessoasResult) {
            this.GetAllPessoasResult = GetAllPessoasResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetAllPessoasIIRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetAllPessoasII", Namespace="http://www.ipca.pt/ws/", Order=0)]
        public ClienteSerializa.WS.GetAllPessoasIIRequestBody Body;
        
        public GetAllPessoasIIRequest() {
        }
        
        public GetAllPessoasIIRequest(ClienteSerializa.WS.GetAllPessoasIIRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class GetAllPessoasIIRequestBody {
        
        public GetAllPessoasIIRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetAllPessoasIIResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetAllPessoasIIResponse", Namespace="http://www.ipca.pt/ws/", Order=0)]
        public ClienteSerializa.WS.GetAllPessoasIIResponseBody Body;
        
        public GetAllPessoasIIResponse() {
        }
        
        public GetAllPessoasIIResponse(ClienteSerializa.WS.GetAllPessoasIIResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.ipca.pt/ws/Pessoa")]
    public partial class GetAllPessoasIIResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public ClienteSerializa.WS.MyPessoas SetPessoas;
        
        public GetAllPessoasIIResponseBody() {
        }
        
        public GetAllPessoasIIResponseBody(ClienteSerializa.WS.MyPessoas SetPessoas) {
            this.SetPessoas = SetPessoas;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetAllPessoasIII", WrapperNamespace="http://www.ipca.pt/ws/", IsWrapped=true)]
    public partial class GetAllPessoasIIIRequest {
        
        public GetAllPessoasIIIRequest() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetAllPessoasIIIResponse", WrapperNamespace="http://www.ipca.pt/ws/", IsWrapped=true)]
    public partial class GetAllPessoasIIIResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.ipca.pt/ws/Pessoa", Order=0)]
        public ClienteSerializa.WS.MyPessoasII MuitasPessoas;
        
        public GetAllPessoasIIIResponse() {
        }
        
        public GetAllPessoasIIIResponse(ClienteSerializa.WS.MyPessoasII MuitasPessoas) {
            this.MuitasPessoas = MuitasPessoas;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ShowPessoaRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ShowPessoa", Namespace="http://www.ipca.pt/ws/", Order=0)]
        public ClienteSerializa.WS.ShowPessoaRequestBody Body;
        
        public ShowPessoaRequest() {
        }
        
        public ShowPessoaRequest(ClienteSerializa.WS.ShowPessoaRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class ShowPessoaRequestBody {
        
        public ShowPessoaRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ShowPessoaResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ShowPessoaResponse", Namespace="http://www.ipca.pt/ws/", Order=0)]
        public ClienteSerializa.WS.ShowPessoaResponseBody Body;
        
        public ShowPessoaResponse() {
        }
        
        public ShowPessoaResponse(ClienteSerializa.WS.ShowPessoaResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.ipca.pt/ws/Pessoa")]
    public partial class ShowPessoaResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public ClienteSerializa.WS.Pessoa Humano;
        
        public ShowPessoaResponseBody() {
        }
        
        public ShowPessoaResponseBody(ClienteSerializa.WS.Pessoa Humano) {
            this.Humano = Humano;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ShowBookRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ShowBook", Namespace="http://www.ipca.pt/ws/", Order=0)]
        public ClienteSerializa.WS.ShowBookRequestBody Body;
        
        public ShowBookRequest() {
        }
        
        public ShowBookRequest(ClienteSerializa.WS.ShowBookRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class ShowBookRequestBody {
        
        public ShowBookRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ShowBookResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ShowBookResponse", Namespace="http://www.ipca.pt/ws/", Order=0)]
        public ClienteSerializa.WS.ShowBookResponseBody Body;
        
        public ShowBookResponse() {
        }
        
        public ShowBookResponse(ClienteSerializa.WS.ShowBookResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.ipca.pt/ws/")]
    public partial class ShowBookResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public ClienteSerializa.WS.Book ShowBookResult;
        
        public ShowBookResponseBody() {
        }
        
        public ShowBookResponseBody(ClienteSerializa.WS.Book ShowBookResult) {
            this.ShowBookResult = ShowBookResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ServiceSoapChannel : ClienteSerializa.WS.ServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceSoapClient : System.ServiceModel.ClientBase<ClienteSerializa.WS.ServiceSoap>, ClienteSerializa.WS.ServiceSoap {
        
        public ServiceSoapClient() {
        }
        
        public ServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ClienteSerializa.WS.GetAllPessoasResponse ClienteSerializa.WS.ServiceSoap.GetAllPessoas(ClienteSerializa.WS.GetAllPessoasRequest request) {
            return base.Channel.GetAllPessoas(request);
        }
        
        public ClienteSerializa.WS.ArrayOfPessoa GetAllPessoas() {
            ClienteSerializa.WS.GetAllPessoasRequest inValue = new ClienteSerializa.WS.GetAllPessoasRequest();
            inValue.Body = new ClienteSerializa.WS.GetAllPessoasRequestBody();
            ClienteSerializa.WS.GetAllPessoasResponse retVal = ((ClienteSerializa.WS.ServiceSoap)(this)).GetAllPessoas(inValue);
            return retVal.Body.GetAllPessoasResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ClienteSerializa.WS.GetAllPessoasResponse> ClienteSerializa.WS.ServiceSoap.GetAllPessoasAsync(ClienteSerializa.WS.GetAllPessoasRequest request) {
            return base.Channel.GetAllPessoasAsync(request);
        }
        
        public System.Threading.Tasks.Task<ClienteSerializa.WS.GetAllPessoasResponse> GetAllPessoasAsync() {
            ClienteSerializa.WS.GetAllPessoasRequest inValue = new ClienteSerializa.WS.GetAllPessoasRequest();
            inValue.Body = new ClienteSerializa.WS.GetAllPessoasRequestBody();
            return ((ClienteSerializa.WS.ServiceSoap)(this)).GetAllPessoasAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ClienteSerializa.WS.GetAllPessoasIIResponse ClienteSerializa.WS.ServiceSoap.GetAllPessoasII(ClienteSerializa.WS.GetAllPessoasIIRequest request) {
            return base.Channel.GetAllPessoasII(request);
        }
        
        public ClienteSerializa.WS.MyPessoas GetAllPessoasII() {
            ClienteSerializa.WS.GetAllPessoasIIRequest inValue = new ClienteSerializa.WS.GetAllPessoasIIRequest();
            inValue.Body = new ClienteSerializa.WS.GetAllPessoasIIRequestBody();
            ClienteSerializa.WS.GetAllPessoasIIResponse retVal = ((ClienteSerializa.WS.ServiceSoap)(this)).GetAllPessoasII(inValue);
            return retVal.Body.SetPessoas;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ClienteSerializa.WS.GetAllPessoasIIResponse> ClienteSerializa.WS.ServiceSoap.GetAllPessoasIIAsync(ClienteSerializa.WS.GetAllPessoasIIRequest request) {
            return base.Channel.GetAllPessoasIIAsync(request);
        }
        
        public System.Threading.Tasks.Task<ClienteSerializa.WS.GetAllPessoasIIResponse> GetAllPessoasIIAsync() {
            ClienteSerializa.WS.GetAllPessoasIIRequest inValue = new ClienteSerializa.WS.GetAllPessoasIIRequest();
            inValue.Body = new ClienteSerializa.WS.GetAllPessoasIIRequestBody();
            return ((ClienteSerializa.WS.ServiceSoap)(this)).GetAllPessoasIIAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ClienteSerializa.WS.GetAllPessoasIIIResponse ClienteSerializa.WS.ServiceSoap.GetAllPessoasIII(ClienteSerializa.WS.GetAllPessoasIIIRequest request) {
            return base.Channel.GetAllPessoasIII(request);
        }
        
        public ClienteSerializa.WS.MyPessoasII GetAllPessoasIII() {
            ClienteSerializa.WS.GetAllPessoasIIIRequest inValue = new ClienteSerializa.WS.GetAllPessoasIIIRequest();
            ClienteSerializa.WS.GetAllPessoasIIIResponse retVal = ((ClienteSerializa.WS.ServiceSoap)(this)).GetAllPessoasIII(inValue);
            return retVal.MuitasPessoas;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ClienteSerializa.WS.GetAllPessoasIIIResponse> ClienteSerializa.WS.ServiceSoap.GetAllPessoasIIIAsync(ClienteSerializa.WS.GetAllPessoasIIIRequest request) {
            return base.Channel.GetAllPessoasIIIAsync(request);
        }
        
        public System.Threading.Tasks.Task<ClienteSerializa.WS.GetAllPessoasIIIResponse> GetAllPessoasIIIAsync() {
            ClienteSerializa.WS.GetAllPessoasIIIRequest inValue = new ClienteSerializa.WS.GetAllPessoasIIIRequest();
            return ((ClienteSerializa.WS.ServiceSoap)(this)).GetAllPessoasIIIAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ClienteSerializa.WS.ShowPessoaResponse ClienteSerializa.WS.ServiceSoap.ShowPessoa(ClienteSerializa.WS.ShowPessoaRequest request) {
            return base.Channel.ShowPessoa(request);
        }
        
        public ClienteSerializa.WS.Pessoa ShowPessoa() {
            ClienteSerializa.WS.ShowPessoaRequest inValue = new ClienteSerializa.WS.ShowPessoaRequest();
            inValue.Body = new ClienteSerializa.WS.ShowPessoaRequestBody();
            ClienteSerializa.WS.ShowPessoaResponse retVal = ((ClienteSerializa.WS.ServiceSoap)(this)).ShowPessoa(inValue);
            return retVal.Body.Humano;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ClienteSerializa.WS.ShowPessoaResponse> ClienteSerializa.WS.ServiceSoap.ShowPessoaAsync(ClienteSerializa.WS.ShowPessoaRequest request) {
            return base.Channel.ShowPessoaAsync(request);
        }
        
        public System.Threading.Tasks.Task<ClienteSerializa.WS.ShowPessoaResponse> ShowPessoaAsync() {
            ClienteSerializa.WS.ShowPessoaRequest inValue = new ClienteSerializa.WS.ShowPessoaRequest();
            inValue.Body = new ClienteSerializa.WS.ShowPessoaRequestBody();
            return ((ClienteSerializa.WS.ServiceSoap)(this)).ShowPessoaAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ClienteSerializa.WS.ShowBookResponse ClienteSerializa.WS.ServiceSoap.ShowBook(ClienteSerializa.WS.ShowBookRequest request) {
            return base.Channel.ShowBook(request);
        }
        
        public ClienteSerializa.WS.Book ShowBook() {
            ClienteSerializa.WS.ShowBookRequest inValue = new ClienteSerializa.WS.ShowBookRequest();
            inValue.Body = new ClienteSerializa.WS.ShowBookRequestBody();
            ClienteSerializa.WS.ShowBookResponse retVal = ((ClienteSerializa.WS.ServiceSoap)(this)).ShowBook(inValue);
            return retVal.Body.ShowBookResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ClienteSerializa.WS.ShowBookResponse> ClienteSerializa.WS.ServiceSoap.ShowBookAsync(ClienteSerializa.WS.ShowBookRequest request) {
            return base.Channel.ShowBookAsync(request);
        }
        
        public System.Threading.Tasks.Task<ClienteSerializa.WS.ShowBookResponse> ShowBookAsync() {
            ClienteSerializa.WS.ShowBookRequest inValue = new ClienteSerializa.WS.ShowBookRequest();
            inValue.Body = new ClienteSerializa.WS.ShowBookRequestBody();
            return ((ClienteSerializa.WS.ServiceSoap)(this)).ShowBookAsync(inValue);
        }
    }
}

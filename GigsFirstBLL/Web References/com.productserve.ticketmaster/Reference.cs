﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.34003.
// 
#pragma warning disable 1591

namespace GigsFirstBLL.com.productserve.ticketmaster {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ServiceBinding", Namespace="http://ticketmaster.productserve.com/v2/soap.php")]
    [System.Xml.Serialization.SoapIncludeAttribute(typeof(Artist))]
    [System.Xml.Serialization.SoapIncludeAttribute(typeof(Event))]
    [System.Xml.Serialization.SoapIncludeAttribute(typeof(Request_Filter))]
    public partial class ServiceService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback findEventsOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ServiceService() {
            this.Url = global::GigsFirstBLL.Properties.Settings.Default.GigsFirstBLL_com_productserve_ticketmaster_ServiceService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event findEventsCompletedEventHandler findEventsCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://ticketmaster.productserve.com/v2/soap.php#findEvents", RequestNamespace="http://ticketmaster.productserve.com/v2/soap.php", ResponseNamespace="http://ticketmaster.productserve.com/v2/soap.php")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public Response findEvents(Request request) {
            object[] results = this.Invoke("findEvents", new object[] {
                        request});
            return ((Response)(results[0]));
        }
        
        /// <remarks/>
        public void findEventsAsync(Request request) {
            this.findEventsAsync(request, null);
        }
        
        /// <remarks/>
        public void findEventsAsync(Request request, object userState) {
            if ((this.findEventsOperationCompleted == null)) {
                this.findEventsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnfindEventsOperationCompleted);
            }
            this.InvokeAsync("findEvents", new object[] {
                        request}, this.findEventsOperationCompleted, userState);
        }
        
        private void OnfindEventsOperationCompleted(object arg) {
            if ((this.findEventsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.findEventsCompleted(this, new findEventsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="http://ticketmaster.productserve.com/v2/soap.php")]
    public partial class Request {
        
        private string apiKeyField;
        
        private string countryField;
        
        private System.Nullable<int> resultsPerPageField;
        
        private System.Nullable<int> currentPageField;
        
        private Request_Sort sortField;
        
        private Request_Filter[] filtersField;
        
        private string updatedSinceField;
        
        /// <remarks/>
        public string apiKey {
            get {
                return this.apiKeyField;
            }
            set {
                this.apiKeyField = value;
            }
        }
        
        /// <remarks/>
        public string country {
            get {
                return this.countryField;
            }
            set {
                this.countryField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public System.Nullable<int> resultsPerPage {
            get {
                return this.resultsPerPageField;
            }
            set {
                this.resultsPerPageField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public System.Nullable<int> currentPage {
            get {
                return this.currentPageField;
            }
            set {
                this.currentPageField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public Request_Sort sort {
            get {
                return this.sortField;
            }
            set {
                this.sortField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public Request_Filter[] filters {
            get {
                return this.filtersField;
            }
            set {
                this.filtersField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string updatedSince {
            get {
                return this.updatedSinceField;
            }
            set {
                this.updatedSinceField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="http://ticketmaster.productserve.com/v2/soap.php")]
    public partial class Request_Sort {
        
        private string fieldField;
        
        private string orderField;
        
        /// <remarks/>
        public string field {
            get {
                return this.fieldField;
            }
            set {
                this.fieldField = value;
            }
        }
        
        /// <remarks/>
        public string order {
            get {
                return this.orderField;
            }
            set {
                this.orderField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="http://ticketmaster.productserve.com/v2/soap.php")]
    public partial class Venue {
        
        private System.Nullable<int> venueIdField;
        
        private System.Nullable<int> ticketmasterVenueIdField;
        
        private string nameField;
        
        private string streetField;
        
        private string cityField;
        
        private string countryField;
        
        private string postcodeField;
        
        private string urlField;
        
        private string imageUrlField;
        
        private string stateField;
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public System.Nullable<int> venueId {
            get {
                return this.venueIdField;
            }
            set {
                this.venueIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public System.Nullable<int> ticketmasterVenueId {
            get {
                return this.ticketmasterVenueIdField;
            }
            set {
                this.ticketmasterVenueIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string street {
            get {
                return this.streetField;
            }
            set {
                this.streetField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string city {
            get {
                return this.cityField;
            }
            set {
                this.cityField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string country {
            get {
                return this.countryField;
            }
            set {
                this.countryField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string postcode {
            get {
                return this.postcodeField;
            }
            set {
                this.postcodeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string url {
            get {
                return this.urlField;
            }
            set {
                this.urlField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string imageUrl {
            get {
                return this.imageUrlField;
            }
            set {
                this.imageUrlField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string state {
            get {
                return this.stateField;
            }
            set {
                this.stateField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="http://ticketmaster.productserve.com/v2/soap.php")]
    public partial class Artist {
        
        private System.Nullable<int> artistIdField;
        
        private System.Nullable<int> ticketmasterArtistIdField;
        
        private string nameField;
        
        private string urlField;
        
        private string imageUrlField;
        
        private string categoryField;
        
        private System.Nullable<int> categoryIdField;
        
        private string parentCategoryField;
        
        private System.Nullable<int> parentCategoryIdField;
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public System.Nullable<int> artistId {
            get {
                return this.artistIdField;
            }
            set {
                this.artistIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public System.Nullable<int> ticketmasterArtistId {
            get {
                return this.ticketmasterArtistIdField;
            }
            set {
                this.ticketmasterArtistIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string url {
            get {
                return this.urlField;
            }
            set {
                this.urlField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string imageUrl {
            get {
                return this.imageUrlField;
            }
            set {
                this.imageUrlField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string category {
            get {
                return this.categoryField;
            }
            set {
                this.categoryField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public System.Nullable<int> categoryId {
            get {
                return this.categoryIdField;
            }
            set {
                this.categoryIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string parentCategory {
            get {
                return this.parentCategoryField;
            }
            set {
                this.parentCategoryField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public System.Nullable<int> parentCategoryId {
            get {
                return this.parentCategoryIdField;
            }
            set {
                this.parentCategoryIdField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="http://ticketmaster.productserve.com/v2/soap.php")]
    public partial class Event {
        
        private System.Nullable<int> eventIdField;
        
        private string ticketmasterEventIdField;
        
        private string statusField;
        
        private string nameField;
        
        private string urlField;
        
        private string eventDateField;
        
        private string onSaleDateField;
        
        private string preSaleDateField;
        
        private string categoryField;
        
        private System.Nullable<int> categoryIdField;
        
        private string parentCategoryField;
        
        private System.Nullable<int> parentCategoryIdField;
        
        private System.Nullable<float> minPriceField;
        
        private System.Nullable<float> maxPriceField;
        
        private Artist[] artistsField;
        
        private Venue venueField;
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public System.Nullable<int> eventId {
            get {
                return this.eventIdField;
            }
            set {
                this.eventIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string ticketmasterEventId {
            get {
                return this.ticketmasterEventIdField;
            }
            set {
                this.ticketmasterEventIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string url {
            get {
                return this.urlField;
            }
            set {
                this.urlField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string eventDate {
            get {
                return this.eventDateField;
            }
            set {
                this.eventDateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string onSaleDate {
            get {
                return this.onSaleDateField;
            }
            set {
                this.onSaleDateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string preSaleDate {
            get {
                return this.preSaleDateField;
            }
            set {
                this.preSaleDateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string category {
            get {
                return this.categoryField;
            }
            set {
                this.categoryField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public System.Nullable<int> categoryId {
            get {
                return this.categoryIdField;
            }
            set {
                this.categoryIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public string parentCategory {
            get {
                return this.parentCategoryField;
            }
            set {
                this.parentCategoryField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public System.Nullable<int> parentCategoryId {
            get {
                return this.parentCategoryIdField;
            }
            set {
                this.parentCategoryIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public System.Nullable<float> minPrice {
            get {
                return this.minPriceField;
            }
            set {
                this.minPriceField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public System.Nullable<float> maxPrice {
            get {
                return this.maxPriceField;
            }
            set {
                this.maxPriceField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public Artist[] artists {
            get {
                return this.artistsField;
            }
            set {
                this.artistsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public Venue venue {
            get {
                return this.venueField;
            }
            set {
                this.venueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="http://ticketmaster.productserve.com/v2/soap.php")]
    public partial class Details {
        
        private System.Nullable<int> totalResultsField;
        
        private System.Nullable<int> totalPagesField;
        
        private System.Nullable<int> currentPageField;
        
        private System.Nullable<int> resultsPerPageField;
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public System.Nullable<int> totalResults {
            get {
                return this.totalResultsField;
            }
            set {
                this.totalResultsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public System.Nullable<int> totalPages {
            get {
                return this.totalPagesField;
            }
            set {
                this.totalPagesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public System.Nullable<int> currentPage {
            get {
                return this.currentPageField;
            }
            set {
                this.currentPageField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public System.Nullable<int> resultsPerPage {
            get {
                return this.resultsPerPageField;
            }
            set {
                this.resultsPerPageField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="http://ticketmaster.productserve.com/v2/soap.php")]
    public partial class Response {
        
        private Details detailsField;
        
        private Event[] resultsField;
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public Details details {
            get {
                return this.detailsField;
            }
            set {
                this.detailsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
        public Event[] results {
            get {
                return this.resultsField;
            }
            set {
                this.resultsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="http://ticketmaster.productserve.com/v2/soap.php")]
    public partial class Request_Filter {
        
        private string objectField;
        
        private string fieldField;
        
        private object[] valuesField;
        
        /// <remarks/>
        public string @object {
            get {
                return this.objectField;
            }
            set {
                this.objectField = value;
            }
        }
        
        /// <remarks/>
        public string field {
            get {
                return this.fieldField;
            }
            set {
                this.fieldField = value;
            }
        }
        
        /// <remarks/>
        public object[] values {
            get {
                return this.valuesField;
            }
            set {
                this.valuesField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    public delegate void findEventsCompletedEventHandler(object sender, findEventsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.33440")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class findEventsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal findEventsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Response Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Response)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591
using System.Xml.Serialization;

namespace CMS
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Flows
    {

        private FlowsFlow[] itemsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Flow", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public FlowsFlow[] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class FlowsFlow
    {

        private FlowsFlowFlowElement[] flowElementField;

        private string nameField;

        private string flowTypeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FlowElement", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public FlowsFlowFlowElement[] FlowElement
        {
            get
            {
                return this.flowElementField;
            }
            set
            {
                this.flowElementField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FlowType
        {
            get
            {
                return this.flowTypeField;
            }
            set
            {
                this.flowTypeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class FlowsFlowFlowElement
    {

        private string flowElementTypeField;

        private bool homeField;

        private bool homeFieldSpecified;

        private bool lastField;

        private bool lastFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FlowElementType
        {
            get
            {
                return this.flowElementTypeField;
            }
            set
            {
                this.flowElementTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Home
        {
            get
            {
                return this.homeField;
            }
            set
            {
                this.homeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool HomeSpecified
        {
            get
            {
                return this.homeFieldSpecified;
            }
            set
            {
                this.homeFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Last
        {
            get
            {
                return this.lastField;
            }
            set
            {
                this.lastField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LastSpecified
        {
            get
            {
                return this.lastFieldSpecified;
            }
            set
            {
                this.lastFieldSpecified = value;
            }
        }
    }
}
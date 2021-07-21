using System.Runtime.Serialization;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Docfx2xml.Models.CustomXML.Enums
{
  [XmlType(Namespace = Namespaces.OpenSquiggly)]
  [JsonConverter(typeof(StringEnumConverter))]
  public enum InfoType
  {
    [XmlEnum("Class")]
    [EnumMember(Value = "class")]
    Class,
    
    [XmlEnum("Method")]
    [EnumMember(Value = "method")]
    Method,
    
    [XmlEnum("Enum")]
    [EnumMember(Value = "enum")]
    Enum,
    
    [XmlEnum("Property")]
    [EnumMember(Value = "property")]
    Property,
    
    [XmlEnum("Field")]
    [EnumMember(Value = "field")]
    Field,
    
    [XmlEnum("Interface")]
    [EnumMember(Value = "interface")]
    Interface,
    
    [XmlEnum("Struct")]
    [EnumMember(Value = "struct")]
    Struct,
    
    [XmlEnum("Constructor")]
    [EnumMember(Value = "constructor")]
    Constructor,
    
    [XmlEnum("Namespace")]
    [EnumMember(Value = "namespace")]
    Namespace,
    
    [XmlEnum("Delegate")]
    [EnumMember(Value = "delegate")]
    Delegate
  }
}
using System.Xml.Serialization;

namespace Docfx2xml.Models.CustomXML.Enums
{
  [XmlType(Namespace = Namespaces.OpenSquiggly)]
  public enum InfoType
  {
    [XmlEnum("Class")]
    Class,
    [XmlEnum("Method")]
    Method,
    [XmlEnum("Enum")]
    Enum,
    [XmlEnum("Property")]
    Property,
    [XmlEnum("Field")]
    Field,
    [XmlEnum("Interface")]
    Interface,
    [XmlEnum("Struct")]
    Struct,
    [XmlEnum("Constructor")]
    Constructor,
    [XmlEnum("Namespace")]
    Namespace,
    [XmlEnum("Delegate")]
    Delegate
  }
}
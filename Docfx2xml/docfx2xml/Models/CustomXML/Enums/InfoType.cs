using System.Xml.Serialization;

namespace Docfx2xml.Models.CustomXML.Enums
{
  [XmlType(Namespace = Namespaces.OpenSquiggly)]
  public enum InfoType
  {
    [XmlEnum("class")]
    Class,
    [XmlEnum("method")]
    Method,
    [XmlEnum("enum")]
    Enum,
    [XmlEnum("property")]
    Property,
    [XmlEnum("field")]
    Field,
    [XmlEnum("interface")]
    Interface,
    [XmlEnum("struct")]
    Struct,
    [XmlEnum("Constructor")]
    Constructor,
    [XmlEnum("Namespace")]
    Namespace
  }
}
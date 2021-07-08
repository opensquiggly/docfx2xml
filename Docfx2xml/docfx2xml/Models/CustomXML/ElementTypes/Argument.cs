using System.Xml.Serialization;

namespace Docfx2xml.Models.CustomXML.ElementTypes
{
  [XmlType(Namespace = Namespaces.OpenSquiggly)]
  public class Argument
  {
    [XmlElement(ElementName = "Type", Order = 1)]
    public string Type { get; set; }
    
    [XmlElement(ElementName = "Value", Order = 2)]
    public string Value { get; set; }
  }
}
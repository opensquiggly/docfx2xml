using System.Xml.Serialization;

namespace Docfx2xml.Models.CustomXML.ElementTypes
{
  [XmlType(Namespace = Namespaces.OpenSquiggly)]
  public class Return
  {
    [XmlElement(ElementName = "Type", Order = 1)]
    public string Type { get; set; }
    
    [XmlElement(ElementName = "Description", Order = 2)]
    public string Description { get; set; }
  }
}
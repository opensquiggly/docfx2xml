using System.Collections.Generic;
using System.Xml.Serialization;

namespace Docfx2xml.Models.CustomXML.ElementTypes
{
  [XmlType(Namespace = Namespaces.OpenSquiggly)]
  public class Parameter
  {
    [XmlElement(ElementName = "Name", Order = 1)]
    public string Name { get; set; }
    
    [XmlElement(ElementName= "Type", Order = 2)]
    public string Type { get; set; }
    
    [XmlElement(ElementName = "Description", Order = 3)]
    public string Description { get; set; }
    
    [XmlArray(ElementName = "Attributes", Order = 4)]
    [XmlArrayItem(ElementName = "Attribute", Type = typeof(Attribute))]
    public List<Attribute> Attributes { get; set; }
  }
}
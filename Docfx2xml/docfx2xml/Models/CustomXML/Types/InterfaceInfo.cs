using System.Collections.Generic;
using System.Xml.Serialization;
using Docfx2xml.Models.CustomXML.ElementTypes;

namespace Docfx2xml.Models.CustomXML.Types
{
  [XmlRoot(ElementName = "Interface", Namespace = Namespaces.OpenSquiggly)]
  public class InterfaceInfo : BaseInfo
  {
    [XmlArray(ElementName = "Methods", Order = 11)]
    [XmlArrayItem(ElementName = "Method", Type = typeof(Description))]
    public List<Description> Methods { get; set; }
    
    [XmlArray(ElementName = "Properties", Order = 12)]
    [XmlArrayItem(ElementName = "Property", Type = typeof(Description))]
    public List<Description> Properties { get; set; }
  }
}
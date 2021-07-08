using System.Collections.Generic;
using System.Xml.Serialization;
using Docfx2xml.Models.CustomXML.ElementTypes;

namespace Docfx2xml.Models.CustomXML.Types
{
  [XmlRoot(ElementName = "Interface", Namespace = Namespaces.OpenSquiggly)]
  public class InterfaceInfo : BaseInfo
  {
    [XmlElement(ElementName = "Comment", Order = 1)]
    public Description Description { get; set; }
    
    [XmlArray(ElementName = "Methods", Order = 2)]
    [XmlArrayItem(ElementName = "Method", Type = typeof(Description))]
    public List<Description> Method { get; set; }
  }
}
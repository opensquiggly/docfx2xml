using System.Xml.Serialization;
using Docfx2xml.Models.CustomXML.ElementTypes;

namespace Docfx2xml.Models.CustomXML.Types
{
  [XmlRoot(ElementName = "Namespace", Namespace = Namespaces.OpenSquiggly)]
  public class NamespaceInfo : BaseInfo
  {
    [XmlElement(ElementName = "Comment", Order = 1)]
    public Description Description { get; set; }
  }
}
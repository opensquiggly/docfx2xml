using System.Collections.Generic;
using System.Xml.Serialization;
using Docfx2xml.Models.CustomXML.ElementTypes;

namespace Docfx2xml.Models.CustomXML.Types
{
  [XmlRoot(ElementName = "Enum", Namespace = Namespaces.OpenSquiggly)]
  public class EnumInfo : BaseInfo
  {
    [XmlArray(ElementName = "Fields", Order = 11)]
    [XmlArrayItem(ElementName = "Field", Type = typeof(Description))]
    public List<Description> Fields { get; set; }
  }
}
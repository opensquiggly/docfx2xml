using System.Collections.Generic;
using System.Xml.Serialization;
using Docfx2xml.Models.CustomXML.ElementTypes;
using Newtonsoft.Json;

namespace Docfx2xml.Models.CustomXML.Types
{
  [XmlRoot(ElementName = "Enum", Namespace = Namespaces.OpenSquiggly)]
  [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
  public class EnumInfo : BaseInfo
  {
    [XmlArray(ElementName = "Fields", Order = 11)]
    [XmlArrayItem(ElementName = "Field", Type = typeof(Description))]
    [JsonProperty("fields", NullValueHandling = NullValueHandling.Ignore)]
    public List<Description> Fields { get; set; }
  }
}
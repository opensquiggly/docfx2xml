using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Docfx2xml.Models.CustomXML.ElementTypes
{
  [XmlType(Namespace = Namespaces.OpenSquiggly)]
  [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
  public class Return
  {
    [XmlElement(ElementName = "Type", Order = 1)]
    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    public string Type { get; set; }
    
    [XmlElement(ElementName = "Description", Order = 2)]
    [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
    public string Description { get; set; }
  }
}
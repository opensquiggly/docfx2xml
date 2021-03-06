using System.Collections.Generic;
using System.Xml.Serialization;
using Docfx2xml.Models.CustomXML.ElementTypes;
using Newtonsoft.Json;

namespace Docfx2xml.Models.CustomXML.Types
{
  [XmlRoot(ElementName = "Interface", Namespace = Namespaces.OpenSquiggly)]
  [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
  public class InterfaceInfo : BaseInfo
  {
    [XmlArray(ElementName = "Methods", Order = 11)]
    [XmlArrayItem(ElementName = "Method", Type = typeof(Description))]
    [JsonProperty("methods", NullValueHandling = NullValueHandling.Ignore)]
    public List<Description> Methods { get; set; }
    
    [XmlArray(ElementName = "Properties", Order = 12)]
    [XmlArrayItem(ElementName = "Property", Type = typeof(Description))]
    [JsonProperty("properties", NullValueHandling = NullValueHandling.Ignore)]
    public List<Description> Properties { get; set; }
  }
}
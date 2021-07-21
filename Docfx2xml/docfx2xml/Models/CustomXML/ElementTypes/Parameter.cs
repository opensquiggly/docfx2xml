using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Docfx2xml.Models.CustomXML.ElementTypes
{
  [XmlType(Namespace = Namespaces.OpenSquiggly)]
  [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
  public class Parameter
  {
    [XmlElement(ElementName = "Name", Order = 1)]
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }
    
    [XmlElement(ElementName= "Type", Order = 2)]
    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    public string Type { get; set; }
    
    [XmlElement(ElementName = "Description", Order = 3)]
    [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
    public string Description { get; set; }
    
    [XmlArray(ElementName = "Attributes", Order = 4)]
    [XmlArrayItem(ElementName = "Attribute", Type = typeof(Attribute))]
    [JsonProperty("attributes", NullValueHandling = NullValueHandling.Ignore)]
    public List<Attribute> Attributes { get; set; }
  }
}
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Docfx2xml.Models.CustomXML.ElementTypes
{
  [XmlType(Namespace = Namespaces.OpenSquiggly)]
  [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
  public class Attribute
  {
    [XmlElement(ElementName = "Type", Order = 1)]
    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    public string Type { get; set; }

    [XmlElement(ElementName = "Constructor", Order = 2)]
    [JsonProperty("constructor", NullValueHandling = NullValueHandling.Ignore)]
    public string Constructor { get; set; }

    [XmlElement(ElementName = "Argument", Order = 3)]
    [JsonProperty("arguments", NullValueHandling = NullValueHandling.Ignore)]
    public List<Argument> Arguments { get; set; }
    
    [XmlElement(ElementName = "NamedArgument", Order = 4)]
    [JsonProperty("namedArgument", NullValueHandling = NullValueHandling.Ignore)]
    public List<Argument> NamedArguments { get; set; }
  }
}
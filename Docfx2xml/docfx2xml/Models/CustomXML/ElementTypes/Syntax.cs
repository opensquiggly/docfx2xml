using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Docfx2xml.Models.CustomXML.ElementTypes
{
  [XmlType(Namespace = Namespaces.OpenSquiggly)]
  [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
  public class Syntax
  {
    [XmlElement(ElementName = "Content", Order = 1)]
    [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
    public string Content { get; set; }
    
    [XmlArray(ElementName = "Parameters", Order = 2)]
    [XmlArrayItem(ElementName = "Parameter", Type = typeof(Parameter))]
    [JsonProperty("parameters", NullValueHandling = NullValueHandling.Ignore)]
    public List<Parameter> Parameters { get; set; }
    
    [XmlElement(ElementName = "Return", Order = 3)]
    [JsonProperty("return", NullValueHandling = NullValueHandling.Ignore)]
    public Return Return { get; set; }
  }
}
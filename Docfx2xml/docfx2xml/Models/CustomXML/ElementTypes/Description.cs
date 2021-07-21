using System.Collections.Generic;
using System.Xml.Serialization;
using Docfx2xml.Models.CustomXML.Enums;
using Newtonsoft.Json;
using YamlDotNet.Serialization;

namespace Docfx2xml.Models.CustomXML.ElementTypes
{
  [XmlType(Namespace = Namespaces.OpenSquiggly)]
  [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
  public class Description
  {
    [XmlElement(ElementName = "Name", Order = 1)]
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }
    
    [XmlElement(ElementName = "NameWithType", Order = 2)]
    [JsonProperty("nameWithType", NullValueHandling = NullValueHandling.Ignore)]
    public string NameWithType { get; set; }
    
    [XmlElement(ElementName = "FullName", Order = 3)]
    [JsonProperty("fullName", NullValueHandling = NullValueHandling.Ignore)]
    public string FullName { get; set; }
    
    [XmlElement(ElementName = "Assembly", Order = 4)]
    [JsonProperty("assembly", NullValueHandling = NullValueHandling.Ignore)]
    public string Assembly { get; set; }
    
    [XmlElement(ElementName = "Summary", Order = 5)]
    [JsonProperty("summary", NullValueHandling = NullValueHandling.Ignore)]
    public string Summary { get; set; }
    
    [XmlElement(ElementName = "Syntax", Order = 6)]
    [JsonProperty("syntax", NullValueHandling = NullValueHandling.Ignore)]
    public Syntax Syntax { get; set; }
    
    [XmlElement(ElementName = "Source", Order = 7)]
    [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
    public Source Source { get; set; }

    [XmlArray(ElementName = "Parameters", Order = 8)]
    [XmlArrayItem(ElementName = "Parameter", Type = typeof(Parameter))]
    [JsonProperty("parameters", NullValueHandling = NullValueHandling.Ignore)]
    public List<Parameter> Parameters { get; set; }

    [XmlArray(ElementName = "Remarks", Order = 9)]
    [XmlArrayItem(ElementName = "Remark", Type = typeof(string))]
    [JsonProperty("remarks", NullValueHandling = NullValueHandling.Ignore)]
    public List<string> Remarks { get; set; }

    [XmlArray(ElementName = "Examples", Order = 10)]
    [XmlArrayItem(ElementName = "Example", Type = typeof(string))]
    [JsonProperty("examples", NullValueHandling = NullValueHandling.Ignore)]
    public List<string> Examples { get; set; }
    
    [XmlArray(ElementName = "Modifiers", Order = 11)]
    [XmlArrayItem(ElementName = "Modifier", Type = typeof(string))]
    [JsonProperty("modifiers", NullValueHandling = NullValueHandling.Ignore)]
    public List<string> Modifiers { get; set; }
    
    [XmlIgnore]
    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    public InfoType Type { get; set; }
  }
}
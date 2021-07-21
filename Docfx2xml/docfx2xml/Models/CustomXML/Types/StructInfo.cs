using System.Collections.Generic;
using System.Xml.Serialization;
using Docfx2xml.Models.CustomXML.ElementTypes;
using Newtonsoft.Json;

namespace Docfx2xml.Models.CustomXML.Types
{
  [XmlRoot(ElementName = "Struct", Namespace = Namespaces.OpenSquiggly)]
  [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
  public class StructInfo : BaseInfo
  {
    [XmlArray(ElementName = "Constructors", Order = 11)]
    [XmlArrayItem(ElementName = "Constructor", Type = typeof(Description))]
    [JsonProperty("constructors", NullValueHandling = NullValueHandling.Ignore)]
    public List<Description> Constructors { get; set; }
    
    [XmlArray(ElementName = "Properties", Order = 12)]
    [XmlArrayItem(ElementName = "Property", Type = typeof(Description))]
    [JsonProperty("properties", NullValueHandling = NullValueHandling.Ignore)]
    public List<Description> Properties { get; set; }
    
    [XmlArray(ElementName = "Fields", Order = 13)]
    [XmlArrayItem(ElementName = "Field", Type = typeof(Description))]
    [JsonProperty("fields", NullValueHandling = NullValueHandling.Ignore)]
    public List<Description> Fields { get; set; }
    
    [XmlArray(ElementName = "Methods", Order = 14)]
    [XmlArrayItem(ElementName = "Method", Type = typeof(Description))]
    [JsonProperty("methods", NullValueHandling = NullValueHandling.Ignore)]
    public List<Description> Methods { get; set; }
  }
}
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Docfx2xml.Models.CustomXML.ElementTypes
{
  [XmlType(Namespace = Namespaces.OpenSquiggly)]
  [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
  public class Source
  {
    [XmlElement(ElementName = "Name", Order = 1)]
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }
    
    [XmlElement(ElementName = "FilePath", Order = 2)]
    [JsonProperty("filePath", NullValueHandling = NullValueHandling.Ignore)]
    public string FilePath { get; set; }
    
    [XmlElement(ElementName = "Branch", Order = 3)]
    [JsonProperty("branch", NullValueHandling = NullValueHandling.Ignore)]
    public string Branch { get; set; }
    
    [XmlElement(ElementName = "Repository", Order = 4)]
    [JsonProperty("repo", NullValueHandling = NullValueHandling.Ignore)]
    public string Repo { get; set; }
    
    [XmlElement(ElementName = "StartLine", Order = 5)]
    [JsonProperty("startLine", NullValueHandling = NullValueHandling.Ignore)]
    public string StartLine { get; set; }
    
    [XmlElement(ElementName = "EndLine", Order = 6)]
    [JsonProperty("endLine", NullValueHandling = NullValueHandling.Ignore)]
    public string EndLine { get; set; }
  }
}
using System.Collections.Generic;
using System.Xml.Serialization;
using Docfx2xml.Models.CustomXML.ElementTypes;
using Newtonsoft.Json;

namespace Docfx2xml.Models.CustomXML
{
  public abstract class BaseInfo
  {
    private static readonly XmlSerializerNamespaces _xmlNamespaces = new XmlSerializerNamespaces();

    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces XmlNamespaces { get; set; } = new XmlSerializerNamespaces(_xmlNamespaces);

    protected BaseInfo()
    {
      _xmlNamespaces.Add(Namespaces.OpenSquigglyPrefix, Namespaces.OpenSquiggly);
    }
    
    [XmlElement(ElementName = "Name", Order = 1)]
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }
    
    [XmlElement(ElementName = "NameWithType", Order = 2)]
    [JsonProperty("nameWithType", NullValueHandling = NullValueHandling.Ignore)]
    public string NameWithType { get; set; }
    
    [XmlElement(ElementName = "FullName", Order = 3)]
    [JsonProperty("fullName", NullValueHandling = NullValueHandling.Ignore)]
    public string FullName { get; set; }
    
    [XmlElement(ElementName = "Summary", Order = 4)]
    [JsonProperty("summary", NullValueHandling = NullValueHandling.Ignore)]
    public string Summary { get; set; }
    
    [XmlArray(ElementName = "Languages", Order = 5)]
    [XmlArrayItem(ElementName = "Language", Type = typeof(string))]
    [JsonProperty("languages", NullValueHandling = NullValueHandling.Ignore)]
    public List<string> Languages { get; set; }
    
    [XmlElement(ElementName = "Namespace", Order = 6)]
    [JsonProperty("namespace", NullValueHandling = NullValueHandling.Ignore)]
    public string Namespace { get; set; }
    
    [XmlElement(ElementName = "Comment", Order = 7)]
    [JsonProperty("comment", NullValueHandling = NullValueHandling.Ignore)]
    public string Comment { get; set; }
    
    [XmlElement(ElementName = "Syntax", Order = 8)]
    [JsonProperty("syntax", NullValueHandling = NullValueHandling.Ignore)]
    public Syntax Syntax { get; set; }
    
    [XmlArray(ElementName = "Assemblies", Order = 9)]
    [XmlArrayItem(ElementName = "Assembly", Type = typeof(string))]
    [JsonProperty("assemblies", NullValueHandling = NullValueHandling.Ignore)]
    public List<string> Assemblies { get; set; }
    
    [XmlArray(ElementName = "Inheritances", Order = 10)]
    [XmlArrayItem(ElementName = "Inheritance", Type = typeof(string))]
    [JsonProperty("inheritance", NullValueHandling = NullValueHandling.Ignore)]
    public List<string> Inheritance { get; set; }
    
    [XmlArray(ElementName = "InheritedMembers", Order = 11)]
    [XmlArrayItem(ElementName = "InheritedMember", Type = typeof(string))]
    [JsonProperty("inheritedMembers", NullValueHandling = NullValueHandling.Ignore)]
    public List<string> InheritedMembers { get; set; }
  }
}
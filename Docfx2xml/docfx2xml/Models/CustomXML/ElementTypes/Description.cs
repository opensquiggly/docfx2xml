using System.Collections.Generic;
using System.Xml.Serialization;
using YamlDotNet.Serialization;

namespace Docfx2xml.Models.CustomXML.ElementTypes
{
  [XmlType(Namespace = Namespaces.OpenSquiggly)]
  public class Description
  {
    [XmlElement(ElementName = "Name", Order = 1)]
    public string Name { get; set; }
    
    [XmlElement(ElementName = "Comment", Order = 2)]
    public string Comment { get; set; }
    
    [XmlElement(ElementName = "ParentName", Order = 4)]
    public string ParentName { get; set; }
    
    [XmlArray(ElementName = "ChildrenNames", Order = 5)]
    [XmlArrayItem(ElementName = "ChildrenName", Type = typeof(string))]
    public List<string> Children { get; set; }
    
    [XmlElement(ElementName = "DisplayNameType", Order = 8)]
    public string NameWithType { get; set; }
    
    [XmlAttribute(AttributeName = "type")]
    public string Type { get; set; }
    
    [XmlElement(ElementName = "Source", Order = 10)]
    public Source Source { get; set; }
    
    [XmlArray(ElementName = "Assemblies", Order = 11)]
    [XmlArrayItem(ElementName = "Assembly", Type = typeof(string))]
    public List<string> Assemblies { get; set; }
    
    [XmlElement(ElementName = "Namespace", Order = 12)]
    public string Namespace { get; set; }
    
    [XmlArray(ElementName = "Implements", Order = 15)]
    [XmlArrayItem(ElementName = "Implement", Type = typeof(string))]
    public List<string> Implements { get; set; }
    
    [XmlElement(ElementName = "Attribute", Order = 17)]
    public List<AttributeInfo> Attributes { get; set; }
    
    [XmlArray(ElementName = "Modifiers", Order = 18)]
    [XmlArrayItem(ElementName = "Modifier", Type = typeof(string))]
    public List<string> ModifiersCSharp { get; set; }
    
    [XmlElement(ElementName = "Summary", Order = 21)]
    public string Summary { get; set; }
    
    [XmlArray(ElementName = "Examples", Order = 22)]
    [XmlArrayItem(ElementName = "Example", Type = typeof(string))]
    public List<string> Example { get; set; }
  }
}
using System.Collections.Generic;
using System.Xml.Serialization;
using Docfx2xml.Models.XML;
using YamlDotNet.Serialization;

namespace Docfx2xml.Models
{
  [XmlType(Namespace = Namespaces.OpenSquiggly)]
  public class AttributeInfo
  {
    /// <summary>
    /// The type of the item, such as class, method, etc.
    /// </summary>
    [YamlMember(Alias = "type")]
    [XmlAttribute(AttributeName = "type")]
    public string Type { get; set; }
    
    [YamlMember(Alias = "ctor")]
    [XmlElement(ElementName = "Constructor", Order = 1)]
    public string Ctor { get; set; }
    
    [YamlMember(Alias = "arguments")]
    [XmlElement(ElementName = "Argument", Order = 2)]
    public List<ArgumentInfo> Arguments { get; set; }
    
    [YamlMember(Alias = "namedArguments")]
    [XmlElement(ElementName = "NamedArgument", Order = 3)]
    public List<ArgumentInfo> NamedArguments { get; set; }
  }
}

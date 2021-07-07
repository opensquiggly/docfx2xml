using System.Collections.Generic;
using System.Xml.Serialization;
using Docfx2xml.Models.XML;
using YamlDotNet.Serialization;

namespace Docfx2xml.Models
{
  [XmlType(Namespace = Namespaces.OpenSquiggly)]
  public class ParameterInfo
  {
    /// <summary>
    /// The identifier of the item.
    /// </summary>
    [YamlMember(Alias = "id")]
    [XmlElement(ElementName = "ShortName", Order = 1)]
    public string Id { get; set; }
    
    /// <summary>
    /// The type of the item, such as class, method, etc.
    /// </summary>
    [YamlMember(Alias = "type")]
    [XmlAttribute(AttributeName = "type")]
    public string Type { get; set; }
    
    [YamlMember(Alias = "description")]
    [XmlElement(ElementName = "Description", Order = 2)]
    public string Description { get; set; }
    
    [YamlMember(Alias = "attributes")]
    [XmlElement(ElementName = "Attribute", Order = 3)]
    public List<AttributeInfo> Attributes { get; set; }
  }
}

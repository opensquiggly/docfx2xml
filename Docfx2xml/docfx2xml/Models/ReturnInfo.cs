using System.Xml.Serialization;
using Docfx2xml.Models.XML;
using YamlDotNet.Serialization;

namespace Docfx2xml.Models
{
  [XmlType(Namespace = Namespaces.OpenSquiggly)]
  public class ReturnInfo
  {
    /// <summary>
    /// The type of the item, such as class, method, etc.
    /// </summary>
    [YamlMember(Alias = "type")]
    [XmlAttribute(AttributeName = "type")]
    public string Type { get; set; }
    
    [YamlMember(Alias = "description")]
    [XmlElement(ElementName = "Description", Order = 1)]
    public string Description { get; set; }
  }
}

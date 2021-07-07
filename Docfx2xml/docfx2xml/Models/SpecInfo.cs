using System.Xml.Serialization;
using Docfx2xml.Models.XML;
using YamlDotNet.Serialization;

namespace Docfx2xml.Models
{
  [XmlType(Namespace = Namespaces.OpenSquiggly)]
  public class SpecInfo
  {
    /// <summary>
    /// The unique identifier of the item.
    /// </summary>
    [YamlMember(Alias = "uid")]
    [XmlElement(ElementName = "Name", Order = 1)]
    public string UId { get; set; }
    
    /// <summary>
    /// The display name of the item.
    /// </summary>
    [YamlMember(Alias = "name")]
    [XmlElement(ElementName = "DisplayName", Order = 2)]
    public string Name { get; set; }
    
    [YamlMember(Alias = "nameWithType")]
    [XmlElement(ElementName = "DisplayNameType", Order = 3)]
    public string NameWithType { get; set; }
    
    /// <summary>
    /// The full display name of the item. In programming languages, it's usually the full qualified name.
    /// </summary>
    [YamlMember(Alias = "fullName")]
    [XmlElement(ElementName = "DisplayFullName", Order = 4)]
    public string FullName { get; set; }
    
    [YamlMember(Alias = "isExternal")]
    [XmlElement(ElementName = "IsExternal", Order = 5)]
    public bool IsExternal { get; set; }
  }
}

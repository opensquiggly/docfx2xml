using System.Collections.Generic;
using System.Xml.Serialization;
using Docfx2xml.Models.XML;
using YamlDotNet.Serialization;

namespace Docfx2xml.Models
{
  [XmlType(Namespace = Namespaces.OpenSquiggly)]
  public class ReferenceInfo
  {
    /// <summary>
    /// The unique identifier of the item.
    /// </summary>
    [YamlMember(Alias = "uid")]
    [XmlElement(ElementName = "Name", Order = 1)]
    public string UId { get; set; }
    
    [YamlMember(Alias = "commentId")]
    [XmlElement(ElementName = "Comment", Order = 2)]
    public string CommentId { get; set; }

    /// <summary>
    /// The UID of the item's parent. If omitted, metadata parser will try to figure out its parent from the children information of other items within the same file.
    /// </summary>
    [YamlMember(Alias = "parent")]
    [XmlElement(ElementName = "ParentName", Order = 3)]
    public string Parent { get; set; }
    
    [YamlMember(Alias = "isExternal")]
    [XmlElement(ElementName = "IsExternal", Order = 4)]
    public bool IsExternal { get; set; }
    
    [YamlMember(Alias = "definition")]
    [XmlElement(ElementName = "Definition", Order = 5)]
    public string Definition { get; set; }

    /// <summary>
    /// The display name of the item.
    /// </summary>
    [YamlMember(Alias = "name")]
    [XmlElement(ElementName = "DisplayName", Order = 6)]
    public string Name { get; set; }

    [YamlMember(Alias = "nameWithType")]
    [XmlElement(ElementName = "DisplayNameType", Order = 7)]
    public string NameWithType { get; set; }

    [YamlMember(Alias = "fullName")]
    [XmlElement(ElementName = "DisplayFullName", Order = 8)]
    public string FullName { get; set; }

    [YamlMember(Alias = "spec.csharp")]
    [XmlElement(ElementName = "Spec", Order = 9)]
    public List<SpecInfo> SpecCSharp { get; set; }
  }
}

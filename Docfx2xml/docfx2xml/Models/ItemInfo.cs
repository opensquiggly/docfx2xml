using System.Collections.Generic;
using System.Xml.Serialization;
using Docfx2xml.Models.XML;
using YamlDotNet.Serialization;

namespace Docfx2xml.Models
{
  [XmlType(Namespace = Namespaces.OpenSquiggly)]
  public class ItemInfo
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
    /// The identifier of the item.
    /// </summary>
    [YamlMember(Alias = "id")]
    [XmlElement(ElementName = "ShortName", Order = 3)]
    public string Id { get; set; }
    
    /// <summary>
    /// The UID of the item's parent. If omitted, metadata parser will try to figure out its parent from the children information of other items within the same file.
    /// </summary>
    [YamlMember(Alias = "parent")]
    [XmlElement(ElementName = "ParentName", Order = 4)]
    public string Parent { get; set; }
    
    /// <summary>
    ///  A list of UIDs of the item's children. Can be omitted if there are no children.
    /// </summary>
    [YamlMember(Alias = "children")]
    [XmlArray(ElementName = "ChildrenNames", Order = 5)]
    [XmlArrayItem(ElementName = "ChildrenName", Type = typeof(string))]
    public List<string> Children { get; set; }
    
    [YamlMember(Alias = "langs")]
    [XmlArray(ElementName = "Languages", Order = 6)]
    [XmlArrayItem(ElementName = "Language", Type = typeof(string))]
    public List<string> Langs { get; set; }
    
    /// <summary>
    /// The display name of the item.
    /// </summary>
    [YamlMember(Alias = "name")]
    [XmlElement(ElementName = "DisplayName", Order = 7)]
    public string Name { get; set; }

    [YamlMember(Alias = "nameWithType")]
    [XmlElement(ElementName = "DisplayNameType", Order = 8)]
    public string NameWithType { get; set; }

    /// <summary>
    /// The full display name of the item. In programming languages, it's usually the full qualified name.
    /// </summary>
    [YamlMember(Alias = "fullName")]
    [XmlElement(ElementName = "DisplayFullName", Order = 9)]
    public string FullName { get; set; }

    /// <summary>
    /// The type of the item, such as class, method, etc.
    /// </summary>
    [YamlMember(Alias = "type")]
    [XmlAttribute(AttributeName = "type")]
    public string Type { get; set; }
    
    /// <summary>
    /// The source code information of the item.
    /// </summary>
    [YamlMember(Alias = "source")]
    [XmlElement(ElementName = "Source", Order = 10)]
    public SourceInfo Source { get; set; }
    
    [YamlMember(Alias = "assemblies")]
    [XmlArray(ElementName = "Assemblies", Order = 11)]
    [XmlArrayItem(ElementName = "Assembly", Type = typeof(string))]
    public List<string> Assemblies { get; set; }
    
    [YamlMember(Alias = "namespace")]
    [XmlElement(ElementName = "Namespace", Order = 12)]
    public string Namespace { get; set; }
    
    [YamlMember(Alias = "syntax")]
    [XmlElement(ElementName = "Syntax", Order = 13)]
    public SyntaxInfo Syntax { get; set; }
    
    [YamlMember(Alias = "inheritance")]
    [XmlArray(ElementName = "Inheritances", Order = 14)]
    [XmlArrayItem(ElementName = "Inheritance", Type = typeof(string))]
    public List<string> Inheritance { get; set; }
    
    [YamlMember(Alias = "implements")]
    [XmlArray(ElementName = "Implements", Order = 15)]
    [XmlArrayItem(ElementName = "Implement", Type = typeof(string))]
    public List<string> Implements { get; set; }
    
    [YamlMember(Alias = "inheritedMembers")]
    [XmlArray(ElementName = "InheritedMembers", Order = 16)]
    [XmlArrayItem(ElementName = "InheritedMember", Type = typeof(string))]
    public List<string> InheritedMembers { get; set; }
    
    [YamlMember(Alias = "attributes")]
    [XmlElement(ElementName = "Attribute", Order = 17)]
    public List<AttributeInfo> Attributes { get; set; }
    
    [YamlMember(Alias = "modifiers.csharp")]
    [XmlArray(ElementName = "Modifiers", Order = 18)]
    [XmlArrayItem(ElementName = "Modifier", Type = typeof(string))]
    public List<string> ModifiersCSharp { get; set; }
    
    [YamlMember(Alias = "modifiers.vb")]
    [XmlIgnore]
    public List<string> ModifiersVb { get; set; }
    
    [YamlMember(Alias = "overload")]
    [XmlElement(ElementName = "Overload", Order = 19)]
    public string Overload { get; set; }
    
    [YamlMember(Alias = "overridden")]
    [XmlElement(ElementName = "ElementName", Order = 20)]
    public string Overridden { get; set; }
    
    [YamlMember(Alias = "summary")]
    [XmlElement(ElementName = "Summary", Order = 21)]
    public string Summary { get; set; }
    
    [YamlMember(Alias = "example")]
    [XmlArray(ElementName = "Examples", Order = 22)]
    [XmlArrayItem(ElementName = "Example", Type = typeof(string))]
    public List<string> Example { get; set; }
  }
}

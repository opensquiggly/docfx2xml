using System.Xml.Serialization;
using Docfx2xml.Models.XML;
using YamlDotNet.Serialization;

namespace Docfx2xml.Models
{
  [XmlType(Namespace = Namespaces.OpenSquiggly)]
  public class SourceInfo
  {
    [YamlMember(Alias = "remote")]
    [XmlElement(ElementName = "Remote", Order = 1)]
    public RemoteInfo Remote { get; set; }
    
    /// <summary>
    /// The identifier of the item.
    /// </summary>
    [YamlMember(Alias = "id")]
    [XmlElement(ElementName = "ShortName", Order = 2)]
    public string Id { get; set; }
    
    /// <summary>
    /// the path to the source code file where the item is defined.
    /// </summary>
    [YamlMember(Alias = "path")]
    [XmlElement(ElementName = "FilePath", Order = 3)]
    public string Path { get; set; }
    
    /// <summary>
    /// the branch of the source code.
    /// </summary>
    [YamlMember(Alias = "branch")]
    [XmlElement(ElementName = "Branch", Order = 4)]
    public string Branch { get; set; }
    
    /// <summary>
    /// the remote Git repository of the source code.
    /// </summary>
    [YamlMember(Alias = "repo")]
    [XmlElement(ElementName = "Repository", Order = 5)]
    public string Repo { get; set; }
    
    /// <summary>
    /// the Git revision of the source code.
    /// </summary>
    [YamlMember(Alias = "revision")]
    [XmlElement(ElementName = "Revision", Order = 6)]
    public string Revision { get; set; }
    
    /// <summary>
    /// the start line of the item definition.
    /// </summary>
    [YamlMember(Alias = "startLine")]
    [XmlAttribute(AttributeName = "startLine")]
    public string StartLine { get; set; }
    
    /// <summary>
    ///  the end line of the item definition.
    /// </summary>
    [YamlMember(Alias = "endLine")]
    [XmlAttribute(AttributeName = "endLine")]
    public string EndLine { get; set; }
  }
}

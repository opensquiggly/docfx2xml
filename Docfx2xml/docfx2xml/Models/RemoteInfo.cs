using System.Xml.Serialization;
using Docfx2xml.Models.XML;
using YamlDotNet.Serialization;

namespace Docfx2xml.Models
{
  [XmlType(Namespace = Namespaces.OpenSquiggly)]
  public class RemoteInfo
  {
    /// <summary>
    /// the path to the source code file where the item is defined.
    /// </summary>
    [YamlMember(Alias = "path")]
    [XmlElement(ElementName = "FilePath", Order = 1)]
    public string Path { get; set; }
    
    /// <summary>
    /// the branch of the source code.
    /// </summary>
    [YamlMember(Alias = "branch")]
    [XmlElement(ElementName = "Branch", Order = 2)]
    public string Branch { get; set; }
    
    /// <summary>
    /// the remote Git repository of the source code.
    /// </summary>
    [YamlMember(Alias = "repo")]
    [XmlElement(ElementName = "Repository", Order = 3)]
    public string Repo { get; set; }
  }
}

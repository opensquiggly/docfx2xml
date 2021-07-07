using System.Collections.Generic;
using System.Xml.Serialization;
using Docfx2xml.Models.XML;
using YamlDotNet.Serialization;

namespace Docfx2xml.Models
{
  [XmlType(Namespace = Namespaces.OpenSquiggly)]
  public class SyntaxInfo
  {
    [YamlMember(Alias = "content")]
    [XmlElement(ElementName = "Content", Order = 1)]
    public string Content { get; set; }
    
    [YamlMember(Alias = "content.vb")]
    [XmlIgnore]
    public string ContentVb { get; set; }
    
    [YamlMember(Alias = "parameters")]
    [XmlElement(ElementName = "Parameter", Order = 2)]
    public List<ParameterInfo> Parameters { get; set; }
    
    [YamlMember(Alias = "return")]
    [XmlElement(ElementName = "Return", Order = 3)]
    public ReturnInfo Return { get; set; }
  }
}

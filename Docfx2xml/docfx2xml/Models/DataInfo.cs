using System.Collections.Generic;
using System.Xml.Serialization;
using Docfx2xml.Models.XML;
using YamlDotNet.Serialization;

namespace Docfx2xml.Models
{
  [XmlRoot(ElementName = "Info", Namespace = Namespaces.OpenSquiggly)]
  public class DataInfo
  {
    private static XmlSerializerNamespaces _xmlNamespaces = new XmlSerializerNamespaces();

    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces XmlNamespaces { get; set; } = new XmlSerializerNamespaces(_xmlNamespaces); 
    
    [YamlMember(Alias = "items")]
    [XmlElement(ElementName = "Item", Namespace = Namespaces.OpenSquiggly, Order = 1)]
    public List<ItemInfo> Items { get; set; }

    [YamlMember(Alias = "references")]
    [XmlElement(ElementName = "Reference", Namespace = Namespaces.OpenSquiggly, Order = 2)]
    public List<ReferenceInfo> References { get; set; }

    public DataInfo()
    {
      _xmlNamespaces.Add(Namespaces.OpenSquiggly_Prefix, Namespaces.OpenSquiggly);
    }
  }
}

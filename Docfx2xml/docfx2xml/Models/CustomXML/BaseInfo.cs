using System.Collections.Generic;
using System.Xml.Serialization;
using Docfx2xml.Models.CustomXML.ElementTypes;

namespace Docfx2xml.Models.CustomXML
{
  public abstract class BaseInfo
  {
    private static readonly XmlSerializerNamespaces _xmlNamespaces = new XmlSerializerNamespaces();

    [XmlNamespaceDeclarations]
    public XmlSerializerNamespaces XmlNamespaces { get; set; } = new XmlSerializerNamespaces(_xmlNamespaces);

    protected BaseInfo()
    {
      _xmlNamespaces.Add(Namespaces.OpenSquigglyPrefix, Namespaces.OpenSquiggly);
    }
    
    [XmlElement(ElementName = "Name", Order = 1)]
    public string Name { get; set; }
    
    [XmlElement(ElementName = "NameWithType", Order = 2)]
    public string NameWithType { get; set; }
    
    [XmlElement(ElementName = "FullName", Order = 3)]
    public string FullName { get; set; }
    
    [XmlArray(ElementName = "Languages", Order = 4)]
    [XmlArrayItem(ElementName = "Language", Type = typeof(string))]
    public List<string> Languages { get; set; }
    
    [XmlElement(ElementName = "Namespace", Order = 5)]
    public string Namespace { get; set; }
    
    [XmlElement(ElementName = "Comment", Order = 6)]
    public string Comment { get; set; }
    
    [XmlElement(ElementName = "Syntax", Order = 7)]
    public Syntax Syntax { get; set; }
    
    [XmlArray(ElementName = "Assemblies", Order = 8)]
    [XmlArrayItem(ElementName = "Assembly", Type = typeof(string))]
    public List<string> Assemblies { get; set; }
    
    [XmlArray(ElementName = "Inheritances", Order = 9)]
    [XmlArrayItem(ElementName = "Inheritance", Type = typeof(string))]
    public List<string> Inheritance { get; set; }
    
    [XmlArray(ElementName = "InheritedMembers", Order = 10)]
    [XmlArrayItem(ElementName = "InheritedMember", Type = typeof(string))]
    public List<string> InheritedMembers { get; set; }
  }
}
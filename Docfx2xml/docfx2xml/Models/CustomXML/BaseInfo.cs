using System.Xml.Serialization;

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
  }
}
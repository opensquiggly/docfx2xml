using System.Xml.Serialization;

namespace Docfx2xml.Models.CustomXML.Types
{
  [XmlRoot(ElementName = "Delegate", Namespace = Namespaces.OpenSquiggly)]
  public class DelegateInfo : BaseInfo
  {
    // contains only base info
  }
}
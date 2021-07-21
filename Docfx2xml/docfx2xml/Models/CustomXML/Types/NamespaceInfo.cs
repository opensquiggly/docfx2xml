using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Docfx2xml.Models.CustomXML.Types
{
  [XmlRoot(ElementName = "Namespace", Namespace = Namespaces.OpenSquiggly)]
  [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
  public class NamespaceInfo : BaseInfo
  {
    // contains only base info
  }
}
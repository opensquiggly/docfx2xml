using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Docfx2xml.Models.CustomXML.Types
{
  [XmlRoot(ElementName = "Delegate", Namespace = Namespaces.OpenSquiggly)]
  [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
  public class DelegateInfo : BaseInfo
  {
    // contains only base info
  }
}
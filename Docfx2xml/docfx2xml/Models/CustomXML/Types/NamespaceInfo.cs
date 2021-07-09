﻿using System.Xml.Serialization;

namespace Docfx2xml.Models.CustomXML.Types
{
  [XmlRoot(ElementName = "Namespace", Namespace = Namespaces.OpenSquiggly)]
  public class NamespaceInfo : BaseInfo
  {
    // contains only base info
  }
}
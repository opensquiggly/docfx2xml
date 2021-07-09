using System.Collections.Generic;
using System.Xml.Serialization;
using Docfx2xml.Models.CustomXML.ElementTypes;

namespace Docfx2xml.Models.CustomXML.Types
{
  [XmlRoot(ElementName = "Struct", Namespace = Namespaces.OpenSquiggly)]
  public class StructInfo : BaseInfo
  {
    [XmlArray(ElementName = "Constructors", Order = 11)]
    [XmlArrayItem(ElementName = "Constructor", Type = typeof(Description))]
    public List<Description> Constructors { get; set; }
    
    [XmlArray(ElementName = "Properties", Order = 12)]
    [XmlArrayItem(ElementName = "Property", Type = typeof(Description))]
    public List<Description> Properties { get; set; }
    
    [XmlArray(ElementName = "Fields", Order = 13)]
    [XmlArrayItem(ElementName = "Field", Type = typeof(Description))]
    public List<Description> Fields { get; set; }
    
    [XmlArray(ElementName = "Methods", Order = 14)]
    [XmlArrayItem(ElementName = "Method", Type = typeof(Description))]
    public List<Description> Methods { get; set; }
  }
}
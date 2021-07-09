using System.Collections.Generic;
using System.Xml.Serialization;

namespace Docfx2xml.Models.CustomXML.ElementTypes
{
  [XmlType(Namespace = Namespaces.OpenSquiggly)]
  public class Syntax
  {
    [XmlElement(ElementName = "Content", Order = 1)]
    public string Content { get; set; }
    
    [XmlArray(ElementName = "Parameters", Order = 2)]
    [XmlArrayItem(ElementName = "Parameter", Type = typeof(Parameter))]
    public List<Parameter> Parameters { get; set; }
    
    [XmlElement(ElementName = "Return", Order = 3)]
    public Return Return { get; set; }
  }
}
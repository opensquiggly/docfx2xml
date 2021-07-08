using System.Collections.Generic;
using System.Xml.Serialization;

namespace Docfx2xml.Models.CustomXML.ElementTypes
{
  [XmlType(Namespace = Namespaces.OpenSquiggly)]
  public class Attribute
  {
    [XmlElement(ElementName = "Type", Order = 1)]
    public string Type { get; set; }

    [XmlElement(ElementName = "Constructor", Order = 2)]
    public string Constructor { get; set; }

    [XmlElement(ElementName = "Argument", Order = 3)]
    public List<Argument> Arguments { get; set; }
    
    [XmlElement(ElementName = "NamedArgument", Order = 4)]
    public List<Argument> NamedArguments { get; set; }
  }
}
using System.Collections.Generic;
using System.Xml.Serialization;
using Docfx2xml.Models.CustomXML.Enums;
using YamlDotNet.Serialization;

namespace Docfx2xml.Models.CustomXML.ElementTypes
{
  [XmlType(Namespace = Namespaces.OpenSquiggly)]
  public class Description
  {
    [XmlElement(ElementName = "Name", Order = 1)]
    public string Name { get; set; }
    
    [XmlElement(ElementName = "NameWithType", Order = 2)]
    public string NameWithType { get; set; }
    
    [XmlElement(ElementName = "FullName", Order = 3)]
    public string FullName { get; set; }
    
    [XmlElement(ElementName = "Assembly", Order = 4)]
    public string Assembly { get; set; }
    
    [XmlElement(ElementName = "Summary", Order = 5)]
    public string Summary { get; set; }
    
    [XmlElement(ElementName = "Syntax", Order = 6)]
    public Syntax Syntax { get; set; }
    
    [XmlElement(ElementName = "Source", Order = 7)]
    public Source Source { get; set; }

    [XmlArray(ElementName = "Parameters", Order = 8)]
    [XmlArrayItem(ElementName = "Parameter", Type = typeof(Parameter))]
    public List<Parameter> Parameters { get; set; }

    [XmlArray(ElementName = "Remarks", Order = 9)]
    [XmlArrayItem(ElementName = "Remark", Type = typeof(string))]
    public List<string> Remarks { get; set; }

    [XmlArray(ElementName = "Examples", Order = 10)]
    [XmlArrayItem(ElementName = "Example", Type = typeof(string))]
    public List<string> Examples { get; set; }
    
    [XmlArray(ElementName = "Modifiers", Order = 11)]
    [XmlArrayItem(ElementName = "Modifier", Type = typeof(string))]
    public List<string> Modifiers { get; set; }
    
    [XmlIgnore]
    public InfoType Type { get; set; }
  }
}
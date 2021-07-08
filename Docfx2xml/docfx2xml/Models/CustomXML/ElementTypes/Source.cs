using System.Xml.Serialization;

namespace Docfx2xml.Models.CustomXML.ElementTypes
{
  [XmlType(Namespace = Namespaces.OpenSquiggly)]
  public class Source
  {
    [XmlElement(ElementName = "Name", Order = 1)]
    public string Name { get; set; }
    
    [XmlElement(ElementName = "FilePath", Order = 2)]
    public string FilePath { get; set; }
    
    [XmlElement(ElementName = "Branch", Order = 3)]
    public string Branch { get; set; }
    
    [XmlElement(ElementName = "Repository", Order = 4)]
    public string Repo { get; set; }
    
    [XmlElement(ElementName = "StartLine", Order = 5)]
    public string StartLine { get; set; }
    
    [XmlElement(ElementName = "EndLine", Order = 6)]
    public string EndLine { get; set; }
  }
}
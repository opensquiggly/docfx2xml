using System.Xml.Serialization;
using Docfx2xml.XmlConverter;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Docfx2xml.Configuration
{
  [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
  [XmlRoot(ElementName = "ConvertConfiguration")]
  public class ConvertConfiguration
  {
    [JsonProperty("yamlDataPath", Required = Required.Always)] 
    [XmlElement(ElementName = "YamlDataPath", IsNullable = false)] 
    public string YamlDataPath { get; set; }

    [JsonProperty("xmlOutPath", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)] 
    [XmlElement(ElementName = "XmlOutPath", IsNullable = false)] 
    public string XmlOutPath { get; set; }

    [JsonProperty("xsltFilePath", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)] 
    [XmlElement(ElementName = "XsltFilePath", IsNullable = true)] 
    public string XsltFilePath { get; set; }
    
    [JsonProperty("saveToNamespaceFolders", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)] 
    [XmlElement(ElementName = "SaveToNamespaceFolders", IsNullable = false)] 
    public bool SaveToNamespaceFolders { get; set; }

    [JsonProperty("xmlConverterType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    [XmlElement(ElementName = "XmlConverterType", IsNullable = false)]
    public XmlConverterType XmlConverterType { get; set; }
    
    [JsonProperty("buildTocLessTreeFiles", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)] 
    [XmlElement(ElementName = "BuildTocLessTreeFiles", IsNullable = false)] 
    public bool BuildTocLessTreeFiles { get; set; }
  }
}

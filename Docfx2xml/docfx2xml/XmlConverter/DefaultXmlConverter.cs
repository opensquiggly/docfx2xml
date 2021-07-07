using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Docfx2xml.Models;

namespace Docfx2xml.XmlConverter
{
  public class DefaultXmlConverter : IXmlConverter
  {
    public XmlDocument ConvertToDoc(DataInfo data, string xsltFile)
    {
      var ser = new XmlSerializer(data.GetType());
      using var memStm = new MemoryStream();
      ser.Serialize(memStm, data);
      memStm.Position = 0;
      var settings = new XmlReaderSettings
      {
        IgnoreWhitespace = true
      };
      using var xtr = XmlReader.Create(memStm, settings);
      var document = new XmlDocument();
      document.Load(xtr);
      
      if (!string.IsNullOrEmpty(xsltFile))
      {
        var processingInstruction = document.CreateProcessingInstruction(
          "xml-stylesheet",
          $"type='text/xsl' href='{xsltFile}'");
        document.InsertAfter(processingInstruction, document.FirstChild);
      }
      
      return document;
    }
  }
}

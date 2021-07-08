using System.Xml;
using Docfx2xml.Models;

namespace Docfx2xml.XmlConverter.Implements
{
  public class DefaultXmlConverter : XmlConverterBase
  {
    public override XmlDocument ConvertToDoc(DataInfo data, string xsltFile)
    {
      return ToXmlDocumentDoc(data, xsltFile);
    }
  }
}

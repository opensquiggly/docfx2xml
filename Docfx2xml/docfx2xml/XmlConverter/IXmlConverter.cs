using System.Xml;
using Docfx2xml.Models;

namespace Docfx2xml.XmlConverter
{
  public interface IXmlConverter
  {
    XmlDocument ConvertToDoc(DataInfo data, string xsltFilePath);
  }
}

using System;
using System.Linq;
using System.Xml;
using Docfx2xml.Models;
using Docfx2xml.Models.CustomXML;
using Docfx2xml.Models.CustomXML.Enums;

namespace Docfx2xml.XmlConverter.Implements
{
  public class CustomIgnoreNamespaceConverter : XmlConverterBase
  {
    public override XmlDocument ConvertToDoc(DataInfo data, string xsltFilePath)
    {
      var dataType = data.Items.FirstOrDefault()?.Type;
      return Enum.TryParse(dataType, true, out InfoType parseResult)
        ? parseResult switch
        {
          InfoType.Class => ToXmlDocumentDoc(XmlMapper.ToClassInfo(data), xsltFilePath),
          InfoType.Enum => ToXmlDocumentDoc(XmlMapper.ToEnumInfo(data), xsltFilePath),
          InfoType.Interface => ToXmlDocumentDoc(XmlMapper.ToInterfaceInfo(data), xsltFilePath),
          InfoType.Struct => ToXmlDocumentDoc(XmlMapper.ToStructInfo(data), xsltFilePath),
          InfoType.Delegate => ToXmlDocumentDoc(XmlMapper.ToDelegateInfo(data), xsltFilePath),
          InfoType.Namespace => null,
          _ => throw new ArgumentOutOfRangeException()
        }
        : throw new XmlException($"unable to parse {nameof(DataInfo)} type: {dataType}");
    }
  }
}
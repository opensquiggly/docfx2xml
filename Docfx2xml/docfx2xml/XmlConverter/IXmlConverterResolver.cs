namespace Docfx2xml.XmlConverter
{
  public interface IXmlConverterResolver
  {
    IXmlConverter Resolve(XmlConverterType type);
  }
}
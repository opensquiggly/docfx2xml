using System;
using Microsoft.Extensions.DependencyInjection;

namespace Docfx2xml.XmlConverter.Implements
{
  public class XmlConverterResolver : IXmlConverterResolver
  {
    private readonly IServiceProvider _serviceProvider;
    
    public XmlConverterResolver(IServiceProvider serviceProvider)
    {
      _serviceProvider = serviceProvider;
    }
    
    public IXmlConverter Resolve(XmlConverterType type) =>
      type switch
      {
        XmlConverterType.Default => _serviceProvider.GetService<DefaultXmlConverter>(),
        XmlConverterType.Custom => _serviceProvider.GetService<CustomXmlConverter>(),
        XmlConverterType.CustomIgnoreNamespaces => _serviceProvider.GetService<CustomIgnoreNamespaceConverter>(),
        _ => _serviceProvider.GetService<DefaultXmlConverter>()
      };
  }
}
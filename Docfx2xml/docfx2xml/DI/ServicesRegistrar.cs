using Docfx2xml.Configuration;
using Docfx2xml.Configuration.Implements;
using Docfx2xml.Converter;
using Docfx2xml.Logger;
using Docfx2xml.XmlConverter;
using Microsoft.Extensions.DependencyInjection;

namespace Docfx2xml.DI
{
  public static class ServicesResolver
  {
    public static ServiceProvider RegisterAppServices(this ServiceCollection serviceCollection)
    {
      serviceCollection.AddSingleton<ILogger, ConsoleLogger>();
      serviceCollection.AddSingleton<IXmlConverter, DefaultXmlConverter>();
      serviceCollection.AddSingleton<IDataLoader, LocalFilesDataLoader>();
      serviceCollection.AddSingleton<IConfigDataProviderFactory, ConfigDataProviderFactory>();
      serviceCollection.AddSingleton<IDataConverter, LocalFilesDataConverter>();

      return serviceCollection.BuildServiceProvider();
    }
  }
}

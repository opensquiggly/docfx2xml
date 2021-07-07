using Docfx2xml.CmdLine;

namespace Docfx2xml.Configuration
{
  public interface IConfigDataProviderFactory
  {
    IConfigDataProvider GetDataProvider(ICmdVerb cmdVerb);
  }
}
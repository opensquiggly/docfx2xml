using System.Threading.Tasks;
using Docfx2xml.Configuration;

namespace Docfx2xml.Converter
{
  public interface IDataConverter
  {
    public void Convert(ConvertConfiguration config);

    public Task ConvertAsync(ConvertConfiguration config);
  }
}

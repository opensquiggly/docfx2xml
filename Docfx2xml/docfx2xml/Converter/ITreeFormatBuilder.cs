using System.Collections.Generic;
using Docfx2xml.Configuration;

namespace Docfx2xml.Converter
{
  public interface ITreeFormatBuilder
  {
    public void BuildTree(IEnumerable<string> fileNames, ConvertConfiguration config);
  }
}
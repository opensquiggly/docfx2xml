using CommandLine;
using Docfx2xml.Configuration;

namespace Docfx2xml.CmdLine
{
  [Verb("run_x", HelpText = "Run convert docfx yaml to xml, using xml config file(ConvertConfig.xml)")]
  public class CmdVerbRunXml : ICmdVerb
  {
    [Option('f', "file", Default = ConfigConstants.XmlConfigFileName, Required = false, HelpText = "Config xml file name")]
    public string FileName { get; set; }
  }
}
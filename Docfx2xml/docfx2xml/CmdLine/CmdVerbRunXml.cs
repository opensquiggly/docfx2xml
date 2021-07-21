using CommandLine;

namespace Docfx2xml.CmdLine
{
  [Verb("run_x", true, HelpText = "Run convert docfx yaml to xml, using xml config file(ConvertConfig.xml)")]
  public class CmdVerbRunXml : ICmdVerb
  {
    [Option('f', "file", Default = "ConvertConfig.xml", Required = false, HelpText = "Config xml file name")]
    public string FileName { get; set; }
  }
}
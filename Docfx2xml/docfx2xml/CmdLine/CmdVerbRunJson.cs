using CommandLine;
using Docfx2xml.Configuration;

namespace Docfx2xml.CmdLine
{
  [Verb("run_j", HelpText = "Run convert docfx yaml to xml, using json config file(convertConfig.json)")]
  public class CmdVerbRunJson : ICmdVerb
  {
    [Option('f', "file", Default = ConfigConstants.JsonConfigFileName, Required = false, HelpText = "Config json file name")]
    public string FileName { get; set; }
  }
}
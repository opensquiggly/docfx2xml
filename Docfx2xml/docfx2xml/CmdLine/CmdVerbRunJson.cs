using CommandLine;

namespace Docfx2xml.CmdLine
{
  [Verb("run_j", true, HelpText = "Run convert docfx yaml to xml, using json config file(convertConfig.json)")]
  public class CmdVerbRunJson : ICmdVerb
  {
    [Option('f', "file", Default = "convertConfig.json", Required = false, HelpText = "Config json file name")]
    public string FileName { get; set; }
  }
}
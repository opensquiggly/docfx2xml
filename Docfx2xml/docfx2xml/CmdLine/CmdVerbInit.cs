using CommandLine;
using Docfx2xml.Configuration;

namespace Docfx2xml.CmdLine
{
  [Verb("init", true, HelpText = "initialize new convertConfig.json file if not exist")]
  public class CmdVerbInit : ICmdVerb
  {
    [Option('f', "file", Default = ConfigConstants.JsonConfigFileName, Required = false, HelpText = "Config json file name")]
    public string FileName { get; set; }
  }
}
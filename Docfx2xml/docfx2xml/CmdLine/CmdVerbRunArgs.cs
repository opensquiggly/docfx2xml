using CommandLine;

namespace Docfx2xml.CmdLine
{
  [Verb("run_a", HelpText = "Run convert docfx yaml to xml, using cmd args as config values")]
  public class CmdVerbRunArgs : ICmdVerb
  {
    [Option('y', "yml", Required = true, HelpText = "Path to folder with docfx .yml files")]
    public string YamlFolderPath { get; set; }
    
    [Option('x', "xml", Required = false, Default = "xml_out", HelpText = "Path to result folder for xml files(created automatically if not exist)")]
    public string XmlFolderPath { get; set; }
    
    [Option('s', "xsl", Required = false, HelpText = "Path to xslt file using for transform default xml in OpenSquiggly")]
    public string XsltFilePath { get; set; }
    
    [Option('n', "namespace", Required = false, Default = false, HelpText = "Split xml files in inner folders by namespace")]
    public bool SaveToNamespaceFolders { get; set; }
    
  }
}
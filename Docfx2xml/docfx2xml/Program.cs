using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;
using Docfx2xml.CmdLine;
using Docfx2xml.Configuration;
using Docfx2xml.Converter;
using Docfx2xml.DI;
using Docfx2xml.Exceptions;
using Docfx2xml.Logger;
using Microsoft.Extensions.DependencyInjection;

namespace Docfx2xml
{
  class Program
  {
    static async Task Main(string[] args)
    {
      var serviceProvider = new ServiceCollection().RegisterAppServices();
      var logger = serviceProvider.GetService<ILogger>();
      var verbs = GetVerbs();
      try
      {
        await Parser.Default.ParseArguments(args, verbs)
          .WithNotParsed(errors => PrintHelp())
          .WithParsedAsync(options => RunOptions(options, serviceProvider));
      }
      catch (Exception ex)
      {
        if (ex is FileNotExistException || ex is FileExistException)
        {
          logger.LogInformation(ex.Message);
          PrintHelp(verbs);
        }
        else
        {
          logger.LogError(ex);
        }
      }
    }

    private static async Task RunOptions(object options, ServiceProvider serviceProvider)
    {
      var stopWatch = Stopwatch.StartNew();

      var logger = serviceProvider.GetService<ILogger>();
      var cmdVerb = options as ICmdVerb;
      var configDataProviderFactory = serviceProvider.GetService<IConfigDataProviderFactory>();
      var configDataProvider = configDataProviderFactory.GetDataProvider(cmdVerb);
      var dataConverter = serviceProvider.GetService<IDataConverter>();
      var config = await configDataProvider.GetConfigurationAsync();
      if (config != null)
      {
        await dataConverter.ConvertAsync(config);
        stopWatch.Stop();
        logger.LogInformation($"Spend time: {stopWatch.ElapsedMilliseconds} ms");
      }
      else
      {
        PrintHelp();
      }
      stopWatch.Reset();
    }

    private static Type[] GetVerbs()
    {
      return new[] {typeof(CmdVerbInit), typeof(CmdVerbRunJson), typeof(CmdVerbRunXml), typeof(CmdVerbRunArgs)};
    }

    private static void PrintHelp(Type[] verbs)
    {
      Console.WriteLine("HELP:" + new HelpText().AddVerbs(verbs));
    }

    private static void PrintHelp()
    {
      var verbs = GetVerbs();
      Console.WriteLine("HELP:" + new HelpText().AddVerbs(verbs));
    }
  }
}

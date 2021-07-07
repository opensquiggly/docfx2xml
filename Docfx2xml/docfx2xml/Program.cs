using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using CommandLine;
using Docfx2xml.CmdLine;
using Docfx2xml.Configuration;
using Docfx2xml.Converter;
using Docfx2xml.DI;
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
      try
      {
        var types = new[] {typeof(CmdVerbRunJson), typeof(CmdVerbRunArgs)};
        
        var parser = BuildParser();
        await parser.ParseArguments(args, types)
          .WithNotParsed(errors => HandleParseError(errors, logger))
            .WithParsedAsync(options => RunOptions(options, serviceProvider));
      }
      catch (Exception ex)
      {
        logger.LogError(ex);
      }
    }

    private static async Task RunOptions(object options, ServiceProvider serviceProvider)
    {
      var stopWatch = Stopwatch.StartNew();

      var cmdVerb = options as ICmdVerb;
      var configDataProviderFactory = serviceProvider.GetService<IConfigDataProviderFactory>();
      var configDataProvider = configDataProviderFactory.GetDataProvider(cmdVerb);
      var dataConverter = serviceProvider.GetService<IDataConverter>();
      var config = await configDataProvider.GetConfigurationAsync();
      await dataConverter.ConvertAsync(config);
      
      stopWatch.Stop();
      var logger = serviceProvider.GetService<ILogger>();
      logger.LogInformation($"Spend time: {stopWatch.ElapsedMilliseconds} ms");
    }

    static Parser BuildParser()
    {
      //return new Parser(options => options.AutoHelp = true);
      return Parser.Default;
    }

    static void HandleParseError(IEnumerable<Error> errors, ILogger logger)
    {
      logger.LogInformation(" use --help");
      // foreach (var error in errors)
      // {
      //   logger.LogError($"Error parse args: {error.Tag.ToString()}");
      // }
    }
  }
}

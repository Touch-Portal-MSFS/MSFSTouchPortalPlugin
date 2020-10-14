﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MSFSTouchPortalPlugin_Generator.Configuration;
using MSFSTouchPortalPlugin_Generator.Interfaces;
using System.Threading.Tasks;

namespace MSFSTouchPortalPlugin_Generator {
  static class Program {
    static async Task Main(string[] args) {
      var logFactory = new LoggerFactory();

      await Host.CreateDefaultBuilder(args).ConfigureServices((context, services) => {
        services
        .AddLogging()
        .Configure<GeneratorOptions>((opt) => {
          opt.PluginName = "MSFSTouchPortalPlugin";
          opt.TargetPath = "..\\..\\..\\..\\";

          if (args.Length >= 1) {
            opt.TargetPath = args[0];
          }
        })
        .AddHostedService<RunService>()
        .AddSingleton<IGenerateDoc, GenerateDoc>()
        .AddSingleton<IGenerateEntry, GenerateEntry>();
      }).RunConsoleAsync();
    }
  }
}

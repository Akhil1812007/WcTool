using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using wc_tool.Sources;
using WcTool.Interfaces;
using WcTool.Sources;

namespace WcTool.Application
{
    public class CliApp
    {
        private readonly ILogger<CliApp> _logger;
        private readonly ILogger<FileTextSource> _fileLogger;
        private readonly ILogger<ConsoleTextSource> _consoleLogger;
        private readonly IWcProcessor _processor;

        public CliApp(
            ILogger<CliApp> logger,
            ILogger<FileTextSource> fileLogger,
            ILogger<ConsoleTextSource> consoleLogger,
            IWcProcessor processor)
        {
            _logger = logger;
            _fileLogger = fileLogger;
            _consoleLogger = consoleLogger;
            _processor = processor;
        }

        public async Task RunAsync(string[] args)
        {
            try
            {
                _logger.LogInformation("Application started...");

                ITextSource textSource;

                if (args.Length > 0 && !string.IsNullOrWhiteSpace(args[0]))
                {
                    string filePath = args[0];
                    textSource = new FileTextSource(filePath, _fileLogger);
                }
                else
                {
                    textSource = new ConsoleTextSource(_consoleLogger);
                }

                string content = textSource.ReadText();
                var result = _processor.Process(content);

                Console.WriteLine($"Lines: {result.LineCount}");
                Console.WriteLine($"Words: {result.WordCount}");
                Console.WriteLine($"Characters: {result.CharacterCount}");

                _logger.LogInformation("Application completed successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred.");
                Console.WriteLine($"Error: {ex.Message}");
            }

            await Task.CompletedTask;
        }
    }
}

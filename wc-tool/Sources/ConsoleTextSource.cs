using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcTool.Interfaces;

namespace wc_tool.Sources
{
    public  class ConsoleTextSource : ITextSource
    {
        private readonly ILogger<ConsoleTextSource> _logger;

        public ConsoleTextSource(ILogger<ConsoleTextSource> logger)
        {
            _logger = logger;
        }

        public string ReadText()
        {
            _logger.LogInformation("Reading input from Console...");
            Console.WriteLine("Please enter your text input (press Ctrl+Z + Enter to finish):");

            string input = "";
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                input += line + Environment.NewLine;
            }

            return input;
        }
        
    }
}

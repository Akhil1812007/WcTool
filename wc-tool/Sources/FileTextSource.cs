using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcTool.Interfaces;
using System.IO;
using WcTool.Exceptions;
using Microsoft.Extensions.Logging;

namespace WcTool.Sources
{
   
    /// <summary>
    /// Reading input from File format source
    /// </summary>
    public class FileTextSource : ITextSource
    {
        private readonly string _filePath;
        private readonly ILogger<FileTextSource> _logger;
        /// <summary>
        /// Setting the contructor
        /// </summary>
        /// <param name="filePath"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public FileTextSource(string filePath,ILogger<FileTextSource> logger) {
            if(string.IsNullOrWhiteSpace(filePath)) 
                throw new ArgumentNullException(nameof(filePath)); 
            _filePath = filePath;
            _logger = logger;
        }
        /// <summary>
        /// Read the file
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="IOException"></exception>
        public string ReadText()
        {
            try
            {
                _logger.LogTrace("Start reading the file content");
                return File.ReadAllText(_filePath);
            }
            catch(FileNotFoundException ex)
            {
                _logger.LogError("FileNotFoundException");
                throw new TextSourceException($"File not found :{_filePath}",ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogError("UnauthorizedAccessException");
                throw new TextSourceException($"File not accessible :{_filePath}", ex);
            }
            catch (IOException ex)
            {
                _logger.LogError("IOException");
                throw new TextSourceException($"Error reading file :{_filePath}", ex);
            }


        }
    }
}

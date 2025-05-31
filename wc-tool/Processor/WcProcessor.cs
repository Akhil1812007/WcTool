using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcTool.Interfaces;

namespace wc_tool.Processor
{
    /// <summary>
    /// 
    /// </summary>
    public class WcProcessor : IWcProcessor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public (int LineCount, int WordCount, int CharacterCount) Process(string content)
        {
            int characterCount=content.Length;
            int lineCount = content.Split('\n',StringSplitOptions.None).Length;
            char[] wordSeparator = new char[] { ' ', '\t', '\r', '\n' };
            int wordCount=content.Split(wordSeparator, StringSplitOptions.RemoveEmptyEntries).Length;
            return (lineCount, wordCount, characterCount);
        }
    }
}

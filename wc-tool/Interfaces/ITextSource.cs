using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcTool.Interfaces
{
    /// <summary>
    /// Abstraction to provide text input from various source
    /// </summary>
    public  interface ITextSource
    {
        /// <summary>
        /// Reads the full text content from the source
        /// </summary>
        /// <returns>
        /// The entire text is return as String
        /// </returns>
        string ReadText();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcTool.Exceptions
{
    public  class TextSourceException :Exception
    {
        public TextSourceException() { }

        public TextSourceException(string message) : base(message) { }

        public TextSourceException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}

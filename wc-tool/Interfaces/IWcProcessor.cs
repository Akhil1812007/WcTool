using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcTool.Interfaces
{
    public interface IWcProcessor
    {
        (int LineCount,int WordCount,int CharacterCount) Process(string content);

    }
}

using DomainModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLogic.Dictionaries
{
    public class SnippetDictionary
    {
        readonly Dictionary<SnippetAction, string> snippets = new Dictionary<SnippetAction, string>()
        {
            {SnippetAction.MyProperty, "$MyProperty$" },
            {SnippetAction.End, "$end$" }
        };
    }
}

using DomainModel.Enums;

namespace DomainLogic.Dictionaries
{
    public class SnippetDictionary
    {
        public readonly Dictionary<SnippetAction, string> snippets = new Dictionary<SnippetAction, string>()
        {
            /*  example TODO CHECK LOGIC
             *  <Literal>
                <ID>href</ID>
                <ToolTip>href</ToolTip>
                <Default>#</Default>
              </Literal>
            <![CDATA[<a href="$href$">$selected$</a>$end$]]>
            */
            {SnippetAction.MyProperty, "$MyProperty$" },
            {SnippetAction.Selected, "$selected$"},
            {SnippetAction.End, "$end$" },
            {SnippetAction.Shortcut, "$shortcut$" },
        };
    }
}

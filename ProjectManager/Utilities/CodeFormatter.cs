using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System.Windows.Documents;
using Microsoft.CodeAnalysis.Text;
using Microsoft.CodeAnalysis.Formatting;
using System.Text.RegularExpressions;
using System.Windows.Media;
using chkam05.Tools.ControlsEx;
using System.Windows;
using System.Linq;
using System.Text;
using System.Collections;

namespace ProjectManager.Utilities
{
    public static class CodeFormatter
    {

        //  METHODS

        #region CSharp

        //  --------------------------------------------------------------------------------
        /// <summary> Load and format CSharp code into RichTextBox. </summary>
        /// <param name="code"> CSharp code. </param>
        /// <param name="richTextBox"> RichTextBox. </param>
        /// <param name="syntaxFormat"> Use syntax formatter. </param>
        public static void LoadCSharpCode(string code, RichTextBoxEx richTextBox, bool syntaxFormat = false)
        {
            string preformattedCode = ReplaceTabsWithSpaces(code);
            TextRange textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);

            textRange.Text = syntaxFormat ? FormatCSharpCode(preformattedCode) : preformattedCode;

            foreach (Paragraph paragraph in richTextBox.Document.Blocks)
            {
                paragraph.Foreground = Brushes.Black;
                paragraph.FontSize = 14d;
                paragraph.FontFamily = new FontFamily("Consolas");
                paragraph.Margin = new Thickness(0);
                paragraph.Padding = new Thickness(0);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Format CSharp code. </summary>
        /// <param name="code"> CSharp code. </param>
        /// <returns> Formatted CSharp code. </returns>
        private static string FormatCSharpCode(string code)
        {
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);
            CompilationUnitSyntax root = syntaxTree.GetCompilationUnitRoot();

            Document document = new AdhocWorkspace()
                .AddProject("MyProject", "C#")
                .AddDocument("MyFile.cs", root.NormalizeWhitespace().ToFullString());

            SourceText sourceText = document.GetTextAsync().Result;
            
            return Formatter.Format(root, new AdhocWorkspace()).ToString();
        }

        #endregion CSharp

        #region UTILITIES

        //  --------------------------------------------------------------------------------
        /// <summary> Replace tabs to spaces. </summary>
        /// <param name="text"> Text. </param>
        /// <param name="spaces"> Spaces count instead of tab. </param>
        /// <returns> Text without tabs. </returns>
        public static string ReplaceTabsWithSpaces(string text, int spaces = 4)
        {
            string strSpaces = string.Empty;

            for (int s = 0; s < spaces; s++)
                strSpaces += " ";

            return text.Replace("\t", strSpaces);
        }

        #endregion UTILITIES

    }
}

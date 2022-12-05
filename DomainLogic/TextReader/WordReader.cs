using DomainModel.Enums;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Text;
using System.Text.RegularExpressions;

namespace DomainLogic.TextReader
{
    /// <summary>
    /// Get the most repetead words from files/websites etc. Make maximum learning using the Pareto style. 
    /// </summary>
    public class WordReader
    {
        private readonly Dictionary<string, int> _mostRepeatedWord = new Dictionary<string, int>();
        private readonly Regex _wordSplitterRegex = new Regex(@"\b[\s,\.-:;]*", RegexOptions.Compiled);
        private readonly Regex _getTextFromWebisteRegex = new Regex(@"(?<=\>)[A-z\s\w]*(?=\<)?", RegexOptions.Compiled);

        private void ReadWordsFromWebsite(string url)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var text = response.Content.ReadAsStringAsync().Result;
                    AnalyzeText(text, SourceOptionWords.Website);
                }
            }
        }

        public void ReadWord(List<string> sources)
        {
            foreach (var source in sources)
            {
                if (Uri.IsWellFormedUriString(source, UriKind.Absolute))
                    ReadWordsFromWebsite(source);
                else
                    ReadWordsFromFiles(source);
            }
        }

        private void ReadWordsFromFiles(string path)
        {
            StringBuilder text = new StringBuilder();

            if (File.Exists(path))
            {
                PdfReader pdfReader = new PdfReader(path);

                for (int page = 1; page <= pdfReader.NumberOfPages; page++)
                {
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                    string currentText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);

                    currentText = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));
                    text.Append(currentText);
                }
                pdfReader.Close();
            }

            AnalyzeText(text.ToString(), SourceOptionWords.pdf);
        }

        //That method should be tested. Here is manys examples from webstites etc. For now reader for files is not implement
        public void AnalyzeText(string text, SourceOptionWords sourceOption)
        {
            switch (sourceOption)
            {
                case SourceOptionWords.Website:
                    var matchedTexts = _getTextFromWebisteRegex.Matches(text);
                    AnalyzeMatchedText(matchedTexts);
                    break;
                case SourceOptionWords.XML:
                    break;
                case SourceOptionWords.JSON:
                    break;
                case SourceOptionWords.Word:
                    break;
                case SourceOptionWords.txt:
                    break;
                case SourceOptionWords.pdf:
                    CountWords(text);
                    break;
                case SourceOptionWords.ProgrammingExtension:
                    break;
                default:
                    break;
            }
        }

        private void AnalyzeMatchedText(MatchCollection matchedTexts)
        {
            foreach (var matchetText in matchedTexts.Where(x => !string.IsNullOrEmpty(x.Value)))
            {
                CountWords(matchetText.Value);
            }
        }

        public void CountWords(string text)
        {
            var words = _wordSplitterRegex.Split(text).Where(x => !string.IsNullOrEmpty(x) || !string.IsNullOrWhiteSpace(x));
            foreach (var word in words)
            {
                var clearedWord = WordRules(word);
                if (_mostRepeatedWord.ContainsKey(clearedWord))
                    _mostRepeatedWord[clearedWord]++;
                else
                    _mostRepeatedWord[clearedWord] = 1;
            }
        }

        //Place more rule here later
        private string WordRules(string word)
        {
            return word.Trim();
        }

        public Dictionary<string, int> getMostRepeatedWords => _mostRepeatedWord;
    }
}

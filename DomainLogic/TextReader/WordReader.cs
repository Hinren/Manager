using DomainModel.Enums;
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
            //word, text will be the easiet 
            //xml, json 
            //Make read pdf or diffrent file extension
            //read also file extension .cs. Find all summaries inside code and we know the names method should be seperated to words also (Classes too)
            //that logic allow to maxime using PARETO style during learning langs we want. 

            throw new NotImplementedException();
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
                var words = _wordSplitterRegex.Split(matchetText.Value).Where(x => !string.IsNullOrEmpty(x) || !string.IsNullOrWhiteSpace(x));
                foreach (var word in words)
                {
                    var clearedWord = WordRules(word);
                    if (_mostRepeatedWord.ContainsKey(clearedWord))
                        _mostRepeatedWord[clearedWord]++;
                    else
                        _mostRepeatedWord[clearedWord] = 1;
                }
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

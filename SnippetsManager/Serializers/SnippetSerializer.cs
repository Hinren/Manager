using SnippetsManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SnippetsManager.Serializers
{
    public class SnippetSerializer
    {

        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> SnippetSerializer class constructor. </summary>
        public SnippetSerializer()
        {
            //
        }

        #endregion CLASS METHODS

        #region SERIALIZATION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Deserialize snippet from file. </summary>
        /// <param name="snippetFilePath"> Snippet file path. </param>
        public SnippetItem DeserializeFromFile(string snippetFilePath, out string errorMessage)
        {
            errorMessage = string.Empty;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(SnippetItem));
                string snippetContent = File.ReadAllText(snippetFilePath);

                object result = null;

                using (TextReader reader = new StringReader(snippetContent))
                {
                    result = serializer.Deserialize(reader);
                }

                if (result != null)
                {
                    SnippetItem item = (SnippetItem)result;
                    item.FilePath = snippetFilePath;
                    return item;
                }
            }
            catch (Exception exc)
            {
                errorMessage = exc.Message;
            }

            return null;
        }

        #endregion SERIALIZATION METHODS

    }
}

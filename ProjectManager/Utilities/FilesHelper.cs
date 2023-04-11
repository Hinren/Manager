using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Utilities
{
    public static class FilesHelper
    {

        //  METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Create file. </summary>
        /// <param name="filePath"> File path. </param>
        /// <param name="defaultContent"> Default file content. </param>
        /// <returns> True - file created; False - otherwise. </returns>
        public static bool CreateFile(string filePath, string defaultContent = "")
        {
            if (File.Exists(filePath))
                return true;

            string directoryPath = Path.GetDirectoryName(filePath);

            try
            {
                Directory.CreateDirectory(directoryPath);
                File.WriteAllText(filePath, defaultContent);
            }
            catch
            {
                return false;
            }

            return true;
        }

    }
}

using Newtonsoft.Json;
using ProjectManager.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Data
{
    public class DatabaseConfig
    {

        //  VARIABLES

        public string DatabaseProfilesFilePath { get; set; }


        //  GETTERS & SETTERS

        [JsonIgnore]
        public string DefaultDatabaseProfilesFilePath
        {
            get
            {
                string filePath = Path.Combine(ApplicationHelper.GetApplicationPath(), "db.json");

                if (!File.Exists(filePath))
                    File.WriteAllText(filePath, "[]");

                return filePath;
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> DatabaseConfig class constructor. </summary>
        /// <param name="databaseProfilesFilePath"> Database profiles file path. </param>
        [JsonConstructor]
        public DatabaseConfig(string databaseProfilesFilePath = null)
        {
            DatabaseProfilesFilePath = ValidateDatabaseProfilesFilePath(databaseProfilesFilePath)
                ? databaseProfilesFilePath
                : DefaultDatabaseProfilesFilePath;
        }

        #endregion CLASS METHODS

        #region VALIDATION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Check if database profiles file path is valid. </summary>
        /// <param name="filePath"> Database profiles file path. </param>
        /// <returns> True - file is valid; False - otherwise. </returns>
        private bool ValidateDatabaseProfilesFilePath(string filePath)
        {
            return !string.IsNullOrEmpty(filePath) && File.Exists(filePath);
        }

        #endregion VALIDATION METHODS

    }
}

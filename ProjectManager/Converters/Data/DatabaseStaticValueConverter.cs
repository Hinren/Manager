using ProjectManager.Data.Configuration.Static;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ProjectManager.Converters.Data
{
    public class DatabaseCharacterSetValueConverter : EnumValueConverter<DatabaseCharacterSet>
    {

        //  CONST

        private static readonly Dictionary<DatabaseCharacterSet, string> _valuesDict = new Dictionary<DatabaseCharacterSet, string>()
        {
            { DatabaseCharacterSet.DEFAULT, "Default" },
            { DatabaseCharacterSet.UTF_8, "utf8" },
            { DatabaseCharacterSet.UTF_16, "utf-16" },
            { DatabaseCharacterSet.ISO_8859_1, "iso-8859-1" },
            { DatabaseCharacterSet.WINDOWS_1251, "windows-1252" },
            { DatabaseCharacterSet.ASCII, "ascii" },
            { DatabaseCharacterSet.UNICODE, "unicode" },
        };


        //  VALUES

        public override DatabaseCharacterSet DefaultKey => DatabaseCharacterSet.DEFAULT;
        public override string DefaultValue => "Default";

        public override Dictionary<DatabaseCharacterSet, string> ValuesDict
        {
            get => _valuesDict;
        }

    }

    public class DatabaseProviderValueConverter : EnumValueConverter<DatabaseProvider>
    {

        //  CONST

        private static readonly Dictionary<DatabaseProvider, string> _valuesDict = new Dictionary<DatabaseProvider, string>()
        {
            { DatabaseProvider.DEFAULT, "Default" },
            { DatabaseProvider.MICROSOFT_ACE_OLEDB_12_0, "Microsoft.ACE.OLEDB.12.0" },
            { DatabaseProvider.MICROSOFT_JET_OLEDB_4_0, "Microsoft.Jet.OLEDB.4.0" },
            { DatabaseProvider.SQL_CLIENT, "System.Data.SqlClient" },
            { DatabaseProvider.OLE_DB, "System.Data.OleDb" }
        };


        //  VALUES

        public override DatabaseProvider DefaultKey => DatabaseProvider.DEFAULT;
        public override string DefaultValue => "Default";

        public override Dictionary<DatabaseProvider, string> ValuesDict
        {
            get => _valuesDict;
        }

    }

    public class DatabaseSSLModeValueConverter : EnumValueConverter<DatabaseSSLMode>
    {

        //  CONST

        private static readonly Dictionary<DatabaseSSLMode, string> _valuesDict = new Dictionary<DatabaseSSLMode, string>()
        {
            { DatabaseSSLMode.DEFAULT, "Default" },
            { DatabaseSSLMode.NONE, "None" },
            { DatabaseSSLMode.REQUIRED, "Required" },
            { DatabaseSSLMode.PREFFERED, "Preferred" },
            { DatabaseSSLMode.SSL_MODE, "SslMode" }
        };


        //  VALUES

        public override DatabaseSSLMode DefaultKey => DatabaseSSLMode.DEFAULT;
        public override string DefaultValue => "Default";

        public override Dictionary<DatabaseSSLMode, string> ValuesDict
        {
            get => _valuesDict;
        }

    }

    public class DatabaseServerCertificateValidationModeValueConverter : EnumValueConverter<DatabaseServerCertificateValidationMode>
    {

        //  CONST

        private static readonly Dictionary<DatabaseServerCertificateValidationMode, string> _valuesDict = new Dictionary<DatabaseServerCertificateValidationMode, string>()
        {
            { DatabaseServerCertificateValidationMode.DEFAULT, "Default" },
            { DatabaseServerCertificateValidationMode.NONE, "None" },
            { DatabaseServerCertificateValidationMode.FULL, "Full" },
            { DatabaseServerCertificateValidationMode.VERIFY_CA, "VerifyCA" },
            { DatabaseServerCertificateValidationMode.VERIFY_FULL, "VerifyFull" },
            { DatabaseServerCertificateValidationMode.VERIFY_HOST_NAME, "VerifyHostName" }
        };


        //  VALUES

        public override DatabaseServerCertificateValidationMode DefaultKey => DatabaseServerCertificateValidationMode.DEFAULT;
        public override string DefaultValue => "Default";

        public override Dictionary<DatabaseServerCertificateValidationMode, string> ValuesDict
        {
            get => _valuesDict;
        }

    }

}

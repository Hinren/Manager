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
    public class DatabaseStaticValueConverter<T> : IValueConverter
    {

        //  VALUES

        public virtual T DefaultKey { get => default(T); }
        public virtual string DefaultValue { get => string.Empty; }
        public virtual Dictionary<T, string> ValuesDict { get => null; }


        //  METHODS

        //  --------------------------------------------------------------------------------
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var enumValue = (T)value;
            return (ValuesDict?.TryGetValue(enumValue, out string name) ?? false) ? name : DefaultValue;
        }

        //  --------------------------------------------------------------------------------
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stringValue = (string)value;
            return (ValuesDict?.ContainsValue(stringValue) ?? false)
                ? ValuesDict.FirstOrDefault(x => x.Value == stringValue).Key
                : default(T);
        }

    }

    public class DatabaseCharacterSetValueConverter : DatabaseStaticValueConverter<DatabaseCharacterSet>
    {

        //  CONST

        private static readonly Dictionary<DatabaseCharacterSet, string> _valuesDict = new Dictionary<DatabaseCharacterSet, string>()
        {
            { DatabaseCharacterSet.UTF_8, "utf8" },
            { DatabaseCharacterSet.UTF_16, "utf-16" },
            { DatabaseCharacterSet.ISO_8859_1, "iso-8859-1" },
            { DatabaseCharacterSet.WINDOWS_1251, "windows-1252" },
            { DatabaseCharacterSet.ASCII, "ascii" },
            { DatabaseCharacterSet.UNICODE, "unicode" },
        };


        //  VALUES

        public override DatabaseCharacterSet DefaultKey => DatabaseCharacterSet.UTF_8;
        public override string DefaultValue => "utf8";

        public override Dictionary<DatabaseCharacterSet, string> ValuesDict
        {
            get => _valuesDict;
        }

    }

    public class DatabaseProviderValueConverter : DatabaseStaticValueConverter<DatabaseProvider>
    {

        //  CONST

        private static readonly Dictionary<DatabaseProvider, string> _valuesDict = new Dictionary<DatabaseProvider, string>()
        {
            { DatabaseProvider.MICROSOFT_ACE_OLEDB_12_0, "Microsoft.ACE.OLEDB.12.0" },
            { DatabaseProvider.MICROSOFT_JET_OLEDB_4_0, "Microsoft.Jet.OLEDB.4.0" },
            { DatabaseProvider.SQL_CLIENT, "System.Data.SqlClient" },
            { DatabaseProvider.OLE_DB, "System.Data.OleDb" }
        };


        //  VALUES

        public override DatabaseProvider DefaultKey => DatabaseProvider.SQL_CLIENT;
        public override string DefaultValue => "System.Data.SqlClient";

        public override Dictionary<DatabaseProvider, string> ValuesDict
        {
            get => _valuesDict;
        }

    }

    public class DatabaseSSLModeValueConverter : DatabaseStaticValueConverter<DatabaseSSLMode>
    {

        //  CONST

        private static readonly Dictionary<DatabaseSSLMode, string> _valuesDict = new Dictionary<DatabaseSSLMode, string>()
        {
            { DatabaseSSLMode.NONE, "None" },
            { DatabaseSSLMode.REQUIRED, "Required" },
            { DatabaseSSLMode.PREFFERED, "Preferred" },
            { DatabaseSSLMode.SSL_MODE, "SslMode" }
        };


        //  VALUES

        public override DatabaseSSLMode DefaultKey => DatabaseSSLMode.NONE;
        public override string DefaultValue => "None";

        public override Dictionary<DatabaseSSLMode, string> ValuesDict
        {
            get => _valuesDict;
        }

    }

    public class DatabaseServerCertificateValidationModeValueConverter : DatabaseStaticValueConverter<DatabaseServerCertificateValidationMode>
    {

        //  CONST

        private static readonly Dictionary<DatabaseServerCertificateValidationMode, string> _valuesDict = new Dictionary<DatabaseServerCertificateValidationMode, string>()
        {
            { DatabaseServerCertificateValidationMode.NONE, "None" },
            { DatabaseServerCertificateValidationMode.FULL, "Full" },
            { DatabaseServerCertificateValidationMode.VERIFY_CA, "VerifyCA" },
            { DatabaseServerCertificateValidationMode.VERIFY_FULL, "VerifyFull" },
            { DatabaseServerCertificateValidationMode.VERIFY_HOST_NAME, "VerifyHostName" }
        };


        //  VALUES

        public override DatabaseServerCertificateValidationMode DefaultKey => DatabaseServerCertificateValidationMode.NONE;
        public override string DefaultValue => "None";

        public override Dictionary<DatabaseServerCertificateValidationMode, string> ValuesDict
        {
            get => _valuesDict;
        }

    }

}

using Newtonsoft.Json;
using ProjectManager.Data.Configuration.Static;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Data.Configuration
{
    public class DatabaseProfile : INotifyPropertyChanged
    {

        //  CONST

        public const string DATA_SOURCE_HEADER = "Data Source";
        public const string INITIAL_CATALOG_HEADER = "Initial Catalog";
        public const string USER_ID_HEADER = "User ID";
        public const string PASSWORD_HEADER = "Password";
        public const string CONNECT_TIMEOUT = "Connect Timeout";
        public const string POOLING_HEADER = "Pooling";
        public const string MULTIPLE_ACTIVE_RESULT_SETS_HEADER = "MultipleActiveResultSets";
        public const string ENCRYPT_HEADER = "Encrypt";
        public const string TRUST_SERVER_CERTIFICATE_HEADER = "TrustServerCertificate";
        public const string APPLICATION_NAME_HEADER = "Application Name";
        public const string WORKSTATION_ID_HEADER = "Workstation ID";
        public const string PROVIDER_HEADER = "Provider";
        public const string PORT_HEADER = "Port";
        public const string SLL_MODE_HEADER = "SSL Mode";
        public const string SERVER_CERTIFICATE_VALIDATION_MODE_HEADER = "Server Certificate Validation Mode";
        public const string ALLOW_PUBLIC_KEY_RETRIEVAL_HEADER = "AllowPublicKeyRetrieval";
        public const string CHARACTER_SET_HEADER = "Character Set";


        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private string _id;
        private string _profileName;
        private string _profileDescription;

        private string _dataSource;
        private string _initialCatalog;
        private string _userID;
        private string _password;
        private int _connectTimeout;
        private bool _pooling;
        private bool _multipleActiveResultSets;
        private bool _encrypt;
        private bool _trustServerCertificate;
        private string _applicationName;
        private string _workstationID;
        private DatabaseProvider _provider = DatabaseProvider.SQL_CLIENT;
        private int _port;
        private DatabaseSSLMode _sslMode = DatabaseSSLMode.NONE;
        private DatabaseServerCertificateValidationMode _serverCertificateValidationMode = DatabaseServerCertificateValidationMode.NONE;
        private bool _allowPublicKeyRetrieval;
        private DatabaseCharacterSet _characterSet = DatabaseCharacterSet.UTF_8;


        //  GETTERS & SETTERS

        public string Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string ProfileName
        {
            get => _profileName;
            set
            {
                _profileName = value;
                OnPropertyChanged(nameof(ProfileName));
            }
        }

        public string ProfileDescription
        {
            get => _profileDescription;
            set
            {
                _profileDescription = value;
                OnPropertyChanged(nameof(ProfileDescription));
            }
        }


        /// <summary> Represents a server address. </summary>
        public string DataSource
        {
            get => _dataSource;
            set
            {
                _dataSource = value;
                OnPropertyChanged(nameof(DataSource));
            }
        }

        /// <summary> Represents name of the database. </summary>
        public string InitialCatalog
        {
            get => _initialCatalog;
            set
            {
                _initialCatalog = value;
                OnPropertyChanged(nameof(InitialCatalog));
            }
        }

        /// <summary> Represents user name. </summary>
        public string UserID
        {
            get => _userID;
            set
            {
                _userID = value;
                OnPropertyChanged(nameof(UserID));
            }
        }

        /// <summary> Represents user password. </summary>
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        /// <summary> Represents maximum call waiting time. Default is 30 seconds. </summary>
        public int ConnectTimeout
        {
            get => _connectTimeout;
            set
            {
                _connectTimeout = Math.Max(0, value);
                OnPropertyChanged(nameof(ConnectTimeout));
            }
        }

        /// <summary> Represents connection pooling enabled status. </summary>
        public bool Pooling
        {
            get => _pooling;
            set
            {
                _pooling = value;
                OnPropertyChanged(nameof(Pooling));
            }
        }

        /// <summary> Represents configuration for permit perform multiple active results at the same time. </summary>
        public bool MultipleActiveResultSets
        {
            get => _multipleActiveResultSets;
            set
            {
                _multipleActiveResultSets = value;
                OnPropertyChanged(nameof(MultipleActiveResultSets));
            }
        }

        /// <summary> Represents configuration for enable encryption. </summary>
        public bool Encrypt
        {
            get => _encrypt;
            set
            {
                _encrypt = value;
                OnPropertyChanged(nameof(Encrypt));
            }
        }

        /// <summary> Represents configuration for trusting the server's certificate. </summary>
        public bool TrustServerCertificate
        {
            get => _trustServerCertificate;
            set
            {
                _trustServerCertificate = value;
                OnPropertyChanged(nameof(TrustServerCertificate));
            }
        }

        /// <summary> Represents application name, that will be used for identifying from which application connection is performed. </summary>
        public string ApplicationName
        {
            get => _applicationName;
            set
            {
                _applicationName = value;
                OnPropertyChanged(nameof(ApplicationName));
            }
        }

        /// <summary> Represents workstation name, that will be used for identifying from which workstation connection is performed. </summary>
        public string WorkstationID
        {
            get => _workstationID;
            set
            {
                _workstationID = value;
                OnPropertyChanged(nameof(WorkstationID));
            }
        }

        /// <summary> Represents data provider for Server. </summary>
        public DatabaseProvider Provider
        {
            get => _provider;
            set
            {
                _provider = value;
                OnPropertyChanged(nameof(Provider));
            }
        }

        /// <summary> Represents database port number. </summary>
        public int Port
        {
            get => _port;
            set
            {
                _port = Math.Max(0, Math.Min(65535, value));
                OnPropertyChanged(nameof(Port));
            }
        }

        /// <summary> Represents SSL Mode configuration. </summary>
        public DatabaseSSLMode SSLMode
        {
            get => _sslMode;
            set
            {
                _sslMode = value;
                OnPropertyChanged(nameof(SSLMode));
            }
        }

        /// <summary> Represents Server Certificate Validation Mode. </summary>
        public DatabaseServerCertificateValidationMode ServerCertificateValidationMode
        {
            get => _serverCertificateValidationMode;
            set
            {
                _serverCertificateValidationMode = value;
                OnPropertyChanged(nameof(ServerCertificateValidationMode));
            }
        }

        /// <summary> Represents configuration for retrieving public keys from the server. </summary>
        public bool AllowPublicKeyRetrieval
        {
            get => _allowPublicKeyRetrieval;
            set
            {
                _allowPublicKeyRetrieval = value;
                OnPropertyChanged(nameof(AllowPublicKeyRetrieval));
            }
        }

        /// <summary> Set of characters used to encode data in a database configuration. </summary>
        public DatabaseCharacterSet CharacterSet
        {
            get => _characterSet;
            set
            {
                _characterSet = value;
                OnPropertyChanged(nameof(CharacterSet));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> DatabaseProfile class constructor. </summary>
        /// <param name="id"> Profile guid identifier. </param>
        [JsonConstructor]
        public DatabaseProfile(string id = null)
        {
            Id = !string.IsNullOrWhiteSpace(id) ? id : Guid.NewGuid().ToString().ToLower();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Create database profile from connection string. </summary>
        /// <param name="connectionString"> Connection string. </param>
        /// <returns> Database profile. </returns>
        public DatabaseProfile FromConnectionString(string connectionString)
        {
            return new DatabaseProfile(null);
        }

        #endregion CLASS METHODS

        #region GET METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Returns a String which represents the object instance. </summary>
        /// <returns> String that represents the object instance. </returns>
        public override string ToString()
        {
            return base.ToString();
        }

        #endregion GET METHODS

        #region NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method for invoking PropertyChangedEventHandler external method. </summary>
        /// <param name="propertyName"> Changed property name. </param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion NOTIFY PROPERTIES CHANGED INTERFACE METHODS

    }
}

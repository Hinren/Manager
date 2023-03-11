using chkam05.Tools.ControlsEx;
using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.InternalMessages;
using MaterialDesignThemes.Wpf;
using ProjectManager.Data.Configuration;
using ProjectManager.Data.Configuration.Static;
using ProjectManager.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectManager.InternalMessages
{
    public partial class DatabaseProfileEditorIM : StandardInternalMessageEx
    {

        //  VARIABLES

        private DatabaseProfile _databaseProfile = null;

        private ObservableCollection<DatabaseCharacterSet> _characterSetsCollection;
        private ObservableCollection<DatabaseProvider> _providersCollection;
        private ObservableCollection<DatabaseServerCertificateValidationMode> _serverCertificateValidationModesCollection;
        private ObservableCollection<DatabaseSSLMode> _sslModesCollection;


        //  GETTERS & SETTERS

        public DatabaseProfile DatabaseProfile
        {
            get => _databaseProfile;
            set
            {
                _databaseProfile = value;
                OnPropertyChanged(nameof(DatabaseProfile));
            }
        }

        public ObservableCollection<DatabaseCharacterSet> CharacterSetsCollection
        {
            get => _characterSetsCollection;
            set
            {
                _characterSetsCollection = value;
                _characterSetsCollection.CollectionChanged += (s, e) => { OnPropertyChanged(nameof(CharacterSetsCollection)); };
                OnPropertyChanged(nameof(CharacterSetsCollection));
            }
        }

        public ObservableCollection<DatabaseProvider> ProviderCollection
        {
            get => _providersCollection;
            set
            {
                _providersCollection = value;
                _providersCollection.CollectionChanged += (s, e) => { OnPropertyChanged(nameof(ProviderCollection)); };
                OnPropertyChanged(nameof(ProviderCollection));
            }
        }

        public ObservableCollection<DatabaseServerCertificateValidationMode> ServerCertificateValidationModes
        {
            get => _serverCertificateValidationModesCollection;
            set
            {
                _serverCertificateValidationModesCollection = value;
                _serverCertificateValidationModesCollection.CollectionChanged += (s, e)
                    => { OnPropertyChanged(nameof(ServerCertificateValidationModes)); };
                OnPropertyChanged(nameof(ServerCertificateValidationModes));
            }
        }

        public ObservableCollection<DatabaseSSLMode> SslModes
        {
            get => _sslModesCollection;
            set
            {
                _sslModesCollection = value;
                _sslModesCollection.CollectionChanged += (s, e) => { OnPropertyChanged(nameof(SslModes)); };
                OnPropertyChanged(nameof(SslModes));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> DatabaseProfileEditorIM class constructor. </summary>
        /// <param name="parentContainer"> Parent InternalMessagesEx container. </param>
        /// <param name="databaseProfile"> Database profile. </param>
        public DatabaseProfileEditorIM(InternalMessagesExContainer parentContainer, DatabaseProfile databaseProfile) : base(parentContainer)
        {
            //  Data setup.
            SetupDataCollections();

            bool isNew = databaseProfile == null;

            DatabaseProfile = isNew
                ? new DatabaseProfile() { ProfileName = "New profile" }
                : databaseProfile;

            //  Initialize interface components.
            InitializeComponent();

            //  Interface configuration.
            Buttons = new InternalMessageButtons[]
            {
                InternalMessageButtons.OkButton,
                InternalMessageButtons.CancelButton
            };

            IconKind = isNew ? PackIconKind.DatabaseAdd : PackIconKind.DatabaseEdit;
            Title = $"Database profile editor: \"{databaseProfile.ProfileName}\"";
        }

        #endregion CLASS METHODS

        #region SETUP METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Setup data collections. </summary>
        private void SetupDataCollections()
        {
            CharacterSetsCollection = new ObservableCollection<DatabaseCharacterSet>(
                ObjectHelper.GetEnumValues<DatabaseCharacterSet>());

            ProviderCollection = new ObservableCollection<DatabaseProvider>(
                ObjectHelper.GetEnumValues<DatabaseProvider>());

            ServerCertificateValidationModes = new ObservableCollection<DatabaseServerCertificateValidationMode>(
                ObjectHelper.GetEnumValues<DatabaseServerCertificateValidationMode>());

            SslModes = new ObservableCollection<DatabaseSSLMode>(
                ObjectHelper.GetEnumValues<DatabaseSSLMode>());
        }

        #endregion SETUP METHODS

        #region TEMPLATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> When overridden in a derived class,cis invoked whenever 
        /// application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ButtonEx okButton = GetButtonEx("okButton");
            ButtonEx cancelButton = GetButtonEx("cancelButton");

            if (okButton != null)
                okButton.Content = "Save";

            if (cancelButton != null)
                cancelButton.Content = "Cancel";
        }

        #endregion TEMPLATE METHODS

    }
}

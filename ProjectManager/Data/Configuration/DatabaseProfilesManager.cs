using Newtonsoft.Json;
using ProjectManager.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace ProjectManager.Data.Configuration
{
    public class DatabaseProfilesManager : INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DatabaseProfile> OnEditProfileRequest;


        //  VARIABLES

        private ObservableCollection<DatabaseProfile> _profilesCollection;
        private string _profilesPath;
        private DatabaseProfile _selectedProfile;

        public ICommand EditCommand { get; set; }
        public ICommand RemoveCommand { get; set; }


        //  GETTERS & SETTERS

        public ObservableCollection<DatabaseProfile> ProfilesCollection
        {
            get => _profilesCollection;
            private set
            {
                _profilesCollection = value;
                _profilesCollection.CollectionChanged += (s, e)
                    =>
                { OnPropertyChanged(nameof(ProfilesCollection)); };
                OnPropertyChanged(nameof(ProfilesCollection));
            }
        }

        public string ProfilesPath
        {
            get => _profilesPath;
            private set
            {
                _profilesPath = value;
                OnPropertyChanged(nameof(ProfilesPath));
            }
        }

        public DatabaseProfile SelectedProfile
        {
            get => _selectedProfile;
            set
            {
                _selectedProfile = value;
                OnPropertyChanged(nameof(SelectedProfile));
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> DatabaseProfilesManager class constructor. </summary>
        /// <param name="profilesPath"> Profiles path. </param>
        public DatabaseProfilesManager(string profilesPath)
        {
            if (!IsValidProfilesPath(profilesPath))
                throw new FileNotFoundException($"The database profile file path directory could not be found.");

            ProfilesPath = profilesPath;

            EditCommand = new RelayCommand(OnEditCommandExecute);
            RemoveCommand = new RelayCommand(OnRemoveCommandExecute);

            LoadData();
        }

        #endregion CLASS METHODS

        #region COMMANDS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after pressing Edit database profile button. </summary>
        /// <param name="profile"> Database profile as object. </param>
        private void OnEditCommandExecute(object profile)
        {
            var databaseProfile = profile as DatabaseProfile;

            if (databaseProfile != null)
                OnEditProfileRequest?.Invoke(this, databaseProfile);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after pressing Remove database profile button. </summary>
        /// <param name="profile"> Database profile as object. </param>
        private void OnRemoveCommandExecute(object profile)
        {
            RemoveProfile(profile as DatabaseProfile);
        }

        #endregion COMMANDS METHODS

        #region LOAD & SAVE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Load profiles from file. </summary>
        private void LoadData()
        {
            if (File.Exists(ProfilesPath))
            {
                var rawData = File.ReadAllText(ProfilesPath);
                var profiles = JsonConvert.DeserializeObject<List<DatabaseProfile>>(rawData);

                if (profiles != null && profiles.Any())
                    ProfilesCollection = new ObservableCollection<DatabaseProfile>(profiles);
            }

            if (ProfilesCollection == null)
            {
#if DEBUG
                ProfilesCollection = new ObservableCollection<DatabaseProfile>()
                {
                    new DatabaseProfile() { ProfileName = "Default profile", ProfileDescription = "This is default profile" },
                    new DatabaseProfile() { ProfileName = "Kamil database", ProfileDescription = "Private Kamils database" },
                    new DatabaseProfile() { ProfileName = "Patryks database", ProfileDescription = "Private Patryks database" },
                    new DatabaseProfile() { ProfileName = "Work", ProfileDescription = "Wokr database profile" }
                };
#else
                ProfilesCollection = new ObservableCollection<DatabaseProfile>();
#endif
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Save profiles to file. </summary>
        private void SaveData()
        {
            var rawData = JsonConvert.SerializeObject(ProfilesCollection.ToList());
            File.WriteAllText(ProfilesPath, rawData);
        }

        #endregion LOAD & SAVE METHODS

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

        #region PROFILES MANAGEMENT METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Add new database profile to profiles collection. </summary>
        /// <param name="profile"> Database profile. </param>
        public void AddNewProfile(DatabaseProfile profile)
        {
            if (profile != null)
            {
                DatabaseProfile currentVersion = ProfilesCollection.FirstOrDefault(p => p.Id == profile.Id);

                if (currentVersion == null)
                {
                    ProfilesCollection.Add(profile);
                    SaveData();
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Remove database profile from profiles collection. </summary>
        /// <param name="profile"> Database profile to remove. </param>
        public void RemoveProfile(DatabaseProfile profile)
        {
            if (profile != null && ProfilesCollection.Contains(profile))
            {
                ProfilesCollection.Remove(profile);
                SaveData();
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Update database profile in profiles collection. </summary>
        /// <param name="profile"> Database profile to update. </param>
        public void UpdateProfile(DatabaseProfile profile)
        {
            if (profile != null)
            {
                DatabaseProfile currentVersion = ProfilesCollection.FirstOrDefault(p => p.Id == profile.Id);

                if (currentVersion != null)
                {
                    var currentVersionIndex = ProfilesCollection.IndexOf(currentVersion);
                    ProfilesCollection[currentVersionIndex] = profile;
                }
                else
                {
                    ProfilesCollection.Add(profile);
                }

                SaveData();
            }
        }

        #endregion PROFILES MANAGEMENT METHODS

        #region UTILITY METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Check if path to the file is valid. </summary>
        /// <returns> True - is valid path; False - otherwise. </returns>
        private bool IsValidProfilesPath(string path)
        {
            try
            {
                string directoryName = Path.GetDirectoryName(path);
                return !string.IsNullOrEmpty(directoryName);
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion UTILITY METHODS

    }
}

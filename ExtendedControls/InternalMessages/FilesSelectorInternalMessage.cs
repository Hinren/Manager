using ExtendedControls.Events;
using ExtendedControls.Static;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static ExtendedControls.Events.Delegates;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;
using ExtendedControls.Data;

namespace ExtendedControls.InternalMessages
{
    public class FilesSelectorInternalMessage : BaseInternalMessage<FilesSelectorInternalMessageCloseEventArgs>
    {

        //  CONST

        public static readonly string USER_PROFILE_PATH = Environment.GetEnvironmentVariable("USERPROFILE");
        protected static readonly string[] FORBIDDEN_CHARACTERS = new string[]
        {
            "/", "<", ">", ":", "\"", "|", "?", "*"
        };


        //  DEPENDENCY PROPERTIES

        #region Appearance TextBoxes Colors Properties

        public static readonly DependencyProperty TextBoxBackgroundMouseOverBrushProperty = DependencyProperty.Register(
            nameof(TextBoxBackgroundMouseOverBrush),
            typeof(Brush),
            typeof(FilesSelectorInternalMessage),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_MOUSE_OVER_COLOR)));

        public static readonly DependencyProperty TextBoxBorderMouseOverBrushProperty = DependencyProperty.Register(
            nameof(TextBoxBorderMouseOverBrush),
            typeof(Brush),
            typeof(FilesSelectorInternalMessage),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_MOUSE_OVER_COLOR)));

        public static readonly DependencyProperty TextBoxForegroundMouseOverBrushProperty = DependencyProperty.Register(
            nameof(TextBoxForegroundMouseOverBrush),
            typeof(Brush),
            typeof(FilesSelectorInternalMessage),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_MOUSE_OVER_COLOR)));

        public static readonly DependencyProperty TextBoxBackgroundSelectedBrushProperty = DependencyProperty.Register(
            nameof(TextBoxBackgroundSelectedBrush),
            typeof(Brush),
            typeof(FilesSelectorInternalMessage),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Transparent)));

        public static readonly DependencyProperty TextBoxBorderSelectedBrushProperty = DependencyProperty.Register(
            nameof(TextBoxBorderSelectedBrush),
            typeof(Brush),
            typeof(FilesSelectorInternalMessage),
            new PropertyMetadata(new SolidColorBrush(StaticResources.BACKGROUND_SELECTED_COLOR)));

        public static readonly DependencyProperty TextBoxForegroundSelectedBrushProperty = DependencyProperty.Register(
            nameof(TextBoxForegroundSelectedBrush),
            typeof(Brush),
            typeof(FilesSelectorInternalMessage),
            new PropertyMetadata(new SolidColorBrush(StaticResources.FOREGROUND_COLOR)));

        public static readonly DependencyProperty TextBoxTextSelectedBrushProperty = DependencyProperty.Register(
            nameof(TextBoxTextSelectedBrush),
            typeof(Brush),
            typeof(FilesSelectorInternalMessage),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        #endregion Appearance TextBoxes Colors Properties

        public static readonly DependencyProperty AllowCreateProperty = DependencyProperty.Register(
            nameof(AllowCreate),
            typeof(bool),
            typeof(FilesSelectorInternalMessage),
            new PropertyMetadata(false));

        public static readonly DependencyProperty FilesTypesProperty = DependencyProperty.Register(
            nameof(FilesTypes),
            typeof(ObservableCollection<InternalMessageFileType>),
            typeof(FilesSelectorInternalMessage),
            new PropertyMetadata(new ObservableCollection<InternalMessageFileType>(
                new List<InternalMessageFileType>()
                {
                    InternalMessageFileType.AllFiles()
                }
            )));

        public static readonly DependencyProperty MultipleFilesProperty = DependencyProperty.Register(
            nameof(MultipleFiles),
            typeof(bool),
            typeof(FilesSelectorInternalMessage),
            new PropertyMetadata(false));

        public static readonly DependencyProperty OnlyDirectoriesProperty = DependencyProperty.Register(
            nameof(OnlyDirectories),
            typeof(bool),
            typeof(FilesSelectorInternalMessage),
            new PropertyMetadata(false));

        public static readonly DependencyProperty UseFilesTypesProperty = DependencyProperty.Register(
        nameof(UseFilesTypes),
            typeof(bool),
            typeof(FilesSelectorInternalMessage),
            new PropertyMetadata(true));


        //  VARIABLES

        protected ExtTextBox _addressTextBox = null;
        protected ExtTextBox _filesTextBox = null;
        protected ExtComboBox _filesTypesComboBox = null;

        private string _currentDirectory;
        private InternalMessageFileType _fileType;
        private List<string> _historyForward;
        private string _initialDirectory = USER_PROFILE_PATH;


        //  GETTERS & SETTERS

        #region Appearance TextBoxes Colors

        public Brush TextBoxBackgroundMouseOverBrush
        {
            get => (Brush)GetValue(TextBoxBackgroundMouseOverBrushProperty);
            set
            {
                SetValue(TextBoxBackgroundMouseOverBrushProperty, value);
                OnPropertyChanged(nameof(TextBoxBackgroundMouseOverBrush));
            }
        }

        public Brush TextBoxBorderMouseOverBrush
        {
            get => (Brush)GetValue(TextBoxBorderMouseOverBrushProperty);
            set
            {
                SetValue(TextBoxBorderMouseOverBrushProperty, value);
                OnPropertyChanged(nameof(TextBoxBorderMouseOverBrush));
            }
        }

        public Brush TextBoxForegroundMouseOverBrush
        {
            get => (Brush)GetValue(TextBoxForegroundMouseOverBrushProperty);
            set
            {
                SetValue(TextBoxForegroundMouseOverBrushProperty, value);
                OnPropertyChanged(nameof(TextBoxForegroundMouseOverBrush));
            }
        }

        public Brush TextBoxBackgroundSelectedBrush
        {
            get => (Brush)GetValue(TextBoxBackgroundSelectedBrushProperty);
            set
            {
                SetValue(TextBoxBackgroundSelectedBrushProperty, value);
                OnPropertyChanged(nameof(TextBoxBackgroundSelectedBrush));
            }
        }

        public Brush TextBoxBorderSelectedBrush
        {
            get => (Brush)GetValue(TextBoxBorderSelectedBrushProperty);
            set
            {
                SetValue(TextBoxBorderSelectedBrushProperty, value);
                OnPropertyChanged(nameof(TextBoxBorderSelectedBrush));
            }
        }

        public Brush TextBoxForegroundSelectedBrush
        {
            get => (Brush)GetValue(TextBoxForegroundSelectedBrushProperty);
            set
            {
                SetValue(TextBoxForegroundSelectedBrushProperty, value);
                OnPropertyChanged(nameof(TextBoxForegroundSelectedBrush));
            }
        }

        public Brush TextBoxTextSelectedBrush
        {
            get => (Brush)GetValue(TextBoxTextSelectedBrushProperty);
            set
            {
                SetValue(TextBoxTextSelectedBrushProperty, value);
                OnPropertyChanged(nameof(TextBoxTextSelectedBrush));
            }
        }

        #endregion Appearance TextBoxes Colors

        public string CurrentDirectory
        {
            get => _currentDirectory;
            protected set
            {
                _currentDirectory = value;
                OnPropertyChanged(nameof(CurrentDirectory));
            }
        }

        public InternalMessageFileType FileType
        {
            get => _fileType;
            protected set
            {
                _fileType = value;
                OnPropertyChanged(nameof(FileType));
            }
        }

        public string InitialDirectory
        {
            get => _initialDirectory;
            set
            {
                if (Directory.Exists(value))
                    _initialDirectory = value;
                OnPropertyChanged(nameof(InitialDirectory));
            }
        }

        public bool AllowCreate
        {
            get => (bool)GetValue(AllowCreateProperty);
            set
            {
                SetValue(AllowCreateProperty, value);
                OnPropertyChanged(nameof(AllowCreate));

                if (value == true)
                    MultipleFiles = false;
            }
        }

        public ObservableCollection<InternalMessageFileType> FilesTypes
        {
            get => (ObservableCollection<InternalMessageFileType>)GetValue(FilesTypesProperty);
            set
            {
                SetValue(FilesTypesProperty, value);
                OnPropertyChanged(nameof(FilesTypes));

                if (IsLoadingComplete)
                {
                    _fileType = FilesTypes.FirstOrDefault();
                    _filesTypesComboBox.SelectedItem = _fileType;
                }
            }
        }

        public bool MultipleFiles
        {
            get => (bool)GetValue(MultipleFilesProperty);
            set
            {
                SetValue(MultipleFilesProperty, value);
                OnPropertyChanged(nameof(MultipleFiles));

                if (value == true)
                {
                    AllowCreate = false;
                    OnlyDirectories = false;
                }
            }
        }

        public bool OnlyDirectories
        {
            get => (bool)GetValue(OnlyDirectoriesProperty);
            set
            {
                SetValue(OnlyDirectoriesProperty, value);
                OnPropertyChanged(nameof(OnlyDirectories));

                if (value == true)
                {
                    MultipleFiles = false;
                    UseFilesTypes = false;
                }
            }
        }

        public bool UseFilesTypes
        {
            get => (bool)GetValue(UseFilesTypesProperty);
            set
            {
                SetValue(UseFilesTypesProperty, value);
                OnPropertyChanged(nameof(UseFilesTypes));

                if (value == true)
                    OnlyDirectories = false;
            }
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> FilesSelectorInternalMessage class constructor. </summary>
        /// <param name="parentContainer"> Parent InternalMessages container. </param>
        public FilesSelectorInternalMessage(InternalMessagesContainer parentContainer) : base(parentContainer)
        {
            _historyForward = new List<string>();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static FilesSelectorInternalMessage class constructor. </summary>
        static FilesSelectorInternalMessage()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FilesSelectorInternalMessage),
                new FrameworkPropertyMetadata(typeof(FilesSelectorInternalMessage)));
        }

        #endregion CLASS METHODS

        #region CHECKBOXES METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing file type selection. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Selection Changed Event Arguments. </param>
        private void OnFileTypeComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBoxEx = sender as ExtComboBox;

            if (comboBoxEx != null && comboBoxEx.SelectedItem != null)
            {
                FileType = comboBoxEx.SelectedItem as InternalMessageFileType;
                OnNavigate();
            }
        }

        #endregion CHECKBOXES METHODS

        #region BUTTONS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Ok Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnBackClick(object sender, RoutedEventArgs e)
        {
            GoBack();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Ok Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnForwardClick(object sender, RoutedEventArgs e)
        {
            GoForward();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Ok Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnNavigateClick(object sender, RoutedEventArgs e)
        {
            Navigate(_addressTextBox.Text);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Ok Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnOkClick(object sender, RoutedEventArgs e)
        {
            Result = InternalMessageResult.Ok;
            Close();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Yes Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnCancelClick(object sender, RoutedEventArgs e)
        {
            Result = InternalMessageResult.Cancel;
            Close();
        }

        #endregion BUTTONS METHODS

        #region DATA METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Get list of files and directories inside selected path. </summary>
        /// <returns> List of files and directories. </returns>
        protected List<InternalMessageFileItem> GetFilesAndDirectories()
        {
            List<InternalMessageFileItem> result = new List<InternalMessageFileItem>();

            if (Directory.Exists(CurrentDirectory))
            {
                //  Get directories.
                foreach (var directoryPath in Directory.GetDirectories(CurrentDirectory))
                {
                    var fileInfo = new FileInfo(directoryPath);

                    if (fileInfo.Attributes.HasFlag(FileAttributes.Directory)
                        && !fileInfo.Attributes.HasFlag(FileAttributes.Hidden)
                        && !fileInfo.Attributes.HasFlag(FileAttributes.System))
                        result.Add(new InternalMessageFileItem(directoryPath));
                }

                //  Get files.
                if (!OnlyDirectories)
                {
                    var checkType = UseFilesTypes && FileType != null;

                    foreach (var filePath in Directory.GetFiles(CurrentDirectory))
                    {
                        var fileInfo = new FileInfo(filePath);

                        if (!fileInfo.Attributes.HasFlag(FileAttributes.Hidden)
                            && !fileInfo.Attributes.HasFlag(FileAttributes.System)
                            && (checkType ? FileType.MatchFile(Path.GetFileName(Path.GetFileName(filePath))) : true))
                            result.Add(new InternalMessageFileItem(filePath));
                    }
                }
            }

            //  Get drives.
            else if (string.IsNullOrEmpty(CurrentDirectory))
            {
                foreach (var drive in DriveInfo.GetDrives())
                {
                    if (Directory.Exists(drive.Name) || File.Exists(drive.Name))
                        result.Add(new InternalMessageFileItem(drive.Name));
                }
            }

            return result;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get list of directories with subdirectories tree. </summary>
        /// <returns> List of directories with subdirectories tree. </returns>
        protected List<InternalMessageFileTreeItem> GetDirectoriesTree()
        {
            List<InternalMessageFileTreeItem> result = new List<InternalMessageFileTreeItem>();
            List<string> hierarchy = GetTreeHierarchy();

            //  Get drives.
            foreach (var drive in DriveInfo.GetDrives())
            {
                if (Directory.Exists(drive.Name) || File.Exists(drive.Name))
                    result.Add(new InternalMessageFileTreeItem(drive.Name));
            }

            if (hierarchy.Any())
            {
                FillTreeContent(result.FirstOrDefault(t => t.Path == hierarchy[0]), hierarchy);
            }

            return result;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Fill nestings in list of directories. </summary>
        /// <param name="item"> Nested file tree item. </param>
        /// <param name="hierarchy"> List of paths forward. </param>
        private void FillTreeContent(InternalMessageFileTreeItem item, List<string> hierarchy)
        {
            if (item != null && hierarchy.Any())
            {
                foreach (var directoryPath in Directory.GetDirectories(hierarchy[0]))
                {
                    var fileInfo = new FileInfo(directoryPath);

                    if (fileInfo.Attributes.HasFlag(FileAttributes.Directory)
                        && !fileInfo.Attributes.HasFlag(FileAttributes.Hidden)
                        && !fileInfo.Attributes.HasFlag(FileAttributes.System))
                        item.SubDirectories.Add(new InternalMessageFileTreeItem(directoryPath));
                }

                hierarchy.RemoveAt(0);

                if (hierarchy.Any())
                {
                    FillTreeContent(item.SubDirectories.FirstOrDefault(t => t.Path == hierarchy[0]), hierarchy);
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get list of parent directories from selected directory. </summary>
        /// <returns> List of parent directories. </returns>
        private List<string> GetTreeHierarchy()
        {
            List<string> result = new List<string>();
            string directory = CurrentDirectory;

            while (directory != null)
            {
                result.Insert(0, directory);
                directory = Path.GetDirectoryName(directory);
            }

            return result;
        }

        #endregion DATA METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Create close method event arguments. </summary>
        /// <returns> Close method event arguments. </returns>
        protected override FilesSelectorInternalMessageCloseEventArgs CreateCloseEventArgs()
        {
            return new FilesSelectorInternalMessageCloseEventArgs(Result, null);
        }

        #endregion INTERACTION METHODS

        #region NAVIGATION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Go to the directory above. </summary>
        protected void GoBack()
        {
            if (!string.IsNullOrEmpty(_currentDirectory))
            {
                var previousDirectory = Path.GetDirectoryName(CurrentDirectory);

                _historyForward.Insert(0, CurrentDirectory);

                CurrentDirectory = previousDirectory;
                _addressTextBox.Text = previousDirectory;
                OnNavigate();
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Go to previous visited directory. </summary>
        protected void GoForward()
        {
            if (_historyForward != null && _historyForward.Any())
            {
                var forwardDirectory = _historyForward[0];

                if (Directory.Exists(forwardDirectory))
                {
                    _historyForward.RemoveAt(0);

                    CurrentDirectory = forwardDirectory;
                    _addressTextBox.Text = forwardDirectory;
                    OnNavigate();
                }
                else
                {
                    _historyForward.Clear();
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Navigate to specified directory. </summary>
        /// <param name="directoryPath"> Directory path. </param>
        protected void Navigate(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                _historyForward.Clear();
                _historyForward.Insert(0, CurrentDirectory);

                CurrentDirectory = directoryPath;
                _addressTextBox.Text = directoryPath;
                OnNavigate();
            }
            else
            {
                _addressTextBox.Text = CurrentDirectory;
            }
        }

        #endregion NAVIGATION METHODS

        #region TEMPLATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Apply Selection changed method on ExtComboBox. </summary>
        /// <param name="extComboBox"> ExtComboBox. </param>
        /// <param name="eventHandler"> Selection changed method. </param>
        protected void ApplyExtComboBoxSelectionChangedMethod(ExtComboBox extComboBox, SelectionChangedEventHandler eventHandler)
        {
            if (extComboBox != null)
                extComboBox.SelectionChanged += eventHandler;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Apply TextModified method on ExtTextBox. </summary>
        /// <param name="extTextBox"> ExtTextBox. </param>
        /// <param name="eventHandler"> TextModified method. </param>
        protected void ApplyExtTextBoxTextModifiedMethod(ExtTextBox extTextBox, TextModifiedEventHandler eventHandler)
        {
            if (extTextBox != null)
                extTextBox.TextModified += eventHandler;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get ExtComboBox from ContentTemplate. </summary>
        /// <param name="comboBoxName"> ExtComboBox name. </param>
        /// <returns> ExtComboBox or null. </returns>
        protected ExtComboBox GetExtComboBox(string comboBoxName)
        {
            return this.Template.FindName(comboBoxName, this) as ExtComboBox;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get ExtTextBox from ContentTemplate. </summary>
        /// <param name="textBoxName"> TextBoxEx name. </param>
        /// <returns> TextBoxEx or null. </returns>
        protected ExtTextBox GetExtTextBox(string textBoxName)
        {
            return this.Template.FindName(textBoxName, this) as ExtTextBox;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> When overridden in a derived class,cis invoked whenever 
        /// application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            //  Apply Template
            base.OnApplyTemplate();

            _currentDirectory = InitialDirectory;

            ApplyExtButtonClickMethod(GetExtButton("cancelButton"), OnCancelClick);
            ApplyExtButtonClickMethod(GetExtButton("okButton"), OnOkClick);
            ApplyExtButtonClickMethod(GetExtButton("backButton"), OnBackClick);
            ApplyExtButtonClickMethod(GetExtButton("forwardButton"), OnForwardClick);
            ApplyExtButtonClickMethod(GetExtButton("goButton"), OnNavigateClick);

            _addressTextBox = GetExtTextBox("addressTextBox");
            _addressTextBox.Text = CurrentDirectory;
            _addressTextBox.PreviewKeyDown += OnAddressTextBoxExPreviewKeyDown;

            _filesTextBox = GetExtTextBox("fileNameTextBox");
            _filesTextBox.Text = string.Empty;

            ApplyExtTextBoxTextModifiedMethod(_addressTextBox, OnAddressTextBoxExTextModified);
            ApplyExtTextBoxTextModifiedMethod(_filesTextBox, OnFileNameTextBoxExTextModified);

            _filesTypesComboBox = GetExtComboBox("filesTypesComboBox");
            _fileType = FilesTypes.FirstOrDefault();
            _filesTypesComboBox.SelectedItem = _fileType;

            ApplyExtComboBoxSelectionChangedMethod(_filesTypesComboBox, OnFileTypeComboBoxSelectionChanged);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after navigating / changing path for refresh data. </summary>
        protected virtual void OnNavigate()
        {
            //
        }

        #endregion TEMPLATE METHODS

        #region TEXTBOXES METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing text in AddressTextBoxEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Text Modified Event Arguments. </param>
        protected virtual void OnAddressTextBoxExTextModified(object sender, TextModifiedEventArgs e)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after pressing key in AddressTextBoxEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Key Event Arguments. </param>
        protected virtual void OnAddressTextBoxExPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Navigate(_addressTextBox.Text);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing text in FileNameTextBoxEx. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Text Modified Event Arguments. </param>
        protected virtual void OnFileNameTextBoxExTextModified(object sender, TextModifiedEventArgs e)
        {
            //
        }

        #endregion TEXTBOXES METHODS

        #region UTILITY METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Get list of files names from list in string available in fileNameTextBox. </summary>
        /// <param name="filesList"> List of files in string. </param>
        /// <returns> List of files names. </returns>
        protected List<string> GetFilesListFromString(string filesList)
        {
            if (!string.IsNullOrEmpty(filesList))
            {
                var matchList = Regex.Matches(filesList, "\"(.*?)\"");

                if (matchList.Count > 0)
                    return matchList.Cast<Match>().Select(match => ReplaceFilesInvalidCharacters(match.Value)).ToList();
                else
                    return new List<string>() { filesList };
            }

            return new List<string>();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Replace invalid characters in file name. </summary>
        /// <param name="fileName"> File name. </param>
        /// <returns> Corrected file name. </returns>
        protected string ReplaceFilesInvalidCharacters(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
            {
                var updatedFileName = fileName;

                foreach (var character in FORBIDDEN_CHARACTERS)
                    updatedFileName = updatedFileName.Replace(character, "");

                return updatedFileName;
            }

            return fileName;
        }

        #endregion UTILITY METHODS

    }
}

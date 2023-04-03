using ProjectManager.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace ProjectManager.Data.Storyboards
{
    public class StoryboardMarginDataHandler : INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private Thickness _margin;
        private bool _running = false;
        private Storyboard _storyboard;


        //  METHODS

        public Thickness Margin
        {
            get => _margin;
            set
            {
                _margin = value;
                OnPropertyChanged(nameof(Margin));
            }
        }

        public bool Running
        {
            get => _running;
        }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> StoryboardMarginDataHandler class constructor. </summary>
        /// <param name="storyboard"> Storyboard. </param>
        public StoryboardMarginDataHandler(Storyboard storyboard)
        {
            _storyboard = storyboard;
            _storyboard.Completed += Storyboard_Completed;
        }

        #endregion CLASS METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Run storyboard. </summary>
        /// <param name="targetMargin"> Target margin value. </param>
        public void RunStoryboard(Thickness? targetMargin = null)
        {
            if (targetMargin.HasValue)
            {
                Margin = targetMargin.Value;
            }

            NotifyStoryboardStart();
            _storyboard.Begin();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after finishing showing/hiding quick view animation. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Event Arguments. </param>
        public void Storyboard_Completed(object sender, EventArgs e)
        {
            NotifyStoryboardFinish();
        }

        #endregion INTERACTION METHODS

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

        #region UTILITY METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Notify storyboard start. </summary>
        protected void NotifyStoryboardStart()
        {
            _running = true;
            OnPropertyChanged(nameof(Running));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Notify storyboard finish. </summary>
        protected void NotifyStoryboardFinish()
        {
            _running = false;
            OnPropertyChanged(nameof(Running));
        }

        #endregion UTILITY METHODS

    }
}

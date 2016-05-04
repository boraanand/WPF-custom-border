using System.ComponentModel;

namespace CustomControl.ViewModels
{
    /// <summary>
    /// View model for MainWindow.xaml view
    /// </summary>
    class CustomBoxViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion

        #region Properties
        // Properties bind to check boxes on UI. 

        /// <summary>
        /// 'All' check box is mutually exclusive to left, right, top, bottom
        /// </summary>
        private bool all;
        public bool All
        {
            get
            {
                return all;
            }
            set
            {
                all = value;
                if (value == true)
                {
                    left = false;
                    top = false;
                    right = false;
                    bottom = false;

                    RaisePropertyChanged(nameof(Left));
                    RaisePropertyChanged(nameof(Top));
                    RaisePropertyChanged(nameof(Right));
                    RaisePropertyChanged(nameof(Bottom));
                }

                RaisePropertyChanged(nameof(All));
            }
        }

        /// <summary>
        /// Check box is mutually exclusive 'all'
        /// </summary>
        private bool left;
        public bool Left
        {
            get
            {
                return left;
            }
            set
            {
                left = value;
                if (value == true)
                {
                    all = false;
                    RaisePropertyChanged(nameof(All));
                }
                RaisePropertyChanged(nameof(Left));
            }
        }

        /// <summary>
        /// Check box is mutually exclusive 'all'
        /// </summary>
        private bool top;
        public bool Top
        {
            get
            {
                return top;
            }
            set
            {
                top = value;
                if (value == true)
                {
                    all = false;
                    RaisePropertyChanged(nameof(All));
                }
                RaisePropertyChanged(nameof(Top));
            }
        }

        /// <summary>
        /// Check box is mutually exclusive 'all'
        /// </summary>
        private bool right;
        public bool Right
        {
            get
            {
                return right;
            }
            set
            {
                right = value;
                if (value == true)
                {
                    all = false;
                    RaisePropertyChanged(nameof(All));
                }
                RaisePropertyChanged(nameof(Right));
            }
        }

        /// <summary>
        /// Check box is mutually exclusive 'all'
        /// </summary>
        private bool bottom;
        public bool Bottom
        {
            get
            {
                return bottom;
            }
            set
            {
                bottom = value;
                if (value == true)
                {
                    all = false;
                    RaisePropertyChanged(nameof(All));
                }
                RaisePropertyChanged(nameof(Bottom));
            }
        }

        #endregion
    }
}

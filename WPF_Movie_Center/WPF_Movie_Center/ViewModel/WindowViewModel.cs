using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_Movie_Center
{
    /// <summary>
    /// The View Model for custom flat window
    /// </summary>
    class WindowViewModel : BaseViewModel
    {
       



        #region Private Member
         /// <summary>
        /// The window this view model controls
        /// </summary>
        private Window mWindow;
        
        /// <summary>
        /// The margin arout the window to allow for a drop shadow
        /// </summary>
        private int mOuterMarginSize = 10;

        /// <summary>
        /// The radiuss at the edges of the window
        /// </summary>
        private int mWindowRadius = 10;
        #endregion

        #region Properties
        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        public int ResizeBorder { get; set; } = 6;
        /// <summary>
        /// The size of the resize border arount the window, taking into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }

        /// <summary>
        /// The margin arout the window to allow for a drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize;
            }
            set
            {
                mOuterMarginSize = value;
            }
        }
        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

        /// <summary>
        /// The radiuss at the edges of the window
        /// </summary>
        public int WindowRadius
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius;
            }
            set
            {
                mWindowRadius = value;
            }
        }
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }



        /// <summary>
        /// The hight of the title bar
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        /// <summary>
        /// The hight of the title bar
        /// </summary>
        public GridLength TitleHeightGridLenght { get { return new GridLength(TitleHeight + ResizeBorder); } }

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public WindowViewModel(Window window)
        {
            mWindow = window;

            // Listen out for the window resizing
            mWindow.StateChanged += (sender, e) =>
            {
                // FIre off events for all properties that are affected by a resize
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };
        }
        #endregion
    }
}

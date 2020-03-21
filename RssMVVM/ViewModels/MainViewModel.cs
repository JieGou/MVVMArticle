// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="Reed Copsey, Jr.">
//   Copyright 2009, Reed Copsey, Jr.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RssMVVM.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Windows.Input;

    using RssModel;

    /// <summary>
    /// The Main ViewModel class
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Our current feed
        /// </summary>
        private Feed feed;

        /// <summary>
        /// The current Uri
        /// </summary>
        private Uri uri;

        /// <summary>
        /// The current FeedViewModel
        /// </summary>
        private FeedViewModel feedViewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {
            // Just providing a default Uri to use here...
            this.Uri = new Uri("http://www.microsoft.com/feeds/msdn/en-us/rss.xml");
            this.LoadFeedCommand = new ActionCommand(() => this.Feed = Feed.Read(this.Uri), () => true);
            this.LoadFeedCommand.Execute(null); // Provide default set of behavior
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets the load feed command.
        /// </summary>
        /// <value>The command to load a feed.</value>
        public ICommand LoadFeedCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the Uri.
        /// </summary>
        /// <value>The Current Uri.</value>
        public Uri Uri
        {
            get
            {
                return this.uri;
            }

            set
            {
                if (this.uri != value)
                {
                    this.uri = value;
                    this.RaisePropertyChanged("Uri");
                }
            }
        }

        /// <summary>
        /// Gets the current feed.
        /// </summary>
        /// <value>The current feed.</value>
        public Feed Feed
        {
            get
            {
                return this.feed;
            }

            private set
            {
                if (this.feed != value)
                {
                    this.feed = value;
                    this.RaisePropertyChanged("Feed");
                    this.FeedViewModel = new FeedViewModel
                                             {
                                                 Feed = this.feed
                                             };
                }
            }
        }

        /// <summary>
        /// Gets the current FeedViewModel.
        /// </summary>
        /// <value>The feed ViewModel.</value>
        public FeedViewModel FeedViewModel
        {
            get
            {
                return this.feedViewModel;
            }
            
            private set
            {
                if (this.feedViewModel != value)
                {
                    if (this.feedViewModel != null)
                    {
                        this.feedViewModel.PropertyChanged -= this.FeedViewModel_PropertyChanged;
                    }

                    this.feedViewModel = value;
                    this.feedViewModel.PropertyChanged += this.FeedViewModel_PropertyChanged;
                }

                this.RaisePropertyChanged("FeedViewModel");
            }
        }

        /// <summary>
        /// Handles the PropertyChanged event of the FeedViewModel
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance containing the event data.</param>
        private void FeedViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedFeedItem")
            {
                this.Uri = this.FeedViewModel.SelectedFeedItem.Link;
            }
        }

        /// <summary>
        /// Raises the property changed event.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FeedViewModel.cs" company="Reed Copsey, Jr.">
//   Copyright 2009, Reed Copsey, Jr.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RssMVVM.ViewModels
{
    using System.ComponentModel;
    using System.Windows.Input;
    using RssModel;

    /// <summary>
    /// The ViewModel for a Feed
    /// </summary>
    public class FeedViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The current feed
        /// </summary>
        private Feed feed;

        /// <summary>
        /// The current FeedItem
        /// </summary>
        private FeedItem feedItem;

        /// <summary>
        /// Initializes a new instance of the <see cref="FeedViewModel"/> class.
        /// </summary>
        public FeedViewModel()
        {
            this.OpenFeedCommand = new ActionCommand(this.OpenFeed, () => true);
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the feed.
        /// </summary>
        /// <value>The current feed.</value>
        public Feed Feed
        {
            get
            {
                return this.feed;
            }

            set
            {
                if (this.feed != value)
                {
                    this.feed = value;
                    this.RaisePropertyChanged("Feed");
                }
            }
        }

        /// <summary>
        /// Gets or sets the selected feed item.
        /// </summary>
        /// <value>The selected feed item.</value>
        public FeedItem SelectedFeedItem
        {
            get
            {
                return this.feedItem;
            }

            set
            {
                if (this.feedItem != value)
                {
                    this.feedItem = value;
                    this.RaisePropertyChanged("SelectedFeedItem");
                }
            }
        }

        /// <summary>
        /// Gets the open feed command.
        /// </summary>
        /// <value>The open feed command.</value>
        public ICommand OpenFeedCommand
        {
            get; 
            private set;
        }

        /// <summary>
        /// Opens the feed.
        /// </summary>
        private void OpenFeed()
        {
            if (this.SelectedFeedItem != null)
            {
                System.Diagnostics.Process.Start(this.SelectedFeedItem.Link.AbsoluteUri);
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

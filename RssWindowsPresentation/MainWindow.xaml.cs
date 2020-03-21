// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Reed Copsey, Jr.">
//   Copyright 2009, Reed Copsey, Jr.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RssWindowsPresentation
{
    using System;
    using System.Windows;

    using RssModel;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the buttonUpdateFeed control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void ButtonUpdateFeed_Click(object sender, RoutedEventArgs e)
        {
            this.feedControl.Feed = Feed.Read(new Uri(this.textBoxFeedUrl.Text));
        }

        /// <summary>
        /// Handles the UriChanged event of the feedControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RssWindowsPresentation.UriChangedEventArgs"/> instance containing the event data.</param>
        private void FeedControl_UriChanged(object sender, UriChangedEventArgs e)
        {
            this.webBrowserFeedDetails.Source = e.Uri;
        }
    }
}

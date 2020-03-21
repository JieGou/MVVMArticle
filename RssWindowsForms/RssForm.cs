// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RssForm.cs" company="Reed Copsey, Jr.">
//   Copyright 2009, Reed Copsey, Jr.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RSSWindowsForms
{
    using System;
    using System.Windows.Forms;

    using RssModel;

    /// <summary>
    /// The Main Windows Form
    /// </summary>
    public partial class RssForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RssForm"/> class.
        /// </summary>
        public RssForm()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the buttonUpdateFeed control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ButtonUpdateFeed_Click(object sender, EventArgs e)
        {
            this.feedControl.Feed = Feed.Read(new Uri(this.textBox1.Text));
        }

        /// <summary>
        /// Handles the UriChanged event of the feedControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RSSWindowsForms.UriChangedEventArgs"/> instance containing the event data.</param>
        private void FeedControl_UriChanged(object sender, UriChangedEventArgs e)
        {
            this.webBrowserFeedDetails.Url = e.Uri;
        }
    }
}

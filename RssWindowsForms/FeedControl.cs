﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FeedControl.cs" company="Reed Copsey, Jr.">
//   Copyright 2009, Reed Copsey, Jr.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RSSWindowsForms
{
    using System;
    using System.Windows.Forms;

    using RssModel;

    /// <summary>
    /// The main Feed UserControl for presentation
    /// </summary>
    public partial class FeedControl : UserControl
    {
        /// <summary>
        /// The current feed
        /// </summary>
        private Feed feed;

        /// <summary>
        /// Initializes a new instance of the <see cref="FeedControl"/> class.
        /// </summary>
        public FeedControl()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Event that fires whenever the selected Uri changes
        /// </summary>
        public event EventHandler<UriChangedEventArgs> UriChanged;

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
                this.feed = value;
                this.ResetFeed();
            }
        }

        /// <summary>
        /// Clears the feed.
        /// </summary>
        private void ClearFeed()
        {
            this.listBoxFeeds.Items.Clear();
            this.textBoxTitle.Text = string.Empty;
            this.textBoxLink.Text = string.Empty;
            this.textBoxDescription.Text = string.Empty;
            this.textBoxItemTitle.Text = string.Empty;
            this.textBoxItemLink.Text = string.Empty;
            this.textBoxItemDescription.Text = string.Empty;
        }

        /// <summary>
        /// Resets the feed.
        /// </summary>
        private void ResetFeed()
        {
            this.ClearFeed();

            if (this.Feed == null)
            {
                return;
            }

            this.textBoxTitle.Text = this.Feed.Title;
            this.textBoxLink.Text = this.Feed.Link.AbsoluteUri;
            this.textBoxDescription.Text = this.Feed.Description;

            foreach (var item in this.Feed.Items)
            {
                this.listBoxFeeds.Items.Add(item.Title);
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the listBoxFeeds control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ListBoxFeeds_SelectedIndexChanged(object sender, EventArgs e)
        {
            FeedItem item = this.Feed.Items[this.listBoxFeeds.SelectedIndex];
            this.textBoxItemTitle.Text = item.Title;
            this.textBoxItemLink.Text = item.Link.AbsoluteUri;
            this.textBoxItemDescription.Text = item.Description;

            if (this.UriChanged != null)
            {
                this.UriChanged(this, new UriChangedEventArgs(new Uri(this.textBoxItemLink.Text)));
            }
        }

        /// <summary>
        /// Handles the Click event of the buttonOpenLink control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ButtonOpenLink_Click(object sender, EventArgs e)
        {
            if (this.Feed != null)
            {
                FeedItem item = this.Feed.Items[this.listBoxFeeds.SelectedIndex];
                if (item != null)
                {
                    System.Diagnostics.Process.Start(item.Link.AbsoluteUri);
                }
            }
        }
    }
}

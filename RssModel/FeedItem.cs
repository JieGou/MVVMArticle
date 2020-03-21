// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FeedItem.cs" company="Reed Copsey, Jr.">
//   Copyright 2009, Reed Copsey, Jr.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RssModel
{
    using System;

    /// <summary>
    /// A single feed item in the model
    /// </summary>
    public class FeedItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeedItem"/> class.
        /// </summary>
        /// <param name="title">The title of the feed item.</param>
        /// <param name="description">The description of the feed item.</param>
        /// <param name="link">The link of the feed item.</param>
        public FeedItem(string title, string description, Uri link)
        {
            this.Title = title;
            this.Description = description;
            this.Link = link;
        }

        /// <summary>
        /// Gets the title of the feed item.
        /// </summary>
        /// <value>The title of the feed item.</value>
        public string Title
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the link of the feed item.
        /// </summary>
        /// <value>The link of the feed item.</value>
        public Uri Link
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the description of the feed item.
        /// </summary>
        /// <value>The description of the feed item.</value>
        public string Description
        {
            get;
            private set;
        }
    }
}
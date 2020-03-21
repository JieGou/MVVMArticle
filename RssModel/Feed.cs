// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Feed.cs" company="Reed Copsey, Jr.">
//   Copyright 2009, Reed Copsey, Jr.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RssModel
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The main Feed model class
    /// </summary>
    public class Feed 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Feed"/> class.
        /// </summary>
        /// <param name="title">The feed title.</param>
        /// <param name="description">The feed description.</param>
        /// <param name="link">The feed's link.</param>
        internal Feed(string title, string description, Uri link)
        {
            this.Title = title;
            this.Description = description;
            this.Link = link;
            this.Items = new List<FeedItem>();
        }

        /// <summary>
        /// Gets the feed title.
        /// </summary>
        /// <value>The title of the feed.</value>
        public string Title
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the link.
        /// </summary>
        /// <value>The feed link.</value>
        public Uri Link
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the feed items.
        /// </summary>
        /// <value>The feed items.</value>
        public IList<FeedItem> Items
        {
            get;
            private set;
        }

        /// <summary>
        /// Reads a feed from the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>A newly constructed Feed</returns>
        public static Feed Read(Uri source)
        {
            return FeedReader.Read(source);
        }
    }
}

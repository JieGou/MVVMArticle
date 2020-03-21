// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UriChangedEventArgs.cs" company="Reed Copsey, Jr.">
//   Copyright 2009, Reed Copsey, Jr.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RSSWindowsForms
{
    using System;

    /// <summary>
    /// Custom EventArgs for the UriChanged event
    /// </summary>
    public class UriChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UriChangedEventArgs"/> class.
        /// </summary>
        /// <param name="newUri">The new URI.</param>
        public UriChangedEventArgs(Uri newUri)
        {
            this.Uri = newUri;
        }

        /// <summary>
        /// Gets the new URI.
        /// </summary>
        /// <value>The new URI.</value>
        public Uri Uri
        {
            get;
            private set;
        }
    }
}
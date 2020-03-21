// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Reed Copsey, Jr.">
//   Copyright 2009, Reed Copsey, Jr.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace RSSWindowsForms
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// The main program entry point
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RssForm());
        }
    }
}

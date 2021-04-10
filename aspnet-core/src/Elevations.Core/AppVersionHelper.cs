﻿namespace Elevations
{
    using System;
    using System.IO;

    using Abp.Reflection.Extensions;

    /// <summary>
    ///     Central point for application version.
    /// </summary>
    public class AppVersionHelper
    {
        /// <summary>
        ///     Gets current version of the application.
        ///     It's also shown in the web page.
        /// </summary>
        public const string Version = "5.5.0.0";

        private static readonly Lazy<DateTime> LzyReleaseDate = new(
            () => new FileInfo(typeof(AppVersionHelper).GetAssembly().Location).LastWriteTime);

        /// <summary>
        ///     Gets release (last build) date of the application.
        ///     It's shown in the web page.
        /// </summary>
        public static DateTime ReleaseDate
        {
            get
            {
                return LzyReleaseDate.Value;
            }
        }
    }
}
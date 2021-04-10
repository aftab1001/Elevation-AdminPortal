namespace Elevations.Sessions.Dto
{
    using System;
    using System.Collections.Generic;

    public class ApplicationInfoDto
    {
        public Dictionary<string, bool> Features { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Version { get; set; }
    }
}
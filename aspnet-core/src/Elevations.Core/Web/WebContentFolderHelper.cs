namespace Elevations.Web
{
    using System;
    using System.IO;
    using System.Linq;

    using Abp.Reflection.Extensions;

    /// <summary>
    ///     This class is used to find root path of the web project in;
    ///     unit tests (to find views) and entity framework core command line commands (to find conn string).
    /// </summary>
    public static class WebContentDirectoryFinder
    {
        public static string CalculateContentRootFolder()
        {
            string? coreAssemblyDirectoryPath =
                Path.GetDirectoryName(typeof(ElevationsCoreModule).GetAssembly().Location);
            if (coreAssemblyDirectoryPath == null)
            {
                throw new Exception("Could not find location of Elevations.Core assembly!");
            }

            DirectoryInfo directoryInfo = new DirectoryInfo(coreAssemblyDirectoryPath);
            while (!DirectoryContains(directoryInfo.FullName, "Elevations.sln"))
            {
                if (directoryInfo.Parent == null)
                {
                    throw new Exception("Could not find content root folder!");
                }

                directoryInfo = directoryInfo.Parent;
            }

            string webMvcFolder = Path.Combine(directoryInfo.FullName, "src", "Elevations.Web.Mvc");
            if (Directory.Exists(webMvcFolder))
            {
                return webMvcFolder;
            }

            string webHostFolder = Path.Combine(directoryInfo.FullName, "src", "Elevations.Web.Host");
            if (Directory.Exists(webHostFolder))
            {
                return webHostFolder;
            }

            throw new Exception("Could not find root folder of the web project!");
        }

        private static bool DirectoryContains(string directory, string fileName)
        {
            return Directory.GetFiles(directory).Any(filePath => string.Equals(Path.GetFileName(filePath), fileName));
        }
    }
}
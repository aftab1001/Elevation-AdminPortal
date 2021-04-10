namespace Elevations.Configuration.Ui
{
    using System.Collections.Generic;

    public static class UiThemes
    {
        static UiThemes()
        {
            All = new List<UiThemeInfo>
                      {
                          new("Red", "red"), new("Pink", "pink"), new("Purple", "purple"),
                          new("Deep Purple", "deep-purple"), new("Indigo", "indigo"), new("Blue", "blue"),
                          new("Light Blue", "light-blue"), new("Cyan", "cyan"), new("Teal", "teal"),
                          new("Green", "green"), new("Light Green", "light-green"), new("Lime", "lime"),
                          new("Yellow", "yellow"), new("Amber", "amber"), new("Orange", "orange"),
                          new("Deep Orange", "deep-orange"), new("Brown", "brown"), new("Grey", "grey"),
                          new("Blue Grey", "blue-grey"), new("Black", "black")
                      };
        }

        public static List<UiThemeInfo> All { get; }
    }
}
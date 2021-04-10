namespace Elevations.Configuration.Ui
{
    public class UiThemeInfo
    {
        public UiThemeInfo(string name, string cssClass)
        {
            Name = name;
            CssClass = cssClass;
        }

        public string CssClass { get; }

        public string Name { get; }
    }
}
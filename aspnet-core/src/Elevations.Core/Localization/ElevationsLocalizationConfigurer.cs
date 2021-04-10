namespace Elevations.Localization
{
    using Abp.Configuration.Startup;
    using Abp.Localization.Dictionaries;
    using Abp.Localization.Dictionaries.Xml;
    using Abp.Reflection.Extensions;

    public static class ElevationsLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    ElevationsConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(ElevationsLocalizationConfigurer).GetAssembly(),
                        "Elevations.Localization.SourceFiles")));
        }
    }
}
namespace Elevations.EntityFrameworkCore.Seed.Host
{
    using System.Collections.Generic;
    using System.Linq;

    using Abp.Localization;
    using Abp.MultiTenancy;

    using Microsoft.EntityFrameworkCore;

    public class DefaultLanguagesCreator
    {
        private readonly ElevationsDbContext _context;

        public DefaultLanguagesCreator(ElevationsDbContext context)
        {
            _context = context;
        }

        public static List<ApplicationLanguage> InitialLanguages
        {
            get
            {
                return GetInitialLanguages();
            }
        }

        public void Create()
        {
            CreateLanguages();
        }

        private static List<ApplicationLanguage> GetInitialLanguages()
        {
            int? tenantId = ElevationsConsts.MultiTenancyEnabled ? null : (int?)MultiTenancyConsts.DefaultTenantId;
            return new List<ApplicationLanguage>
                       {
                           new(tenantId, "en", "English", "famfamfam-flags us"),
                           new(tenantId, "ar", "العربية", "famfamfam-flags sa"),
                           new(tenantId, "de", "German", "famfamfam-flags de"),
                           new(tenantId, "it", "Italiano", "famfamfam-flags it"),
                           new(tenantId, "fa", "فارسی", "famfamfam-flags ir"),
                           new(tenantId, "fr", "Français", "famfamfam-flags fr"),
                           new(tenantId, "pt-BR", "Português", "famfamfam-flags br"),
                           new(tenantId, "tr", "Türkçe", "famfamfam-flags tr"),
                           new(tenantId, "ru", "Русский", "famfamfam-flags ru"),
                           new(tenantId, "zh-Hans", "简体中文", "famfamfam-flags cn"),
                           new(tenantId, "es-MX", "Español México", "famfamfam-flags mx"),
                           new(tenantId, "nl", "Nederlands", "famfamfam-flags nl"),
                           new(tenantId, "ja", "日本語", "famfamfam-flags jp")
                       };
        }

        private void AddLanguageIfNotExists(ApplicationLanguage language)
        {
            if (_context.Languages.IgnoreQueryFilters()
                .Any(l => l.TenantId == language.TenantId && l.Name == language.Name))
            {
                return;
            }

            _context.Languages.Add(language);
            _context.SaveChanges();
        }

        private void CreateLanguages()
        {
            foreach (ApplicationLanguage language in InitialLanguages)
            {
                AddLanguageIfNotExists(language);
            }
        }
    }
}
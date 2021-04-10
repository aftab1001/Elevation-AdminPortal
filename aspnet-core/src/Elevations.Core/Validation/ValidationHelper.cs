namespace Elevations.Validation
{
    using System.Text.RegularExpressions;

    using Abp.Extensions;

    public static class ValidationHelper
    {
        public const string EmailRegex = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        public static bool IsEmail(string value)
        {
            if (value.IsNullOrEmpty())
            {
                return false;
            }

            Regex regex = new Regex(EmailRegex);
            return regex.IsMatch(value);
        }
    }
}
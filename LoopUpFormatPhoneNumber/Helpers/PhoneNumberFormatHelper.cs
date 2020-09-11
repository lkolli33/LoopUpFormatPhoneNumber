using System;
using System.Text.RegularExpressions;

namespace LoopUpFormatPhoneNumber.Helpers
{
    public class PhoneNumberFormatHelper
    {
        #region Regex Patterns
        private static readonly Regex[] patterns =
        {
            new Regex(@"(?<first>13397)(?<second>\d{5})"),
            new Regex(@"(?<first>13398)(?<second>\d{5})"),
            new Regex(@"(?<first>13873)(?<second>\d{5})"),
            new Regex(@"(?<first>15242)(?<second>\d{5})"),
            new Regex(@"(?<first>15394)(?<second>\d{5})"),
            new Regex(@"(?<first>15395)(?<second>\d{5})"),
            new Regex(@"(?<first>15396)(?<second>\d{5})"),
            new Regex(@"(?<first>16973)(?<second>\d{5})"),
            new Regex(@"(?<first>16974)(?<second>\d{5})"),
            new Regex(@"(?<first>16977)(?<second>\d{4}\d?)"),
            new Regex(@"(?<first>17683)(?<second>\d{5})"),
            new Regex(@"(?<first>17684)(?<second>\d{5})"),
            new Regex(@"(?<first>17687)(?<second>\d{5})"),
            new Regex(@"(?<first>19467)(?<second>\d{5})"),
            new Regex(@"(?<first>19755)(?<second>\d{5})"),
            new Regex(@"(?<first>19756)(?<second>\d{5})"),
            new Regex(@"(?<first>2\d)(?<second>\d{4})(?<third>\d{4})"),
            new Regex(@"(?<first>3\d{2})(?<second>\d{3})(?<third>\d{4})"),
            new Regex(@"(?<first>5\d{3})(?<second>\d{3})(?<third>\d{4})"),
            new Regex(@"(?<first>7\d{3})(?<second>\d{6})"),
            new Regex(@"(?<first>800)(?<second>\d{6})"),
            new Regex(@"(?<first>8\d{2})(?<second>\d{3})(?<third>\d{4})"),
            new Regex(@"(?<first>9\d{2})(?<second>\d{3})(?<third>\d{4})"),
            new Regex(@"(?<first>1\d1)(?<second>\d{3})(?<third>\d{4})"),
            new Regex(@"(?<first>11\d)(?<second>\d{3})(?<third>\d{4})"),
            new Regex(@"(?<first>1\d{3})(?<second>\d{5}\d?)")
    
    };
        #endregion

        public static string FormatAsUkTelephone(string number)
        {
            Regex matchedPattern = null;

            int len = number.Length;
            string formatedNumber =  number.Substring(3, len - 3);
           
            foreach (Regex pattern in patterns)
            {
                if (pattern.IsMatch(formatedNumber))
                {
                    matchedPattern = pattern;
                    break;
                }
            }
            if (matchedPattern != null)
            {
                var mc = matchedPattern.Matches(formatedNumber);
                if (mc[0].Groups.Count == 3)
                {
                    return String.Format("{0} {1}", "0"+ mc[0].Groups["first"], mc[0].Groups["second"]);
                }
                else if (mc[0].Groups.Count == 4)
                {
                    return String.Format("{0} {1} {2}", "0" + mc[0].Groups["first"], mc[0].Groups["second"], mc[0].Groups["third"]);
                }
            }
            return formatedNumber;
        }
    }
}
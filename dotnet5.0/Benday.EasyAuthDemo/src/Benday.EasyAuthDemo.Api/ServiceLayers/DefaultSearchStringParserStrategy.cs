using System;

namespace Benday.EasyAuthDemo.Api.ServiceLayers
{
    public class DefaultSearchStringParserStrategy : ISearchStringParserStrategy
    {
        private static readonly string SemiColonDelimiter = ";";
        private static readonly string CommaDelimiter = ",";

        public string[] Parse(string parseThis)
        {
            if (parseThis == null)
            {
                return new string[] { };
            }
            else
            {
                parseThis = parseThis.Trim();

                if (parseThis.Length == 0 ||
                    parseThis.Replace(SemiColonDelimiter, String.Empty)
                    .Replace(CommaDelimiter, String.Empty).Length == 0)
                {
                    return new string[] { };
                }
                else
                {
                    return ParseNonEmptySearch(parseThis);
                }
            }
        }

        private string[] ParseNonEmptySearch(string parseThis)
        {
            var tokens = parseThis.Split(
                new string[] { SemiColonDelimiter, CommaDelimiter },
                StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < tokens.Length; i++)
            {
                tokens[i] = tokens[i].Trim();
            }

            return tokens;
        }
    }
}

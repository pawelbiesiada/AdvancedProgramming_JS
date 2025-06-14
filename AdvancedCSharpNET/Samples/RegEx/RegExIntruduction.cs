﻿using System;
using System.Text.RegularExpressions;

namespace AdvancedCSharp.Samples.RegEx
{
    class RegExIntruduction
    {
        const string AddressCodePattern = @"\d{2}-\d{3}";
        //const string AddressCodePattern = @"[0123456789]{2}-[0-9]{3}";
        const string HtmlTagsPatternGreedy = "<.+>";
        const string HtmlTagsPatternLazy = "<.+?>";

        static void Main()
        {
            Regex regex = new Regex("\\b(?<dopasowanie>\\w+)(?<kropka>\\.)");

            var inputSentence = "Mój kod poc00-000ztowy to 00-001 w Warszawie.";

            var wordMatch = regex.Match(inputSentence);
            if (wordMatch != null)
            {
                Console.WriteLine(wordMatch.Groups["dopasowanie"]);
            }


            Regex.Match(inputSentence, AddressCodePattern);
            var match = regex.Matches(inputSentence);
            if (match[0].Success)
            {
                Console.WriteLine(match[0].Value);
            }

            var htmlPartString = @"<body> Hello World </body>";
            var greedyMatches = Regex.Matches(htmlPartString, HtmlTagsPatternGreedy);
            var lazyMatches = Regex.Matches(htmlPartString, HtmlTagsPatternLazy);
            Console.WriteLine("Looking for matches of sentence pattern: {0}", htmlPartString);
            Console.WriteLine("Greedy pattern - matches: {0}\t matches are {1}", greedyMatches.Count, greedyMatches[0]);
            Console.WriteLine("Lazy pattern - matches: {0}\t matches are {1}, {2}", lazyMatches.Count, lazyMatches[0], lazyMatches[1]);

            //Regex.CacheSize - when used
            
            Console.ReadKey();
        }

    }
}

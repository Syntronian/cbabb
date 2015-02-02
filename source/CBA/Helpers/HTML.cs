using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CBA.Helpers
{
    public class HTML
    {
        public static string StripTags(string inputHTML)
        {
            if (string.IsNullOrEmpty(inputHTML)) return inputHTML;
            // from http://stackoverflow.com/questions/19523913/remove-html-tags-from-string-including-nbsp-in-c-sharp
            // If you can't use an HTML parser oriented solution to filter out the tags, here's a simple regex for it.
            var noHTML = Regex.Replace(inputHTML, @"<[^>]+>|&nbsp;", "").Trim();

            // You should ideally make another pass through a regex filter that takes care of multiple spaces as
            return Regex.Replace(noHTML, @"\s{2,}", " ");
        }

        /// <summary>
        /// from http://www.mikesdotnetting.com/Article/140/Converting-URLs-Into-Links-With-Regex
        /// Finds web and email addresses in a string and surrounds then with the appropriate HTML anchor tags 
        /// </summary>
        /// <param name="s"></param>
        /// <returns>String</returns>
        public static string WithActiveLinks(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;

            //Finds URLs with no protocol
            var urlregex = new Regex(@"\b\({0,1}(?<url>(www|ftp)\.[^ ,""\s<)]*)\b",
              RegexOptions.IgnoreCase | RegexOptions.Compiled);
            //Finds URLs with a protocol
            var httpurlregex = new Regex(@"\b\({0,1}(?<url>[^>](http://www\.|http://|https://|ftp://)[^,""\s<)]*)\b",
              RegexOptions.IgnoreCase | RegexOptions.Compiled);
            //Finds email addresses
            var emailregex = new Regex(@"\b(?<mail>[a-zA-Z_0-9.-]+\@[a-zA-Z_0-9.-]+\.\w+)\b",
              RegexOptions.IgnoreCase | RegexOptions.Compiled);
            s = urlregex.Replace(s, " <a href=\"http://${url}\" target=\"_blank\">${url}</a>");
            s = httpurlregex.Replace(s, " <a href=\"${url}\" target=\"_blank\">${url}</a>");
            s = emailregex.Replace(s, "<a href=\"mailto:${mail}\">${mail}</a>");
            return s;
        }
    }
}
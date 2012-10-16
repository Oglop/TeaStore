using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeaEWebStore.Helpers
{
    public static class HtmlHelpers
    {

        public static string Truncate(string input, int length)
        {
            if (input.Length <= length)
            {
                return input;
            }
            else
            {
                return input.Substring(0, length) + "...";
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAplikacija.Models.PomocneKlase
{
    public static class ExtensionMethods
    {
        public static string ExtendedToString<T>(this List<T> list)
        {
            string retVal = "";

            foreach (var s in list)
            {
                retVal += s + " ";
            }
            return retVal;
        }
    }
}
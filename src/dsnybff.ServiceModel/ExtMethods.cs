using System;
using System.Collections.Generic;
using System.Text;
using ServiceStack;

namespace dsnybff
{
    public static class ExtMethods
    {
        public static IEnumerable<string> ToList(this string s, char splitOn = ';')
        {
            return s?.Split(';');
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace Kajujam.Concrates.ExtensionMethods
{
    public static class ToStringExtension
    {
        public static string ToTitleCase(this string Text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Text);
        }
    }
}


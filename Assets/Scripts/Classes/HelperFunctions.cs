//
// Copyright (c) SunnyMonster
// https://www.youtube.com/channel/UCbKQHYlzpR_pa5UL7JNP3kg/
//

using System;
using UnityEngine;

namespace Classes
{
    public static class HelperFunctions
    {
        //draw a boundary box
        public static void DrawBoundaryAsGizmos(float maxX, float minX, float maxZ, float minZ, float lineHeight)
        {
            Gizmos.DrawLine(new Vector3(maxX, lineHeight, maxZ), new Vector3(maxX, lineHeight, minZ));
            Gizmos.DrawLine(new Vector3(maxX, lineHeight, minZ), new Vector3(minX, lineHeight, minZ));
            Gizmos.DrawLine(new Vector3(minX, lineHeight, minZ), new Vector3(minX, lineHeight, maxZ));
            Gizmos.DrawLine(new Vector3(minX, lineHeight, maxZ), new Vector3(maxX, lineHeight, maxZ));
        }

        public static float RoundToDecimalPlaces(float f, int decimalPlaces)
        {
            return Mathf.Round(f * Mathf.Pow(10f, decimalPlaces)) / Mathf.Pow(10f, decimalPlaces);
        }
        
        public static string TimeSpanToShortForm(TimeSpan t)
        {
            var shortForm = "";
            if (t.Days > 0)
            {
                shortForm += $"{t.Days.ToString()}d";
            }
            if (t.Hours > 0)
            {
                shortForm += $"{t.Hours.ToString()}h";
            }
            if (t.Minutes > 0)
            {
                shortForm += $"{t.Minutes.ToString()}m";
            }
            if (t.Seconds > 0)
            {
                shortForm += $"{t.Seconds.ToString()}s";
            }
            if (shortForm == "")
            {
                shortForm += "0s";
            }
            return shortForm;
        } 
    }
}
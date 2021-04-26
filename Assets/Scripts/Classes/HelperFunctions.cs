//
// Copyright (c) SunnyMonster
// https://www.youtube.com/channel/UCbKQHYlzpR_pa5UL7JNP3kg/
//

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
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace EisvilTest
{
    public static class LevelData
    {
        public static readonly Bound LevelBound = new(20.0f, 20.0f);

        public static readonly Vector3 PlayerPosition = new(0.0f, 1.0f, -20.0f);

        public static readonly List<(int Blue, int Red)> EnemiesCount = new()
        {
            { (5, 3 ) },
            { (15, 15) }
        };
    }
}
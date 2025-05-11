using System.Collections.Generic;

namespace EisvilTest
{
    public static class ChallengeData
    {
        public static readonly List<(string Text, int Target)> Challenges = new()
        {
            { ("Играть 20 секунд", 20 ) },
            { ("Убить 12 врагов", 12) },
            { ("Убить 8 красных врагов", 8) }
        };
    }
}
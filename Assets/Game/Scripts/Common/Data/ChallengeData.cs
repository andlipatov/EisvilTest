using System.Collections.Generic;

namespace EisvilTest
{
    public static class ChallengeData
    {
        public static readonly List<(string Text, int Target)> Challenges = new()
        {
            { ("������ 20 ������", 20 ) },
            { ("����� 12 ������", 12) },
            { ("����� 8 ������� ������", 8) }
        };
    }
}
namespace EisvilTest
{
    public readonly struct Bound
    {
        public readonly float HalfWidth;
        public readonly float HalfLength;

        public Bound(float width, float length)
        {
            HalfWidth = width * 0.5f;
            HalfLength = length * 0.5f;
        }
    }
}
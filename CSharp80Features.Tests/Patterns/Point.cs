namespace CSharp80Features.Tests.Patterns
{
    public readonly struct Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }

        public int Y { get; }

        public void Deconstruct(out int x, out int y)
        {
            (x, y) = (X, Y);
        }
    }
}

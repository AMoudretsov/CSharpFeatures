namespace CSharp80Features.Tests.Patterns
{
    public struct Vector
    {
        public Vector(Point start, Point end)
        {
            Start = start;
            End = end;
        }

        public Point Start { get; }

        public Point End { get; }
    }
}

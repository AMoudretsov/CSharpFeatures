namespace CSharp90Features.Tests.InitOnlySetters
{
    public class Point
    {
        public Point()
        {
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int? X { get; init; }

        public int? Y { get; init; }
    }
}

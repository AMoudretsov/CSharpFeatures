namespace CSharp90Features.Tests.InitOnlySetters
{
    public class EquidistantPoint : Point
    {
        private readonly int _distance;

        public EquidistantPoint()
        {
            Distance = 0;
        }

        public EquidistantPoint(int distance)
        {
            Distance = distance;
        }

        public int Distance
        {
            get
            {
                return _distance;
            }
            init
            {
                _distance = value;
                X = value;
                Y = value;
            }
        }
    }
}

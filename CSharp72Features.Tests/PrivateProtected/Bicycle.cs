namespace CSharp72Features.Tests.PrivateProtected
{
    public class Bicycle : Vehicle
    {
        public Bicycle() : base(2)
        {
        }

        public int HowManyWheels() => _wheels;
    }
}

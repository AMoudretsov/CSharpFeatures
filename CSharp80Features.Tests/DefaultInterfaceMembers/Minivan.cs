namespace CSharp80Features.Tests.DefaultInterfaceMembers
{
    public class Minivan : ICar
    {
        public bool IsElectric => false;

        public int NumberOfWheels => 4;

        public int MaxSpeed => 200;
    }
}

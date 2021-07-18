namespace CSharp80Features.Tests.DefaultInterfaceMembers
{
    public class Bicycle : IVehicle
    {
        public int NumberOfWheels => 2;

        public int MaxSpeed => 30;

        public string Description() => "Eco vehicle";
    }
}

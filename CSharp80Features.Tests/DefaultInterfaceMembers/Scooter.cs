namespace CSharp80Features.Tests.DefaultInterfaceMembers
{
    public class Scooter : IVehicle
    {
        public int NumberOfWheels => 2;

        public int MaxSpeed => 50;

        public string Model => $"{IVehicle.GetVehicleType(this)} Model #1";
    }
}

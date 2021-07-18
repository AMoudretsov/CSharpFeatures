namespace CSharp80Features.Tests.DefaultInterfaceMembers
{
    public interface IVehicle
    {
        int NumberOfWheels { get; }

        int MaxSpeed { get; }

        string Description() => $"{GetVehicleType(this)} {NumberOfWheels} {MaxSpeed}";

        static string GetVehicleType(IVehicle vehicle)
        {
            return vehicle.GetType().Name;
        }
    }
}

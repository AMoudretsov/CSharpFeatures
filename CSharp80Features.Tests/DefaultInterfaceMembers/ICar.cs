namespace CSharp80Features.Tests.DefaultInterfaceMembers
{
    public interface ICar : IVehicle
    {
        bool IsElectric { get; }

        new string Description() => IsElectric ? $"Electric engine {MaxSpeed}" : $"Fuel engine {MaxSpeed}";
    }
}

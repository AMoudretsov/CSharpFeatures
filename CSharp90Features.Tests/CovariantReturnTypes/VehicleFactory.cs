namespace CSharp90Features.Tests.CovariantReturnTypes
{
    public class VehicleFactory
    {
        public virtual Vehicle GetVehicle() => new Vehicle();
    }
}

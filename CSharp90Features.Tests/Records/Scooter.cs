namespace CSharp90Features.Tests.Records
{
    public record Scooter(int Wheels, int Speed, string Model) : Vehicle(Wheels, Speed);
}

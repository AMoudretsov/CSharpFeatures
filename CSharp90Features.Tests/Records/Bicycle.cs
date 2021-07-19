namespace CSharp90Features.Tests.Records
{
    public record Bicycle(int Wheels, int Speed, string Model) : Vehicle(Wheels, Speed);
}

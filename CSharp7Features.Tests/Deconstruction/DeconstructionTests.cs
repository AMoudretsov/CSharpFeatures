using Xunit;

namespace CSharp7Features.Tests.Deconstruction
{
    public class DeconstructionTests
    {
        [Fact]
        public void TupleCanBeDeconstructedIntoIndividualVariables()
        {
            var cases = ("test string", "Test String", "TEST STRING");

            var (lower, original, upper) = cases;

            Assert.Equal("test string", lower);
            Assert.Equal("Test String", original);
            Assert.Equal("TEST STRING", upper);
        }

        [Fact]
        public void UnnecessaryFieldsCanBeExcludedFromDeconstructionUsingDiscards()
        {
            var cases = ("test string", "Test String", "TEST STRING");

            var (_, _, upper) = cases;

            Assert.Equal("TEST STRING", upper);
        }

        [Fact]
        public void ClassesExposingDeconstructMethodCanBeDeconstructed()
        {
            var user = new User
            {
                UserName = "TestUser",
                FirstName = "TestFirstName",
                LastName = "TestLastName",
                PhoneNumber = "0 (123) 456-78-90",
                Email = "TestEmail@mock.test"
            };

            var (userName, firstName, lastName) = user;

            Assert.Equal("TestUser", userName);
            Assert.Equal("TestFirstName", firstName);
            Assert.Equal("TestLastName", lastName);

            var (_, _, _, phoneNumber, email) = user;

            Assert.Equal("0 (123) 456-78-90", phoneNumber);
            Assert.Equal("TestEmail@mock.test", email);
        }
    }
}

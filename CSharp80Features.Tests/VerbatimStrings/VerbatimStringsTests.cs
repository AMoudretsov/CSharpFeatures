using Xunit;

namespace CSharp80Features.Tests.VerbatimStrings
{
    public class VerbatimStringsTests
    {
        [Fact]
        public void AnyOrderOfAtSignAndDollarSignCanBeUsed()
        {
            var projectNo = 1;
            var atSignFollowsDollarSign = $@"C:\Src\Project{projectNo}";
            var dollarSignFollowsAtSign = @$"C:\Src\Project{projectNo}";

            Assert.Equal("C:\\Src\\Project1", atSignFollowsDollarSign);
            Assert.Equal("C:\\Src\\Project1", dollarSignFollowsAtSign);
        }
    }
}

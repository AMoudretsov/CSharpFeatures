using Xunit;

namespace CSharp90Features.Tests.LambdaDiscardParameters
{
    public class LambdaDiscardParametersTests
    {
        [Fact]
        public void LambdaArgsCanBeReplacedWithDiscardsIfNotUsedInTheBody()
        {
            var counter = 0;

            var button = new Button();
            button.Click += (_, _) => { counter++; };

            button.InitiateClick();
            button.InitiateClick();
            button.InitiateClick();

            Assert.Equal(3, counter);
        }
    }
}

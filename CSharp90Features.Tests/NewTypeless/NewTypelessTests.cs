using System;
using Xunit;

namespace CSharp90Features.Tests.NewTypeless
{
    public class NewTypelessTests
    {
        [Fact]
        public void TypeCanBeOmittedInPropertyInitializer()
        {
            var schedule = new Schedule
            {
                Start = new(2021, 2, 15)
            };

            Assert.Equal(new DateTime(2021, 2, 15), schedule.Start);
        }


        [Fact]
        public void TypeCanBeOmittedInVariableInitialization()
        {
            DateTime value = new(2021, 2, 15);

            Assert.Equal(new DateTime(2021, 2, 15), value);
        }

        [Fact]
        public void TypeCanBeOmittedPassingMethodArgs()
        {
            bool IsFirstQuarter(DateTime value) => 1 <= value.Month && value.Month <= 3;

            Assert.True(IsFirstQuarter(new(2021, 2, 15)));
            Assert.False(IsFirstQuarter(new(2021, 5, 15)));
        }

        [Fact]
        public void TypeCanBeOmittedInReturnStatement()
        {
            DateTime Clone(DateTime value) => new(value.Ticks);

            Assert.Equal(
                new DateTime(2021, 2, 15),
                Clone(new(2021, 2, 15)));
        }
    }
}

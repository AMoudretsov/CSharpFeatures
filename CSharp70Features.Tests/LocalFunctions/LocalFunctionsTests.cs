using System;
using System.Linq;
using Xunit;

namespace CSharp70Features.Tests.LocalFunctions
{
    public class LocalFunctionsTests
    {
        [Fact]
        public void UseLocalFunctionToIncludeComplexLogicAndSymplifyRestOfCode()
        {
            var dates = new[]
            {
                new DateTime(2021, 1, 3),
                new DateTime(2021, 2, 1),
                new DateTime(2021, 3, 5),
                new DateTime(2021, 4, 12),
                new DateTime(2021, 5, 3),
                new DateTime(2021, 6, 16)
            };

            var actual = dates.Where(isFirstMondayOfMonth);

            Assert.Equal(
                new[]
                {
                    new DateTime(2021, 2, 1),
                    new DateTime(2021, 5, 3)
                },
                actual);

            bool isFirstMondayOfMonth(DateTime date)
            {
                return date.DayOfWeek == DayOfWeek.Monday
                    && date.AddDays(-7).Month != date.Month;

            }
        }

        [Fact]
        public void LocalFunctionHasAccessToLocalVariablesOfOuterFunction()
        {
            var month = 5;

            var dates = new[]
            {
                new DateTime(2021, 1, 3),
                new DateTime(2021, 2, 1),
                new DateTime(2021, 3, 5),
                new DateTime(2021, 4, 12),
                new DateTime(2021, 5, 3),
                new DateTime(2021, 6, 16)
            };

            var actual = dates.Where(isFirstMondayOfMonth);

            Assert.Equal(
                new[]
                {
                    new DateTime(2021, 5, 3)
                },
                actual);

            bool isFirstMondayOfMonth(DateTime date)
            {
                return date.DayOfWeek == DayOfWeek.Monday
                    && date.Month == month
                    && date.AddDays(-7).Month != month;

            }
        }
    }
}

using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Xunit;

namespace CSharp80Features.Tests.Patterns
{
    public class PatternsTests
    {
        [Fact]
        public void PatternMatchingCanBeUsedInSwitchExpressions()
        {
            Assert.Equal(CoreControlType.Link, ConvertToCoreControlType(WebControlType.A));
            Assert.Equal(CoreControlType.Label, ConvertToCoreControlType(WebControlType.Span));
            Assert.Throws<ArgumentException>(() => ConvertToCoreControlType(WebControlType.Select));
        }

        [Fact]
        public void NonExhaustiveSwitchExpressionThrowsExceptionIfNoMatchFound()
        {
            Assert.Throws<SwitchExpressionException>(() => ConvertToCoreControlTypeNoDefault(WebControlType.Select));
        }

        [Fact]
        public void CaseGuardCanBeUsedForMoreAccurateMatching()
        {
            Assert.Equal(WebControlType.Span, ConvertToWebControlType(CoreControlType.Label, true));
        }

        [Fact]
        public void PropertyPatternWithValueConditions()
        {
            Assert.Equal(SizeCategory.Medium, GetSizeCategory("0123456789"));
            Assert.Equal(SizeCategory.Big, GetSizeCategory(new int[101]));
            Assert.Throws<ArgumentNullException>(() => GetSizeCategory(null));
            Assert.Throws<ArgumentException>(() => GetSizeCategory(new object()));
        }

        [Fact]
        public void PropertyPatternCanIncludeNestedPatterns()
        {
            var zeroVector = new Vector(
                new Point(0, 0),
                new Point(0, 0));

            var nonZeroVector = new Vector(
                new Point(0, 0),
                new Point(1, 1));

            Assert.True(IsZeroVector(zeroVector));
            Assert.False(IsZeroVector(nonZeroVector));
        }

        [Fact]
        public void TuplePatternCanBeUsedToMatchCombinationOfMultipleValues()
        {
            Assert.Equal("Orange", MixColors("Red", "Yellow"));
        }

        [Fact]
        public void PositionalPatternCanBeUsedToInspectProperties()
        {
            Assert.Equal("II", GetQuadrant(new Point(-1, 1)));
        }

        private CoreControlType ConvertToCoreControlType(WebControlType webControlType) =>
            webControlType switch
            {
                WebControlType.InputText => CoreControlType.TextBox,
                WebControlType.InputCheckBox => CoreControlType.CheckBox,
                WebControlType.InputRadio => CoreControlType.RadioButton,
                WebControlType.Button => CoreControlType.Button,
                WebControlType.Img => CoreControlType.Image,
                WebControlType.A => CoreControlType.Link,
                WebControlType.Label => CoreControlType.Label,
                WebControlType.Span => CoreControlType.Label,
                WebControlType.Div => CoreControlType.Label,
                _ => throw new ArgumentException(nameof(webControlType))
            };

#pragma warning disable CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).
        private CoreControlType ConvertToCoreControlTypeNoDefault(WebControlType webControlType) =>
            webControlType switch
            {
                WebControlType.InputText => CoreControlType.TextBox,
                WebControlType.InputCheckBox => CoreControlType.CheckBox,
                WebControlType.InputRadio => CoreControlType.RadioButton,
                WebControlType.Button => CoreControlType.Button,
                WebControlType.Img => CoreControlType.Image,
                WebControlType.A => CoreControlType.Link,
                WebControlType.Label => CoreControlType.Label,
                WebControlType.Span => CoreControlType.Label,
                WebControlType.Div => CoreControlType.Label,
            };
#pragma warning restore CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).

        private WebControlType ConvertToWebControlType(CoreControlType coreControlType, bool inline = false) =>
            coreControlType switch
            {
                CoreControlType.TextBox => WebControlType.InputText,
                CoreControlType.CheckBox => WebControlType.InputCheckBox,
                CoreControlType.RadioButton => WebControlType.InputRadio,
                CoreControlType.Button => WebControlType.Button,
                CoreControlType.Image => WebControlType.Img,
                CoreControlType.Link => WebControlType.A,
                CoreControlType.Label when inline => WebControlType.Span,
                CoreControlType.Label when !inline => WebControlType.Div,
                _ => throw new ArgumentException(nameof(coreControlType))
            };

        private SizeCategory GetSizeCategory(object input) =>
            input switch
            {
                string { Length: < 10 } => SizeCategory.Small,
                string { Length: < 100 } => SizeCategory.Medium,
                string { Length: >= 100 } => SizeCategory.Big,
                ICollection { Count: < 10 } => SizeCategory.Small,
                ICollection { Count: < 100 } => SizeCategory.Medium,
                ICollection { Count: >= 100 } => SizeCategory.Big,
                null => throw new ArgumentNullException(nameof(input)),
                _ => throw new ArgumentException("Unknown type of argument.", nameof(input))
            };

        private bool IsZeroVector(Vector vector) => vector is { Start: { X: 0, Y: 0 }, End: { X: 0, Y: 0 } };

        private string MixColors(string color1, string color2)
        {
            return (color1, color2) switch
            {
                ("Yellow", "Blue") => "Green",
                ("Red", "Yellow") => "Orange",
                ("Blue", "Red") => "Purple",
                _ => throw new InvalidOperationException($"Unknown combination of colors: {color1} and {color2}.")
            };
        }

        private string GetQuadrant(Point point) =>
            point switch
            {
                var (x, y) when x > 0 && y > 0 => "I",
                var (x, y) when x < 0 && y > 0 => "II",
                var (x, y) when x < 0 && y < 0 => "III",
                var (x, y) when x > 0 && y < 0 => "IV",
                _ => throw new ArgumentException("Cannot determine quadrant.", nameof(point))
            };
    }
}

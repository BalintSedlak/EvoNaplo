using EvoNaplo.Common.GuardClauses;
using NUnit.Framework;

namespace EvoNaplo.Common.UnitTest
{
    public class GuardAgainstExpressionTests
    {
        [Test]
        [TestCaseSource(nameof(MatchingIntInputs))]
        public void GuardAgainstExpression_MatchingIntInput_DoesNothing(int actual, int expected)
        {
            Guard.Against.AgainstExpression((x) => x == expected, actual, $"Value is not equal to {expected}");
        }

        [Test]
        [TestCaseSource(nameof(NotMatchingIntInputs))]
        public void GuardAgainstExpression_NotMatchingIntInputs_ThrowsArgumentException(int actual, int expected)
        {
            Assert.Throws<ArgumentException>(() => Guard.Against.AgainstExpression((x) => x == expected, actual, $"Value is not equal to {expected}"));
        }

        [Test]
        [TestCaseSource(nameof(MatchingDoubleInputs))]
        public void GuardAgainstExpression_MatchingDoubleInput_DoesNothing(double actual, double expected)
        {
            Guard.Against.AgainstExpression((x) => x == expected, actual, $"Value is not equal to {expected}");
        }

        [Test]
        [TestCaseSource(nameof(NotMatchingDoubleInputs))]
        public void GuardAgainstExpression_NotMatchingDoubleInput_DoesNothing(double actual, double expected)
        {
            Assert.Throws<ArgumentException>(() => Guard.Against.AgainstExpression((x) => x == expected, actual, $"Value is not equal to {expected}"));
        }

        [Test]
        [TestCaseSource(nameof(GetCustomStruct))]
        public void GuardAgainstExpression_CustomStructsFieldIsMatching_DoesNothing(CustomStruct test)
        {
            Guard.Against.AgainstExpression((x) => x.FieldName == "FieldValue", test, "FieldValue is not matching");
        }

        [Test]
        [TestCaseSource(nameof(GetCustomStruct))]
        public void GuardAgainstExpression_CustomStructsFieldIsNotMatching_ThrowsArgumentException(CustomStruct test)
        {
            Assert.Throws<ArgumentException>(() => Guard.Against.AgainstExpression((x) => x.FieldName == "FailThis", test, "FieldValue is not matching"));
        }

        public struct CustomStruct
        {
            public string FieldName { get; set; }
        }

        private static IEnumerable<object[]> GetCustomStruct()
        {
            yield return new object[] {
                new CustomStruct
                {
                    FieldName = "FieldValue"
                }
            };
        }

        public static IEnumerable<object[]> MatchingIntInputs()
        {
            yield return new object[] { 10, 10 };
            yield return new object[] { -1, -1 };
            yield return new object[] { 0, 0 };
            yield return new object[] { int.MinValue, int.MinValue };
            yield return new object[] { int.MaxValue, int.MaxValue };
        }

        public static IEnumerable<object[]> NotMatchingIntInputs()
        {
            yield return new object[] { 10, 11 };
            yield return new object[] { -1, 1 };
            yield return new object[] { 0, 2 };
            yield return new object[] { 0, -1 };
            yield return new object[] { int.MinValue, int.MaxValue };
        }

        public static IEnumerable<object[]> MatchingDoubleInputs()
        {
            yield return new object[] { 10.0, 10.0 };
            yield return new object[] { -1.0, -1.0 };
            yield return new object[] { 0.0, 0.0 };
            yield return new object[] { double.MinValue, double.MinValue };
            yield return new object[] { double.MaxValue, double.MaxValue };
        }

        public static IEnumerable<object[]> NotMatchingDoubleInputs()
        {
            yield return new object[] { 10.0, 11.0 };
            yield return new object[] { -1f, 1f };
            yield return new object[] { 0.0, 0.1 };
            yield return new object[] { 0.0, -0.1 };
            yield return new object[] { double.MinValue, double.MaxValue };
        }
    }
}

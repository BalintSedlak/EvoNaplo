using EvoNaplo.Common.GuardClauses;
using NUnit.Framework;

namespace EvoNaplo.Common.UnitTest
{
    public class GuardAgainstDefaultTests
    {
        [Test]
        public void GuardAgainstDefault_NonDefaultValue_DoesNothing()
        {
            Guard.Against.Default("", "string");
            Guard.Against.Default(1, "int");
            Guard.Against.Default(Guid.NewGuid(), "guid");
            Guard.Against.Default(DateTime.Now, "datetime");
            Guard.Against.Default(new object(), "object");
        }

        [Test]
        public void GuardAgainstDefault_DefaultValue_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Guard.Against.Default(default(string), "string"), "string");
            Assert.Throws<ArgumentException>(() => Guard.Against.Default(default(int), "int"), "int");
            Assert.Throws<ArgumentException>(() => Guard.Against.Default(default(Guid), "guid"), "guid");
            Assert.Throws<ArgumentException>(() => Guard.Against.Default(default(DateTime), "datetime"), "datetime");
            Assert.Throws<ArgumentException>(() => Guard.Against.Default(default(object), "object"), "object");
        }

        [Test]
        [TestCaseSource(nameof(GetNonDefaultTestVectors))]
        public void GuardAgainstDefault_NonDefaultValue_ReturnsExpectedValue(object input, string name, object expected)
        {
            var actual = Guard.Against.Default(input, name);
            Assert.AreEqual(expected, actual);
        }

        public static IEnumerable<object[]> GetNonDefaultTestVectors()
        {
            yield return new object[] { "", "string", "" };
            yield return new object[] { 1, "int", 1 };

            var guid = Guid.NewGuid();
            yield return new object[] { guid, "guid", guid };

            var now = DateTime.Now;
            yield return new object[] { now, "now", now };

            var obj = new object();
            yield return new object[] { obj, "obj", obj };
        }
    }
}

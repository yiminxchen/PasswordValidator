using NUnit.Framework;
using PasswordValidator;

namespace PasswordValidator.Test
{
    [TestFixture]
    class PatternCharRuleTest
    {
        [TestCase("abaedf34")]
        [TestCase("abcbedf34")]
        public void Password_Has_Pattern_Char(string password)
        {

            IPasswordRuleChecker patternCharChecker = new PatternCharRuleChecker();

            ValidationStatus status = patternCharChecker.CheckRule(password);

            Assert.AreEqual(status, ValidationStatus.Fail);
        }

        [TestCase("aabbchg")]
        [TestCase("a")]
        [TestCase("ab")]
        [TestCase("abc")]
        public void Password_Has_NO_Pattern_Char(string password)
        {

            IPasswordRuleChecker patternCharChecker = new PatternCharRuleChecker();

            ValidationStatus status = patternCharChecker.CheckRule(password);

            Assert.AreEqual(status, ValidationStatus.Pass);
        }
    }
}

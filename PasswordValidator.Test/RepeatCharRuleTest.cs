using System;
using NUnit.Framework;
using PasswordValidator;

namespace PasswordValidator.Test
{
    [TestFixture]
    public class RepeatCharRuleTest
    {
        [TestCase("aaabcde", 3)]
        [TestCase("abcdd", 2)]
        [TestCase("aabccccdd", 3)]
        [TestCase("a111342w", 3)]
        [TestCase("aaA2344B!!!Eeds", 3)]
        public void Password_Has_Repeat_Char(string password, int repeatCount)
        {

            IPasswordRuleChecker repeatCharChecker = new RepeatCharRuleChecker(repeatCount);

            ValidationStatus status = repeatCharChecker.CheckRule(password);

            Assert.AreEqual(status, ValidationStatus.Fail);
        }

        [TestCase("aabcde", 3)]
        [TestCase("2323Asdc", 2)]
        [TestCase("aa33223Def", 3)]
        [TestCase("aaA2344B!@we", 3)]
        public void Password_Has_NO_Repeat_Char(string password, int repeatCount)
        {

            IPasswordRuleChecker repeatCharChecker = new RepeatCharRuleChecker(repeatCount);

            ValidationStatus status = repeatCharChecker.CheckRule(password);

            Assert.AreEqual(status, ValidationStatus.Pass);
        }
    }
}

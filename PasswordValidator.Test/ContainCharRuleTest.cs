using System;
using NUnit.Framework;
using PasswordValidator;

namespace PasswordValidator.Test
{
    [TestFixture]
    public class ContainCharRuleTest
    {
        [TestCase("j23ayht", "aeiou")]
        [TestCase("j23Ayht", "aeiouAEIOU")]
        [TestCase("j2i3Ayht", "aeiouAEIOU")]
        [TestCase("j2i3Ayht@", "@!#$")]
        public void Password_Has_char(string password, string vowels)
        {
            IPasswordRuleChecker containCharRuleChecker = new ContainCharRuleChecker(vowels);

            ValidationStatus status = containCharRuleChecker.CheckRule(password);

            Assert.AreEqual(status, ValidationStatus.Fail);
        }

        [TestCase("j23yht", "aeiou")]
        [TestCase("j23yht", "aeiouAEIOU")]
        [TestCase("j23yht", "aeiouAEIOU")]
        [TestCase("j2i3Ayht", "@!#$")]
        public void Password_Has_NO_char(string password, string vowels)
        {
            IPasswordRuleChecker containCharRuleChecker = new ContainCharRuleChecker(vowels);

            ValidationStatus status = containCharRuleChecker.CheckRule(password);

            Assert.AreEqual(status, ValidationStatus.Pass);
        }
    }
}

using System;
using NUnit.Framework;
using PasswordValidator;


namespace PasswordValidator.Test
{
    [TestFixture]
    class PasswordPolicyTest
    {
        [TestCase("bgh76T@1", 3, "aeiouAEIOU")]
        public void Password_Comply_To_Strict_Policy(string password, int repeatCount, string vowels)
        {

            IPasswordPolicy strictPolicy = new StrictPasswordPolicy { RepeatCount = repeatCount, Vowels = vowels };

            ValidationStatus status = strictPolicy.Validate(password);

            Assert.AreEqual(status, ValidationStatus.Pass);
        }

        [TestCase("bgah76T@1", 3, "aeiouAEIOU")]
        [TestCase("bgh76T@1@", 3, "aeiouAEIOU")]
        [TestCase("bgh76T@1@", 3, "aeiouAEIOU")]
        public void Password_Do_Not_Comply_To_Strict_Policy(string password, int repeatCount, string vowels)
        {

            IPasswordPolicy strictPolicy = new StrictPasswordPolicy { RepeatCount = repeatCount, Vowels = vowels };

            ValidationStatus status = strictPolicy.Validate(password);

            Assert.AreEqual(status, ValidationStatus.Fail);
        }

        [TestCase("bgh7A6T@1@", 3, "aeiouAEIOU")]
        [TestCase("bAgh7A6T@1", 2, "aeiouAEIOU")]
        public void Password_Comply_To_Minimum_Policy(string password, int repeatCount, string vowels)
        {

            IPasswordPolicy minimumPolicy = new MinimumPasswordPolicy { RepeatCount = repeatCount, Vowels = vowels };

            ValidationStatus status = minimumPolicy.Validate(password);

            Assert.AreEqual(status, ValidationStatus.Pass);
        }

        [TestCase("bghhh76T@1@", 3, "aeiouAEIOU")]
        [TestCase("bgh76T@@@1@", 3, "aeiouAEIOU")]
        public void Password_Do_Not_Comply_To_Minimum_Policy(string password, int repeatCount, string vowels)
        {

            IPasswordPolicy minimumPolicy = new MinimumPasswordPolicy { RepeatCount = repeatCount, Vowels = vowels };

            ValidationStatus status = minimumPolicy.Validate(password);

            Assert.AreEqual(status, ValidationStatus.Fail);
        }
    }
}

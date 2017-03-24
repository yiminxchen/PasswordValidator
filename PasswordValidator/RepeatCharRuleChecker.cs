using System;

namespace PasswordValidator
{
    /// <summary>
    /// Implementation of password rule for repeat char
    /// </summary>
    public class RepeatCharRuleChecker : IPasswordRuleChecker
    {
        private IPasswordRuleChecker _nextRule;
        private readonly int _numberOfRepeatChar;
        
        public RepeatCharRuleChecker(int numberOfRepeatChar)
        {
            _numberOfRepeatChar = (numberOfRepeatChar < 0) ? 0 : numberOfRepeatChar;
        }
        public ValidationStatus CheckRule(string password)
        {
            if (HasRepeatChar(password))
            {
                return ValidationStatus.Fail;
            }
            // check next rule
            if (_nextRule != null)
            {
                return _nextRule.CheckRule(password);
            }

            return ValidationStatus.Pass;
        }

        public void RegisterNextRule(IPasswordRuleChecker nextRule)
        {
            _nextRule = nextRule;
        }

        /// <summary>
        /// Check consecutive repeat char in given string. Note: This only works for regular Unicode char
        /// </summary>
        /// <param name="password"></param>
        /// <returns>true if has consecutive repeat char, otherwise false</returns>
        private bool HasRepeatChar(string password)
        {

            if (String.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException();
            }

            if (password.Length < _numberOfRepeatChar)
            {
                throw new ArgumentOutOfRangeException();
            }

            char charToCheck = password[0];
            int repeatCount = 0;

            foreach (char c in password)
            {
                if (c == charToCheck)
                {
                    repeatCount++;
                }
                else
                {
                    repeatCount = 1;
                }

                if (repeatCount >= _numberOfRepeatChar)
                    return true;

                charToCheck = c;
            }

            return false;
        }
    }
}
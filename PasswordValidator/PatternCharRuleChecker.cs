using System;

namespace PasswordValidator
{
    /// <summary>
    /// Implementation of password rule for containing specific pattern
    /// </summary>
    public class PatternCharRuleChecker : IPasswordRuleChecker
    {
        private IPasswordRuleChecker _nextRule;

        public ValidationStatus CheckRule(string password)
        {
            if (HasPatternChar(password))
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
        /// Check pattern that for a 3 char pattern, the first and last char is the same and the middle char is different
        /// Note: This only works for regular Unicode char
        /// </summary>
        /// <param name="password"></param>
        /// <returns>true if has the pattern, otherwise false</returns>
        private bool HasPatternChar(string password)
        {

            if (String.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException();
            }

            if (password.Length < 3)
                return false;

            for (int i = 0; i < password.Length - 1; i++)
            {
                if ((i + 2) >= password.Length)
                {
                    break;
                }
            
                if ((password[i] == password[i+2]) && (password[i] != password[i+1]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
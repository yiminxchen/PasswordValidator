using System;
using System.Linq;

namespace PasswordValidator
{
    /// <summary>
    /// Implementation of password rule for containing specific chars
    /// </summary>
    public class ContainCharRuleChecker : IPasswordRuleChecker
    {
        private IPasswordRuleChecker _nextRule;
        private readonly string _containChar;

        public ContainCharRuleChecker(string containChar)
        {
            _containChar = containChar;
        }

        public ValidationStatus CheckRule(string password)
        {
            if (String.IsNullOrEmpty(password) || String.IsNullOrEmpty(_containChar))
            {
                throw new ArgumentNullException();
            }

            if (password.Intersect(_containChar).Any())
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
    }
}
namespace PasswordValidator
{
    /// <summary>
    /// Implementation of strict password polcy, all three rules needs to be checked
    /// </summary>
    public class StrictPasswordPolicy : IPasswordPolicy
    {
        public int RepeatCount { get; set; }
        public string Vowels { get; set; } 
        public ValidationStatus Validate(string password)
        {
            IPasswordRuleChecker repeatCharChecker = new RepeatCharRuleChecker(RepeatCount);
            IPasswordRuleChecker containCharRuleChecker = new ContainCharRuleChecker(Vowels);
            IPasswordRuleChecker patternCharChecker = new PatternCharRuleChecker();

            // chain rules
            repeatCharChecker.RegisterNextRule(containCharRuleChecker);
            containCharRuleChecker.RegisterNextRule(patternCharChecker);

            return repeatCharChecker.CheckRule(password);
        }
    }
}
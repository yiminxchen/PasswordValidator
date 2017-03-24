namespace PasswordValidator
{
    public class MinimumPasswordPolicy : IPasswordPolicy
    {
        public int RepeatCount { get; set; }
        public string Vowels { get; set; }
        public ValidationStatus Validate(string password)
        {
            IPasswordRuleChecker repeatCharChecker = new RepeatCharRuleChecker(RepeatCount);

            return repeatCharChecker.CheckRule(password);
        }
    }
}
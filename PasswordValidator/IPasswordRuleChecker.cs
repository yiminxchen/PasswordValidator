namespace PasswordValidator
{
    public interface IPasswordRuleChecker
    {
        ValidationStatus CheckRule(string password);
        void RegisterNextRule(IPasswordRuleChecker nextRule);
    }
}
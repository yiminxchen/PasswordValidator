namespace PasswordValidator
{
    public interface IPasswordPolicy
    {
        ValidationStatus Validate(string password);
    }
}
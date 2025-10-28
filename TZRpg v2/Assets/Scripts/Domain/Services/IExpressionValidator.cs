namespace Domain.Services
{
    public interface IExpressionValidator
    {
        bool TryValidate(string input);
    }
}
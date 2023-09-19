namespace Application.InterfaceServices
{
    public interface IPasswordResetAttemptService
    {
        Task AddAttemptAsync(string userId);
        Task<bool> HasAttempts(string userId);
        Task RefreshAttempts(string userId);
    }
}
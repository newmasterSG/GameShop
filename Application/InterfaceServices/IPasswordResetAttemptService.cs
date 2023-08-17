namespace Application.InterfaceServices
{
    public interface IPasswordResetAttemptService
    {
        Task AddAttemptAsync(string userId);
        Task<bool> IsBlockedAsync(string userId);
        Task UnblockUserAsync(string userId);
    }
}
using Application.InterfaceServices;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PasswordResetAttemptService : IPasswordResetAttemptService
    {
        private readonly IDistributedCache _cache;
        public PasswordResetAttemptService(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task AddAttemptAsync(string userId)
        {
            var attemptsKey = $"PasswordResetAttempts_{userId}";
            var attemptsBytes = await _cache.GetAsync(attemptsKey);

            int attempts = attemptsBytes != null ? int.Parse(Encoding.UTF8.GetString(attemptsBytes)) : 0;
            attempts++;

            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1)
            };

            await _cache.SetStringAsync(attemptsKey, attempts.ToString(), options);
        }

        public async Task<bool> IsBlockedAsync(string userId)
        {
            var attemptsKey = $"PasswordResetAttempts_{userId}";
            var attemptsBytes = await _cache.GetAsync(attemptsKey);

            if (attemptsBytes != null)
            {
                int attempts = int.Parse(Encoding.UTF8.GetString(attemptsBytes));
                return attempts >= 2;
            }

            return false;
        }

        public async Task UnblockUserAsync(string userId)
        {
            var attemptsKey = $"PasswordResetAttempts_{userId}";
            await _cache.RemoveAsync(attemptsKey);
        }
    }
}

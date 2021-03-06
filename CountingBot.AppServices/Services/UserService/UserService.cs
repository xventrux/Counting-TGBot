using CountingBot.Domain.Entities;
using CountingBot.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace CountingBot.AppServices.Services.UserService
{
    /// <inheritdoc/>
    public class UserService : IUserService
    {
        IRepository<User> userRepository;
        ITelegramBotClient telegramBotClient;

        public UserService(IRepository<User> userRepository, ITelegramBotClient telegramBotClient)
        {
            this.userRepository = userRepository;
            this.telegramBotClient = telegramBotClient;
        }

        /// <inheritdoc/>
        public async Task<User> Login(long id)
        {
            User user = await userRepository.GetByIdAsync(id);
            if (user == null) return null;

            return user;
        }

        /// <inheritdoc/>
        public async Task<User> Registration(long id, string login)
        {
            User user = new User()
            {
                Id = id,
                UserName = login,
                Exp = 0,
                Level = 0,
                ProcessName = "",
                Step = 0

            };
            await userRepository.AddAsync(user);
            return user;
        }

        /// <inheritdoc/>
        public async Task Update(User user)
        {
            await userRepository.UpdateAsync(user);
        }

        /// <inheritdoc/>
        public async Task Delete(User user)
        {
            await userRepository.DeleteAsync(user);
        }
    }
}

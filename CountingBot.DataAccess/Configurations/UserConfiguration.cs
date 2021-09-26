using CountingBot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CountingBot.DataAccess.Configurations
{
    /// <summary>
    /// Конфигурация пользователя
    /// </summary>
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.ToTable(nameof(User));

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).ValueGeneratedNever();

        }
    }
}

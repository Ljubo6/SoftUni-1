namespace P03_FootballBetting.Data.Models.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BetConfiguration : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            builder.HasKey(b => b.BetId);

            builder.Property(b => b.Prediction).IsRequired().IsUnicode();

            builder.HasOne(b => b.User).WithMany(u => u.Bets).HasForeignKey(u => u.UserId);

            builder.HasOne(b => b.Game).WithMany(g => g.Bets).HasForeignKey(g => g.GameId);
        }
    }
}

namespace P03_FootballBetting.Data.Models.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(p => p.PlayerId);

            builder.HasOne(p => p.Team).WithMany(t => t.Players).HasForeignKey(p => p.TeamId);

            builder.HasOne(plr => plr.Position).WithMany(pos => pos.Players).HasForeignKey(plr => plr.PositionId);
        }
    }
}

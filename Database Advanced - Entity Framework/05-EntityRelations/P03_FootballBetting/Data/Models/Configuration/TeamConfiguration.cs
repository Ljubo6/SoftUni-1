namespace P03_FootballBetting.Data.Models.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(t => t.TeamId);

            builder.Property(t => t.Name).IsRequired();

            builder.Property(t => t.Initials).IsRequired();

            builder
                .HasOne(team => team.Town)
                .WithMany(town => town.Teams)
                .HasForeignKey(team => team.TownId);

            builder
                .HasOne(t => t.PrimaryKitColor)
                .WithMany(pkc => pkc.PrimaryKitTeams)
                .HasForeignKey(t => t.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne(t => t.SecondaryKitColor)
               .WithMany(skc => skc.SecondaryKitTeams)
               .HasForeignKey(t => t.SecondaryKitColorId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

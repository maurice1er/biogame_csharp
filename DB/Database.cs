using biochallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace biochallenge.DB;

public class Database : DbContext
{
	public Database(DbContextOptions<Database> options) : base(options) { }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		// modelBuilder.Entity<Option>(entity => entity.Property(x => x.Id).HasMaxLength(255));

		modelBuilder.Entity<Question>()
		.HasMany(q => q.Options)
		.WithOne(o => o.Question)
		.HasForeignKey(o => o.QuestionId);

		// modelBuilder.Entity<Question>(entity => entity.Property(x => x.Id).HasMaxLength(255));

		modelBuilder.Entity<Challenge>()
			.HasOne(c => c.Challenged)
			.WithMany()
			.HasForeignKey(c => c.ChallengedId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<Challenge>()
			.HasOne(c => c.Challenger)
			.WithMany()
			.HasForeignKey(c => c.ChallengerId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<Challenge>()
			.HasOne(c => c.Winner)
			.WithMany()
			.HasForeignKey(c => c.WinnerId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<Challenge>()
			.HasMany(c => c.Quiz)
			.WithOne()
			.OnDelete(DeleteBehavior.Cascade);
	}


	public DbSet<Participant> Participants { get; set; }

	public DbSet<Challenge> Challenges { get; set; }

	public DbSet<Question> Questions { get; set; }

	public DbSet<Option> Options { get; set; }
	
}

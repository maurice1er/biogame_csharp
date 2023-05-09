using biochallenge.Models;
// using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
// using Ubiety.Dns.Core;

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

		// Seed data
		var participant1 = new Participant { Id = Guid.NewGuid(), Score = 2.0 };
		var participant2 = new Participant { Id = Guid.NewGuid(), Score = 1.0 };
		modelBuilder.Entity<Participant>().HasData(participant1, participant2);

		var question1 = new Question { Quiz = "Quiz 1", Hint = "", Duration = 10 };
		var question2 = new Question { Quiz = "Quiz 2", Hint = "", Duration = 30 };
		var question3 = new Question { Quiz = "Quiz 3", Duration = 15 };
		modelBuilder.Entity<Question>().HasData(question1); //, question2, question3);

		var option1 = new Option { Answer = "Answer 1", IsCorrect = false, QuestionId = question1.Id };
		var option2 = new Option { Answer = "Answer 2", IsCorrect = false, QuestionId = question1.Id };
		var option3 = new Option { Answer = "Answer 3", IsCorrect = true, QuestionId = question1.Id };
		modelBuilder.Entity<Option>().HasData(option1, option2, option3);

		var challenge1 = new Challenge { ChallengedId = participant1.Id, ChallengerId = participant2.Id };
		modelBuilder.Entity<Challenge>().HasData(challenge1);
		/**/


		base.OnModelCreating(modelBuilder);
	}


	public DbSet<Participant> Participants { get; set; }

	public DbSet<Challenge> Challenges { get; set; }

	public DbSet<Question> Questions { get; set; }

	public DbSet<Option> Options { get; set; }
	
}

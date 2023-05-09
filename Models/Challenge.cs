using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace biochallenge.Models;

public class Challenge
{
	[Key]
	[Column(TypeName = "char(36)")]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public Guid Id { get; set; } = Guid.NewGuid();

	public bool IsStarted { get; set; } = false;
	public bool IsFinished { get; set; } = false;


	public Guid ChallengedId { get; set; }
	public virtual Participant Challenged { get; set; }
	public Guid ChallengerId { get; set; }
	public virtual Participant Challenger { get; set; }


	public Guid? WinnerId { get; set; }
	public virtual Participant? Winner { get; set; }
	
	public virtual ICollection<Question> Quiz { get; set; }

	public DateTime? LaunchedAt { get; set; }
	public DateTime? AcceptedAt { get; set; }
	public DateTime? EndAt { get; set; }
}

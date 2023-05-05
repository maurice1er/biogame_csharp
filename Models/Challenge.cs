namespace biochallenge.Models;

public class Challenge
{
	public Guid Id { get; set; } = Guid.NewGuid();

	public bool IsStarted { get; set; } = false;
	public bool IsFinished { get; set; } = false;

	public virtual Participant Challenged { get; set; }
	public virtual Participant Challenger { get; set; }
	public virtual Participant Winner { get; set; }
	
	public virtual ICollection<Quiz> Quiz { get; set; }

	public DateTime? LaunchedAt { get; set; } = null;
	public DateTime? AcceptedAt { get; set; } = null;
	public DateTime? EndAt { get; set; } = null;
}

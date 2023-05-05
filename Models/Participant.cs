namespace biochallenge.Models;

public class Participant
{
	public Guid Id { get; set; } = Guid.NewGuid();
	public double Score { get; set; } = 0.0;
}

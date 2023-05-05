namespace biochallenge.Models;

public class Options
{
	public Guid Id { get; set; } = Guid.NewGuid();
	public string Answer { get; set; }
	public bool IsCorrect { get; set; } = false;
	public virtual Quiz Quiz { get; set; }
}

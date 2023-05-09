using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace biochallenge.Models;

public class Question
{
	[Key]
	[Column(TypeName = "char(36)")]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public Guid Id { get; set; } = Guid.NewGuid();
	public string Quiz { get; set; }
	public string? Hint { get; set; }

	// public ICollection<string>? Images { get; set; }

	public int Duration { get; set; }

	public virtual ICollection<Option> Options { get; set; }

}


public class Image
{
	[Key]
	[Column(TypeName = "char(36)")]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public Guid Id { get; set; } = Guid.NewGuid();
	public string Path { get; set; }

	[ForeignKey("Question")]
	public Guid QuestionId { get; set; }
	public virtual Question Question { get; set; }
}
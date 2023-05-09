using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace biochallenge.Models;

public class Option
{
	[Key]
	[Column(TypeName = "char(36)")]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public Guid Id { get; set; } = Guid.NewGuid();
	public string Answer { get; set; }
	public bool IsCorrect { get; set; } = false;

	public Guid QuestionId { get; set; }
	public virtual Question Question { get; set; }

}

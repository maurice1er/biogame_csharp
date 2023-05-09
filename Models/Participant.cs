using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace biochallenge.Models;

public class Participant
{
	[Key]
	[Column(TypeName = "char(36)")]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public Guid Id { get; set; } = Guid.NewGuid();
	public double Score { get; set; } = 0.0;
}

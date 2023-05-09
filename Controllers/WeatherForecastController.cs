using biochallenge.Models;
using biochallenge.Repositories;
using biochallenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace biochallenge.Controllers;


[ApiController]
[Route("/api")]
public class WeatherForecastController : ControllerBase
{
	IChallengeRepository participantRepository;

	private static readonly string[] Summaries = new[]
	{
		"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
	};

	private readonly ILogger<WeatherForecastController> _logger;

	public WeatherForecastController(ILogger<WeatherForecastController> logger)
	{
		_logger = logger;
		participantRepository = new ChallengeService();

	}


	
	[HttpGet("/getgame")]
	public ActionResult<Participant> GetGame()
	{
		
		List<Option> options = new List<Option>
		{
			new Option { Answer = "Option 1", IsCorrect = false },
			new Option { Answer = "Option 2", IsCorrect = true },
			new Option { Answer = "Option 3", IsCorrect = false }
		};

		List<Question> quizList = new List<Question>();
		quizList.Add(new Question { Quiz = "Question1", Hint = "Hint1", Duration = 5 });
		quizList.Add(new Question { Quiz = "Question2", Hint = "Hint2", Duration = 10 });
		quizList.Add(new Question { Quiz = "Question3", Hint = "Hint3", Duration = 5 });

		Participant challenger = new Participant();
		Participant challenged = new Participant();

		Challenge ch = new Challenge
		{
			Challenger = challenger,
			Challenged = challenged,
			Quiz = quizList
		};
		

		return Ok(new { status = ch});
	}
	


	[HttpGet(Name = "GetWeatherForecast")]
	public IEnumerable<WeatherForecast> Get()
	{
			return Enumerable
			.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = Random.Shared.Next(-20, 55),
				Summary = Summaries[Random.Shared.Next(Summaries.Length)]
			})
			.ToArray();
	}
}




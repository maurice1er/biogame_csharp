using biochallenge.Models;
using biochallenge.Repositories;
using System.Net.Http;


namespace biochallenge.Services;

public class ChallengeService : IChallengeRepository
{
	private HttpClient client;

	public ChallengeService()
	{
		client = new HttpClient();
	}


	public async Task<Challenge> CreateChallenge(Participant challenger, Participant? challenged, List<Question> quizList)
	{
		client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
		HttpResponseMessage response = await client.GetAsync("todos/" + 1);

		Console.WriteLine(response.IsSuccessStatusCode);

		Challenge challenge = new Challenge
		{
			Challenger = challenger,
			Quiz = quizList,
			LaunchedAt = DateTime.Now
		};
		
		return challenge;
	}

	public bool AcceptChallenge(Challenge challenge, Participant participant)
	{
		if (challenge.AcceptedAt != null)
		{
			return false;
		}

		challenge.AcceptedAt = DateTime.Now;
		challenge.Challenged = participant;

		return true;
	}

}

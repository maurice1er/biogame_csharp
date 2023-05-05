using biochallenge.Models;
using biochallenge.Repositories;

namespace biochallenge.Services;

public class ChallengeService : IChallengeRepository
{
	public Challenge CreateChallenge(Participant challenger, Participant? challenged, List<Quiz> quizList)
	{
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

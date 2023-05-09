using biochallenge.Models;

namespace biochallenge.Repositories;

public interface IChallengeRepository
{
	Task<Challenge> CreateChallenge(Participant challenger, Participant challenged, List<Question> quizList);
	bool AcceptChallenge(Challenge challenge, Participant participant);
}

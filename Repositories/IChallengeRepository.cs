using biochallenge.Models;

namespace biochallenge.Repositories;

public interface IChallengeRepository
{
	Challenge CreateChallenge(Participant challenger, Participant challenged, List<Quiz> quizList);
	bool AcceptChallenge(Challenge challenge, Participant participant);
}

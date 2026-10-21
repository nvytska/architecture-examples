namespace Patterns;

using Helpers;

public interface IAiApi
{
    Task<string> GetAnswer(string prompt);
}

public class LoggingAiApiDecorator(
    IAiApi inner,
    ICurrentUserProvider currentUser,
    ILogger logger) : IAiApi
{

    public async Task<string> GetAnswer(string prompt)
    {
        logger.Log($"User {currentUser.GetCurrentUser()} asked: {prompt}");
        var answer = await inner.GetAnswer(prompt);
        return answer;
    }
}

public class EligibilityCheckerAiApiProxy(
    IAiApi inner,
    IAiEligibilityChecker eligibilityChecker,
    ICurrentUserProvider currentUser) : IAiApi
{

    public async Task<string> GetAnswer(string prompt)
    {
        if (!eligibilityChecker.IsEligible(await currentUser.GetCurrentUser()))
        {
            throw new Exception("User is not eligible"); 
        }
        var answer = await inner.GetAnswer(prompt);
        return answer;
    }
}
namespace Patterns.Helpers;

public interface ICurrentUserProvider
{
    Task<IUser> GetCurrentUser(); 
}

public interface IUser
{
    Guid Id { get; }
}

public interface IAiEligibilityChecker
{
    bool IsEligible(IUser user);
}
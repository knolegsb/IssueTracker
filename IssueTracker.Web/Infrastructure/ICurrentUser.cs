using IssueTracker.Web.Domain;

namespace IssueTracker.Web.Infrastructure
{
    public interface ICurrentUser
    {
        ApplicationUser User { get; }
    }
}

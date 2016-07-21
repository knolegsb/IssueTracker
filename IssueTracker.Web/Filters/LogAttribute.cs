using IssueTracker.Web.Data;
using IssueTracker.Web.Domain;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace IssueTracker.Web.Filters
{
    public class LogAttribute : ActionFilterAttribute
    {
        //private readonly ApplicationDbContext _context;
        public string Description { get; set; }

        public LogAttribute(string description/*, ApplicationDbContext context*/)
        {
            //_context = context;
            Description = description;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var userId = filterContext.HttpContext.User.Identity.GetUserId();
            var context = new ApplicationDbContext();
            var user = context.Users.Find(userId);
            context.Logs.Add(new LogAction(user,
                filterContext.ActionDescriptor.ActionName,
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                Description));

            context.SaveChanges();
        }
    }
}
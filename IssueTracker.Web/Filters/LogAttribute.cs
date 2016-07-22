using IssueTracker.Web.Data;
using IssueTracker.Web.Domain;
using IssueTracker.Web.Infrastructure;
using System.Collections.Generic;
using System.Web.Mvc;

namespace IssueTracker.Web.Filters
{
    public class LogAttribute : ActionFilterAttribute
    {
        //private readonly ApplicationDbContext _context;
        public string Description { get; set; }
        private IDictionary<string, object> _parameters;
        public ICurrentUser CurrentUser { get; set; }
        public ApplicationDbContext Context { get; set; }

        public LogAttribute(string description/*, ApplicationDbContext context*/)
        {
            //_context = context;
            Description = description;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _parameters = filterContext.ActionParameters;
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //var userId = filterContext.HttpContext.User.Identity.GetUserId();
            //var context = new ApplicationDbContext();
            //var user = context.Users.Find(userId);

            var description = Description;
            foreach (var kvp in _parameters)
            {
                description = description.Replace("{" + kvp.Key + "}", kvp.Value.ToString());
            }

            Context.Logs.Add(new LogAction(CurrentUser.User,
                filterContext.ActionDescriptor.ActionName,
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                description)); // Description -> description

            Context.SaveChanges();
        }
    }
}
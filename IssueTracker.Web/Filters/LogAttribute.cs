using IssueTracker.Web.Data;
using IssueTracker.Web.Domain;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Web.Mvc;

namespace IssueTracker.Web.Filters
{
    public class LogAttribute : ActionFilterAttribute
    {
        //private readonly ApplicationDbContext _context;
        public string Description { get; set; }
        private IDictionary<string, object> _parameters;

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
            var userId = filterContext.HttpContext.User.Identity.GetUserId();
            var context = new ApplicationDbContext();
            var user = context.Users.Find(userId);

            var description = Description;
            foreach (var kvp in _parameters)
            {
                description = description.Replace("{" + kvp.Key + "}", kvp.Value.ToString());
            }

            context.Logs.Add(new LogAction(user,
                filterContext.ActionDescriptor.ActionName,
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                description)); // Description -> description

            context.SaveChanges();
        }
    }
}
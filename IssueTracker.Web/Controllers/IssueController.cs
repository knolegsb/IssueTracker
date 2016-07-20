using IssueTracker.Web.Data;
using IssueTracker.Web.Domain;
using IssueTracker.Web.Models.Issue;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace IssueTracker.Web.Controllers
{
    public class IssueController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IssueController(ApplicationDbContext context)
        {
            _context = context;
        }

        [ChildActionOnly]
        public ActionResult IssueWidget()
        {
            //return Content("Here's where issues would go!");
            var models = from i in _context.Issues
                select new IssueSummaryViewModel
                {
                    IssueID = i.IssueID,
                    Subject = i.Subject,
                    CreatedAt = i.CreatedAt
                };
            return PartialView(models.ToArray());
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult New(NewIssueForm form)
        {
            var userId = User.Identity.GetUserId();
            var user = _context.Users.Find(userId);
            _context.Issues.Add(new Issue(user, null, form.Subject, form.Body));
            _context.Logs.Add(new LogAction(user, "New", "Issue", "Created issue"));
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult View(int id)
        {
            var issue = _context.Issues.Find(id);
            if (issue == null)
            {
                throw new ApplicationException("Issue not found!");
            }

            var userId = User.Identity.GetUserId();
            var user = _context.Users.Find(userId);
            _context.Logs.Add(new LogAction(user, "View", "Issue", "Viewed issue " + id));
            _context.SaveChanges();

            return View(new IssueDetailsViewModel
            {
                IssueID = issue.IssueID,
                Subject = issue.Subject,
                CreatedAt = issue.CreatedAt,
                Body = issue.Body
            });
        }

        public ActionResult Delete(int id)
        {
            var issue = _context.Issues.Find(id);

            if (issue == null)
            {
                throw new ApplicationException("Issue not found!");
            }
            
            _context.Issues.Remove(issue);

            var userId = User.Identity.GetUserId();
            var user = _context.Users.Find(userId);
            _context.Logs.Add(new LogAction(user, "Delete", "Issue", "Deleted issue " + id));
            _context.SaveChanges();

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
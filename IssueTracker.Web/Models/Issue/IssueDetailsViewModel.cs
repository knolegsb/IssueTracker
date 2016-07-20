using System;

namespace IssueTracker.Web.Models.Issue
{
    public class IssueDetailsViewModel
    {
        public int IssueID { get; set; }
        public string Subject { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Body { get; set; }
    }
}
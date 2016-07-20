using IssueTracker.Web.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IssueTracker.Web.Models.Issue
{
    public class NewIssueForm
    {
        [Required]
        public string Subject { get; set; }

        [Required]
        public IssueType IssueType { get; set; }

        [Required, Display(Name = "Assigned To")]
        public string AssignedToUserID { get; set; }

        [Required]
        public string Body { get; set; }
    }
}
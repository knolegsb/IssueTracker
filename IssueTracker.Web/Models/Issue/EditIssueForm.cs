using IssueTracker.Web.Domain;
using IssueTracker.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IssueTracker.Web.Models.Issue
{
    public class EditIssueForm : IMapFrom<Domain.Issue>
    {
        [HiddenInput]
        public int IssueID { get; set; }

        [ReadOnly(true)]
        public string CreatorUseName { get; set; }

        [Required]
        public string Subject { get; set; }
        public IssueType IssueType { get; set; }

        [Display(Name = "Assigned To")]
        public string AssignedToUserName { get; set; }

        [Required]
        public string Body { get; set; }
    }
}
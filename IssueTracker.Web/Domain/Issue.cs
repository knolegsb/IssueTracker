﻿using IssueTracker.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IssueTracker.Web.Domain
{
    public class Issue
    {
        public int IssueID { get; set; }
        public ApplicationUser Creator { get; set; }
        public ApplicationUser AssignedTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public IssueType IssueType { get; set; }

        protected Issue()
        {

        }

        public Issue(ApplicationUser creator, ApplicationUser assignedTo, IssueType type, string subject, string body)
        {
            Creator = creator;
            AssignedTo = assignedTo;
            Subject = subject;
            Body = body;
            CreatedAt = DateTime.Now;
            IssueType = type;
        }
    }
}
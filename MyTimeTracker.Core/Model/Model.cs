using System;
using System.Collections.Generic;

namespace MyTimeTracker.Core.Model
{

    public class Worklog
    {
        public DateTime Started { get; set; }
        public int TimeSpentInSeconds { get; set; }
        public string IssueId { get; set; }
    }

    public class Fields
    {
        public string summary { get; set; }
        public int timespent { get; set; }
    }

    public class Issue
    {
        public string expand { get; set; }
        public string id { get; set; }
        public string self { get; set; }
        public string key { get; set; }
        public Fields fields { get; set; }
    }

    public class Example
    {
        public string expand { get; set; }
        public int startAt { get; set; }
        public int maxResults { get; set; }
        public int total { get; set; }
        public IList<Issue> issues { get; set; }
    }
}

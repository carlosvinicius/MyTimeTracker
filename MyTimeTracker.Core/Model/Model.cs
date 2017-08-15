using System;
using System.Collections.Generic;

namespace MyTimeTracker.Core.Model
{
    public class Issuetype
    {
        public string self { get; set; }
        public string id { get; set; }
        public string description { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public bool subtask { get; set; }
    }

    public class AvatarUrls
    {
        public string a48x48 { get; set; }
        public string a24x24 { get; set; }
        public string a16x16 { get; set; }
        public string a32x32 { get; set; }
    }

    public class Project
    {
        public string self { get; set; }
        public string id { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public AvatarUrls avatarUrls { get; set; }
    }

    public class Watches
    {
        public string self { get; set; }
        public int watchCount { get; set; }
        public bool isWatching { get; set; }
    }

    public class Priority
    {
        public string self { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Assignee
    {
        public string self { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public string accountId { get; set; }
        public string emailAddress { get; set; }
        public AvatarUrls avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
    }

    public class StatusCategory
    {
        public string self { get; set; }
        public int id { get; set; }
        public string key { get; set; }
        public string colorName { get; set; }
        public string name { get; set; }
    }

    public class Status
    {
        public string self { get; set; }
        public string description { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public StatusCategory statusCategory { get; set; }
    }

    public class Creator
    {
        public string self { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public string accountId { get; set; }
        public string emailAddress { get; set; }
        public AvatarUrls avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
    }

    public class Reporter
    {
        public string self { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public string accountId { get; set; }
        public string emailAddress { get; set; }
        public AvatarUrls avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
    }

    public class Aggregateprogress
    {
        public int progress { get; set; }
        public int total { get; set; }
    }

    public class Progress
    {
        public int progress { get; set; }
        public int total { get; set; }
    }

    public class Votes
    {
        public string self { get; set; }
        public int votes { get; set; }
        public bool hasVoted { get; set; }
    }

    public class Fields
    {
        public Issuetype issuetype { get; set; }
        public object timespent { get; set; }
        public Project project { get; set; }
        public IList<object> fixVersions { get; set; }
        public object aggregatetimespent { get; set; }
        public object resolution { get; set; }
        public object customfield_10036 { get; set; }
        public IList<object> customfield_10037 { get; set; }
        public object resolutiondate { get; set; }
        public int workratio { get; set; }
        public DateTime lastViewed { get; set; }
        public Watches watches { get; set; }
        public DateTime created { get; set; }
        public Priority priority { get; set; }
        public IList<object> labels { get; set; }
        public object aggregatetimeoriginalestimate { get; set; }
        public object timeestimate { get; set; }
        public IList<object> versions { get; set; }
        public IList<object> issuelinks { get; set; }
        public Assignee assignee { get; set; }
        public DateTime updated { get; set; }
        public Status status { get; set; }
        public IList<object> components { get; set; }
        public object customfield_10050 { get; set; }
        public object customfield_10051 { get; set; }
        public object timeoriginalestimate { get; set; }
        public object customfield_10052 { get; set; }
        public object customfield_10053 { get; set; }
        public object description { get; set; }
        public object customfield_10054 { get; set; }
        public IList<string> customfield_10010 { get; set; }
        public string customfield_10011 { get; set; }
        public object customfield_10012 { get; set; }
        public object customfield_10013 { get; set; }
        public object customfield_10049 { get; set; }
        public object customfield_10008 { get; set; }
        public object aggregatetimeestimate { get; set; }
        public object customfield_10009 { get; set; }
        public string summary { get; set; }
        public Creator creator { get; set; }
        public IList<object> subtasks { get; set; }
        public object customfield_10040 { get; set; }
        public object customfield_10041 { get; set; }
        public Reporter reporter { get; set; }
        public Aggregateprogress aggregateprogress { get; set; }
        public string customfield_10000 { get; set; }
        public object customfield_10044 { get; set; }
        public object customfield_10045 { get; set; }
        public object customfield_10001 { get; set; }
        public object customfield_10046 { get; set; }
        public object customfield_10002 { get; set; }
        public object customfield_10047 { get; set; }
        public object customfield_10003 { get; set; }
        public object customfield_10004 { get; set; }
        public object customfield_10048 { get; set; }
        public object customfield_10038 { get; set; }
        public object customfield_10039 { get; set; }
        public object environment { get; set; }
        public object duedate { get; set; }
        public Progress progress { get; set; }
        public Votes votes { get; set; }
    }

    public class Issue
    {
        public string expand { get; set; }
        public string id { get; set; }
        public string self { get; set; }
        public string key { get; set; }
        public Fields fields { get; set; }
    }

    public class Author
    {
        public string self { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public string accountId { get; set; }
        public string emailAddress { get; set; }
        public AvatarUrls avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
    }

    public class UpdateAuthor
    {
        public string self { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public string accountId { get; set; }
        public string emailAddress { get; set; }
        public AvatarUrls avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
    }

    public class Worklog
    {
        public string self { get; set; }
        public Author author { get; set; }
        public UpdateAuthor updateAuthor { get; set; }
        public string comment { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public DateTime started { get; set; }
        public string timeSpent { get; set; }
        public int timeSpentSeconds { get; set; }
        public string id { get; set; }
        public string issueId { get; set; }
    }

    public class ExampleWorklog
    {
        public int startAt { get; set; }
        public int maxResults { get; set; }
        public int total { get; set; }
        public IList<Worklog> worklogs { get; set; }
    }

    public class ExampleIssues
    {
        public string expand { get; set; }
        public int startAt { get; set; }
        public int maxResults { get; set; }
        public int total { get; set; }
        public IList<Issue> issues { get; set; }
    }

    public class Fields2
    {
        public Worklog worklog { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gitcv.Models.Types
{
    public class GithubRepository
    {
        public string url { get; set; }
        public string html_url { get; set; }
        public string clone_url { get; set; }
        public string git_url { get; set; }
        public string ssh_url { get; set; }
        public string svn_url { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string homepage { get; set; }
        public string language { get; set; }
        public bool fork { get; set; }
        public long forks { get; set; }
        public long watchers { get; set; }
        public long size { get; set; }
        public string master_branch { get; set; }
        public long open_issues { get; set; }
        public string pushed_at { get; set; }
        public string created_at { get; set; }

        public RepositoryOwner owner { get; set; }
    }
}
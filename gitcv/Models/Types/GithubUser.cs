using System;

namespace gitcv.Models.Types
{
    public class GithubUser
    {
        public string login { get; set; }
        public long id { get; set; }
        public string avatar_url { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public string company { get; set; }
        public string blog { get; set; }
        public string location { get; set; }
        public string email { get; set; }
        public bool hireable { get; set; }
        public string bio { get; set; }
        public long public_repos { get; set; }
        public long public_gists { get; set; }
        public long followers { get; set; }
        public long following { get; set; }
        public string html_url { get; set; }
        public string created_at { get; set; }
        public string type { get; set; }
    }
}
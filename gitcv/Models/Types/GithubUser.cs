using System;

namespace gitcv.Models.Types
{
    public class GithubUser
    {
        public String login { get; set; }
        public String id { get; set; }
        public String avatar_url { get; set; }
        public String gravatar_id { get; set; }
        public String url { get; set; }
        public String name { get; set; }
        public String company { get; set; }
        public String blog { get; set; }
        public String location { get; set; }
        public String email { get; set; }
        public String hireable { get; set; }
        public String bio { get; set; }
        public String public_repos { get; set; }
        public String public_gists { get; set; }
        public String followers { get; set; }
        public String following { get; set; }
        public String html_url { get; set; }
        public String created_at { get; set; }
        public String type { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gitcv.Models.Types
{
    public class RepositoryOwner
    {
        public string login { get; set; }
        public long id { get; set; }
        public string avatar_url { get; set; }
        public string gravatar_id { get; set; }
        public string url { get; set; }
    }
}
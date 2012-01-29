using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using gitcv.Models.Types;

namespace gitcv.Models.Services
{
    public class GithubService
    {
        public GithubService()
        {
            
        }

        public static GithubUser GetUser(string userName)
        {
            var uri = string.Format("https://api.github.com/users/{0}", userName);
            var stream = MakeRequest(uri);
            var serializer = new DataContractJsonSerializer(typeof(GithubUser));
            var user = (GithubUser)serializer.ReadObject(stream);
            stream.Close();
            return user;
        }

        public static List<GithubRepository> GetRepositories(string userName)
        {
            var uri = string.Format("https://api.github.com/users/{0}/repos", userName);
            var stream = MakeRequest(uri);
            var serializer = new DataContractJsonSerializer(typeof(List<GithubRepository>));
            var repos = (List<GithubRepository>)serializer.ReadObject(stream);
            stream.Close();
            return repos;
        }

        public static Dictionary<string, int> GetLanguages(string userName)
        {
            var repos = GithubService.GetRepositories(userName);

            var languages = new Dictionary<string, int>();
            foreach (var repo in repos)
            {
                if (String.IsNullOrEmpty(repo.language))
                {
                    repo.language = "Other";
                }

                if (!languages.ContainsKey(repo.language))
                {
                    languages.Add(repo.language, 1);
                }
                else
                {
                    languages[repo.language]++;
                }
            }
            return languages;
        } 

        private static Stream MakeRequest(string uri)
        {
            var request = WebRequest.Create(uri) as HttpWebRequest;
            var response = request.GetResponse() as HttpWebResponse;
            return response.GetResponseStream();
        }
    }
}
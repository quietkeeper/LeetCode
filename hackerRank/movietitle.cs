using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.hackerRank
{
    class movietitle
    {

        static string[] getMovieTitles(string substr)
        {
            if (string.IsNullOrEmpty(substr))
                return null;
            
            MovieSearchResultParameter parameter=GetParameters(substr, 1);
            string[] result = new string[parameter.TotalCount];
            parameter.Titles.CopyTo(result, 0);
            int totalCount = parameter.TotalCount;
            int totalPage = totalCount / parameter.NumPerPage + 1;
            for (int i = 2; i < totalPage+1; i++)
            {
                parameter= GetParameters(substr, i);
                parameter.Titles.CopyTo(result, parameter.NumPerPage*(i-1));
            }
            return result.ToArray();
        }

        static MovieSearchResultParameter GetParameters(string substr,int page)
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    string url = @"https://jsonmock.hackerrank.com/api/movies/search/?Title=" + substr+ @"&page="+page;
                    var json = wc.DownloadString(url);

                    JArray rss = JArray.Parse(json);

                    MovieSearchResultParameter result = rss.Select(l => new MovieSearchResultParameter
                    {
                         PageNum = Convert.ToInt32(l["page"]),
                        TotalCount = Convert.ToInt32(l["total"]),
                         NumPerPage = Convert.ToInt32(l["per_page"])
                    }).FirstOrDefault();
                    string[] Titles =
                            (from p in rss["data"]
                            select (string)p["Title"]).ToArray();
                    result.Titles = Titles;
                    return result;

                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class MovieSearchResultParameter
    {
        public int NumPerPage { get; set; }
        public int PageNum { get; set; }

        public string[] Titles { get; set; }
        public int TotalCount { set; get; }
    }

    
}

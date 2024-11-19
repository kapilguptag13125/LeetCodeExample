using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static LeetcodeExamples.Tests.GacGroup;

namespace LeetcodeExamples.Tests
{
    public class GacGroup
    {

        public class Movie
        {
            public string Title { get; set; }
            public string Genre { get; set; }
            public int Rating { get; set; }
        }

        public static void Run()
        {

            List<Movie> lstMovies = new List<Movie>();

            lstMovies.Add(new Movie { Genre = "Adv", Rating = 10, Title = "abc" });
            lstMovies.Add(new Movie { Genre = "Adv", Rating = 20, Title = "abc1" });
            lstMovies.Add(new Movie { Genre = "Adv", Rating = 30, Title = "abc3" });

            var list = lstMovies.GroupBy(t => t.Genre).Select(t1 => new {
                Key = t1.Key,
                Values = t1
            }).ToList();

            Dictionary<string, Movie> result = new Dictionary<string, Movie>();

            foreach (var movie in list)
            {
                var res = movie.Values.Where(t => t.Rating == movie.Values.Select(t => t.Rating).Max()).FirstOrDefault();

            }


            List<string> ShowBlanace = new List<string> { "see", "show" };
            List<string> DepositFunds = new List<string> { "deposit", "put", "invest", "transfer" };
            List<string> WithdrwaFunds = new List<string> { "withdraw", "pull" };
            string message = "I want to pull 2300 dollars";
            var wordsInMessage = message.Split(" ");

            var depositeFundsResult = wordsInMessage.Where(t => DepositFunds.Any(s => s.Equals(t, StringComparison.OrdinalIgnoreCase))).ToList();


            //var wordsInMessage = "show balance".Split(" ");
            //List<string> showBlanace = new List<string> { "see", "show" };

            //var result = wordsInMessage.Where(t => showBlanace.Any(s=>s.Contains(t, StringComparison.OrdinalIgnoreCase)));
        }

    }
}

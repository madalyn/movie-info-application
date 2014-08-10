using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using MovieInfoApplication.MovieInfo;
using System.Runtime;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace MovieInfoApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Madalyn!");

            //get 10 movies currently in theaters, give back the JSON (limit=10 var later)
            //perhaps do as user input if time
            //need a catch if no movies, or less than input number
            string json = getMoviesJSON(10);

            //Console.WriteLine(json);

           
            //dynamically make all 10 movies elsewhere - C# properties           
            Movie guardians = new Movie("guardians",null);
            string title = guardians.getTitle();
            Console.WriteLine(title);

            JObject movie1 = JsonConvert.DeserializeObject<JObject>(json);
           // Console.WriteLine(movie1);

            JSONParseDynamic(json);
           
                       
        }
        /*
        static List<string> JSONParseObject(string jsonText)
        {
            JObject jResults = JObject.Parse(jsonText);
            List<string> counties = new List<string>();
            foreach (var county in jResults["total"])
            {
                counties.Add((string)county["name"]);
            }
            return counties;
        }*/

        static List<string> JSONParseDynamic(string jsonText)
        {
            dynamic jResults = JsonConvert.DeserializeObject(jsonText);
            List<string> titles = new List<string>();
            List<Movie> movieList = new List<Movie>();

            foreach (var t in jResults.movies)
            {
                titles.Add((string)t.title);
                //for each one, create a movie object
                //add to a list of movies
                movieList.Add(new Movie((string)t.title, null));

                
                Console.WriteLine((string)t.title);
            }
            
            return titles;
        }

        /// <summary>
        /// This function deals with getting the appropriate number
        /// of movie objects in JSON form
        /// </summary>
        /// <param name="numTitles">the number of movies to get</param>
        /// <returns>the correct number of movies in a string of JSON</returns>
        static string getMoviesJSON(int numTitles)
        {
            string numString = numTitles.ToString();
            string url = "http://api.rottentomatoes.com/api/public/v1.0/lists/movies/in_theaters.json?page_limit="+numString+"&page=1&country=us&apikey=xyfqrbjvshc9vsupeht8dw2p";
            WebRequest request = WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string json = reader.ReadToEnd();
            
            reader.Close();
            dataStream.Close();
            response.Close();

            return json;
        }

        ///Configure Movies & Number to return --> move to new class later (right now to 10)
        void createMovieList()
        {
            //string of json

            //create movie objects
            //add titles
        }

        /// <summary>
        /// Call individually for each movie
        /// </summary>
        void createActorList()
        {
            //use the movie info to get full actor list (new func)

            //use full actor list to create actor objects w/ name & age for each

            //return the List<Actor>
        }

    }
}

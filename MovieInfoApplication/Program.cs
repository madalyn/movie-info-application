using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using MovieInfoApplication.MovieInfo;

namespace MovieInfoApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Madalyn!");

            //get 10 movies currently in theaters, give back the JSON (limit=10 var later)
            //perhaps do as user input if time
            string json = getMovieTitlesJSON(10);

            Console.WriteLine(json);

           
            //dynamically make all 10 movies elsewhere            
            Movie guardians = new Movie("guardians",null);
            string title = guardians.getTitle();
            Console.WriteLine(title);
                       
        }


        static string getMovieTitlesJSON(int numTitles)
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

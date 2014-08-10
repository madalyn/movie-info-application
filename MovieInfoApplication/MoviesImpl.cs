using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieInfoApplication.MovieInfo;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace MovieInfoApplication
{
    /// <summary>
    /// A class to configure the movie objects parsed
    /// from the recieved JSON
    /// </summary>
    class MoviesImpl //the class itself should probably deal with the JSON. Too much passed around right now
    {
        public List<Movie> createMoviesFromJSON(string json)
        {
            dynamic jResults = JsonConvert.DeserializeObject(json);
            List<Movie> movieList = new List<Movie>();

            //"movies" and "title" come from JSON structure
            foreach (var movie in jResults.movies)
            {
                //for each one, create a movie object & add to list; use movie id to generate actors
                movieList.Add(new Movie((string)movie.title, createActorsFromJSON(getActorsJSON((int)movie.id)), (int)movie.id));
            }

            return movieList;
        }

        public List<Actor> createActorsFromJSON(string json)
        {
            dynamic jResults = JsonConvert.DeserializeObject(json);
            List<Actor> castList = new List<Actor>();

            foreach (var actor in jResults.cast)
            {
                castList.Add(new Actor((string)actor.name, 10));
            }

            return castList;
        }

        /// <summary>
        /// This function deals with getting the appropriate number
        /// of movie objects in JSON form
        /// </summary>
        /// <param name="numTitles">the number of movies to get</param>
        /// <returns>the correct number of movies in a string of JSON</returns>
        /// ********************use this
        public string getMoviesJSON(int numTitles)
        {
            string numString = numTitles.ToString();
            string url = "http://api.rottentomatoes.com/api/public/v1.0/lists/movies/in_theaters.json?page_limit=" + numString + "&page=1&country=us&apikey=xyfqrbjvshc9vsupeht8dw2p";

            return doWebRequest(url);
        }

        /// <summary>
        /// Takes in the movie's rotten tomatoes ID to do the query
        /// for the correct cast
        /// </summary>
        /// <param name="id">the rotten tomatoes ID for the specific movie</param>
        /// <returns>the correct raw json string</returns>
        public string getActorsJSON(int id)
        {
            string idString = id.ToString();
            string url = "http://api.rottentomatoes.com/api/public/v1.0/movies/" + idString + "/cast.json?apikey=xyfqrbjvshc9vsupeht8dw2p";

            return doWebRequest(url);
        }

        private string doWebRequest(string url)
        {
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

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieInfoApplication.MovieInfo;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using MovieInfoApplication.requests;

namespace MovieInfoApplication
{
    /// <summary>
    /// A class to configure the movie objects parsed
    /// from the recieved JSON
    /// </summary>
    class MoviesImpl
    {
        public List<Movie> getMovies(int numTitles)
        {
            string moviesJSON = getMoviesJSON(numTitles);
            return createMoviesFromJSON(moviesJSON);
        }

        // using the JSON string, creates the movie objects
        private List<Movie> createMoviesFromJSON(string json)
        {
            dynamic jResults = JsonConvert.DeserializeObject(json);
            List<Movie> movieList = new List<Movie>();

            if (jResults.movies != null)
            {
                //"movies" and "title" come from JSON structure
                foreach (var movie in jResults.movies)
                {
                    //for each one, create a movie object & add to list; use movie id to generate actors
                    movieList.Add(new Movie((string)movie.title, createActorsFromJSON(getActorsJSON((int)movie.id)), (int)movie.id));
                }
            }

            return movieList;
        }

        // uses the JSON string to create actor objects for that movie's entire cast
        private List<Actor> createActorsFromJSON(string json)
        {
            dynamic jResults = JsonConvert.DeserializeObject(json);
            List<Actor> castList = new List<Actor>();

            foreach (var actor in jResults.cast)
            {
                castList.Add(new Actor((string)actor.name, 10));
            }

            return castList;
        }

        // deals with getting JSON string for the desired number of movies
        private string getMoviesJSON(int numTitles)
        {
            string numString = numTitles.ToString();
            string url = "http://api.rottentomatoes.com/api/public/v1.0/lists/movies/in_theaters.json?page_limit=" + numString + "&page=1&country=us&apikey=xyfqrbjvshc9vsupeht8dw2p";

            return WebRequester.getInstance().doWebRequest(url);
        }

        // using the movie's rotten tomatoes ID, query for the json of the entire cast
        private string getActorsJSON(int id)
        {
            string idString = id.ToString();
            string url = "http://api.rottentomatoes.com/api/public/v1.0/movies/" + idString + "/cast.json?apikey=xyfqrbjvshc9vsupeht8dw2p";

            return WebRequester.getInstance().doWebRequest(url);
        }

        public string getActorAge()
        {
            string url = "http://api.freebase.com/api/service/search?query=Smith&type=/people/person";
            Console.WriteLine(WebRequester.getInstance().doWebRequest(url));
            return WebRequester.getInstance().doWebRequest(url);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieInfoApplication.MovieInfo;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using MovieInfoApplication.requests;
using Newtonsoft.Json.Linq;

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
                    //createActorsFromJSON(getActorsJSON((int)movie.id))
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
                castList.Add(new Actor((string)actor.name, (int)getActorAge((string)actor.name)));
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

        /// <summary>
        /// Gets the age of an actor from freebase by using that
        /// actor's name.
        /// </summary>
        /// <param name="name">The name of the actor</param>
        /// <returns>the age if it is found; -1 if no age</returns>
        public int getActorAge(string name)
        {
            string url = "https://www.googleapis.com/freebase/v1/search?query=" + name + "&type=/film/actor&output=(/people/person/age)&limit=1&key=AIzaSyAwbCTaa97y8hJsjiVxwKYVvRcwk9z1G6U";

            dynamic jResults = JsonConvert.DeserializeObject(WebRequester.getInstance().doWebRequest(url));
            dynamic result = null;

            //if we get back an array, make sure there is data; 
            if (jResults.result != null && jResults.result.Type == JTokenType.Array && ((JArray)jResults.result).Count > 0)
            {
                result = jResults.result[0];
            }
            //if not, make sure it is at least an object
            else if (jResults.result != null && jResults.result.Type == JTokenType.Object)
            {
                result = jResults.result;
            }

            //get the actors age based on the json
            //make sure there is data for age & name
            //check all the way down; because as soon as you try to index a null value it breaks
            if (result != null && result.output != null && result.output["/people/person/age"] != null &&
                result.output["/people/person/age"]["/people/person/age"] != null && 
                result["name"] != null)
            {
                //check to make sure first result (most confident) is still same person
                if (name.Equals((string)result["name"]))
                {
                    return (int)result.output["/people/person/age"]["/people/person/age"][0];
                }
            }
               
            //the most confident result is the wrong person or age could not be found, set invalid age
            return -1;
        }
    }
}

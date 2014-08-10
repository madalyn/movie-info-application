using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieInfoApplication.MovieInfo
{
    //For the class Movie
    //the Title and the Cast List are set
    //by information parsed via the JSON
    //meaning when a new Movie is created
    //the title and castlist must be known at this time
    public class Movie : IMovie
    {
        private string title;
        private List<Actor> actors;
        private int rtid;

        public Movie(string title, List<Actor> actors, int rtid)
        {
            this.title = title;
            this.actors = actors;
            this.rtid = rtid;
        }

        /// <summary>
        /// Method to return the title of the movie
        /// </summary>
        /// <returns></returns>
        public string getTitle()
        {
            return title;
        }

        /// <summary>
        /// Method to return a list of Actors in the movie
        /// </summary>
        /// <returns></returns>
        public List<Actor> getActorsInMovie() 
        {
            return actors;
        }

        /// <summary>
        /// Gets the movie's specific rotten tomatoes ID
        /// </summary>
        /// <returns>the ID</returns>
        public int getRTID()
        {
            return rtid;
        }

        /// <summary>
        /// Method that gives back the average age of the cast
        /// Note: this will this class's function got get the cast list
        /// </summary>
        /// <returns></returns>
        public double getAverageAgeOfCast()
        {
            List<Actor> cast = getActorsInMovie();
            double ageTotal = 0.0;

            foreach (var actor in cast)
            {
                ageTotal += actor.getAge();
            }

            return ageTotal / (cast.Count);
        }
    }
}

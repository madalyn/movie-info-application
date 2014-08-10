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

        /**
        * Method to return the title of the movie
        */
        public string getTitle()
        {
            return title;
        }

        /**
         * Method to return a list of Actors in the movie
         */
        public List<Actor> getActorsInMovie() 
        {
            return actors;
        }

        /**
         * Method that gives back the average age of the cast
         * Note: this will use a helper-function to find the number of actors
         * */
        public double getAverageAgeOfCast(List<Actor> cast)
        {
            return 1.0;
        }

        /// <summary>
        /// Gets the movie's specific rotten tomatoes ID
        /// </summary>
        /// <returns>the ID</returns>
        public int getRTID()
        {
            return rtid;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieInfoApplication.MovieInfo;

namespace MovieInfoApplication
{
    public interface IMovie
    {
        /// <summary>
        /// Method to return the title of the movie
        /// </summary>
        /// <returns></returns>
        string getTitle();

        /// <summary>
        /// Method to return a list of Actors in the movie
        /// </summary>
        /// <returns></returns>
        List<Actor> getActorsInMovie();

        /// <summary>
        /// Gets the movie's specific rotten tomatoes ID
        /// </summary>
        /// <returns>the ID</returns>
        int getRTID();

        /// <summary>
        /// Method that gives back the average age of the cast
        /// Note: this will this class's function got get the cast list
        /// </summary>
        /// <returns></returns>
        double getAverageAgeOfCast();
    }
}

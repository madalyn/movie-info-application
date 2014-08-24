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
        /// Property to access the title of the movie
        /// </summary>
        /// <returns>the movie's title</returns>
        string Title { get; set; }
        
        /// <summary>
        /// Property to access a list of Actors in the movie
        /// </summary>
        /// <returns>the movie's cast</returns>
        List<IActor> Actors { get; set; }

        /// <summary>
        /// Property to access movie's specific rotten tomatoes ID
        /// </summary>
        /// <returns>the ID</returns>
        int RottenTomatoesID { get; set; }

        /// <summary>
        /// Method that calculates the average age of the movie's cast
        /// </summary>
        /// <returns>the average age of the cast (only including the actors whose names could be found).</returns>
        double getAverageAgeOfCast();
    }
}

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
        /// <returns></returns>
        string Title { get; set; }
        
        /// <summary>
        /// Property to access a list of Actors in the movie
        /// </summary>
        /// <returns></returns>
        List<Actor> Actors { get; set; }

        /// <summary>
        /// Property to access movie's specific rotten tomatoes ID
        /// </summary>
        /// <returns>the ID</returns>
        int RottenTomatoesID { get; set; }

        /// <summary>
        /// Method that gives back the average age of the cast
        /// Note: this will this class's function got get the cast list
        /// </summary>
        /// <returns></returns>
        double getAverageAgeOfCast();
    }
}

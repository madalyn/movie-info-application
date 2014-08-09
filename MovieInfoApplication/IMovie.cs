using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieInfoApplication.MovieInfo;

namespace MovieInfoApplication
{
    public interface IMovie
    {
        /**
         * Method to return the title of the movie
         */
        string getTitle();

        /**
         * Method to return a list of Actors in the movie
         */
        List<Actor> getActorsInMovie();

        /**
         * Method that gives back the average age of the cast
         * Note: this will use a helper-function to find the number of actors
         * */
        double getAverageAgeOfCast(List<Actor> cast);
    }
}

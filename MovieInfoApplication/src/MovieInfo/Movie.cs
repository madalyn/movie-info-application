using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieInfoApplication.MovieInfo
{
    //The Movie class, which contains information about a movie object
    //the Title, Actors, and RottonTomatoesID are set
    //by information parsed from the recieved JSON for that movie
    //All movie info comes from Rotton Tomatoes
    public class Movie : IMovie
    {
        public string Title { get; set; }
        public List<IActor> Actors { get; set; }
        public int RottenTomatoesID { get; set; }

        public Movie(string title, List<IActor> actors, int rottenTomatoesID)
        {
            this.Title = title;
            this.Actors = actors;
            this.RottenTomatoesID = rottenTomatoesID;
        }

        /// <summary>
        /// Method that calculates the average age of the movie's cast
        /// </summary>
        /// <returns>the average age of the cast (only including the actors whose names could be found).</returns>
        public double getAverageAgeOfCast()
        {
            double ageTotal = 0.0;
            int noAgeTotal = 0;

            //need to sum up actors who's ages weren't included and subtract that from the count
            //otherwise, use the actors with ages to find the average age of the cast
            foreach (var actor in Actors)
            {
                if (actor.Age < 0)
                {
                    noAgeTotal++;
                }
                else
                {
                    ageTotal += actor.Age;
                }
            }

            //let the user know how many actors were used in calculating the average age of the cast
            Console.WriteLine(noAgeTotal + " out of " + Actors.Count + " actors were not included");
            return ageTotal / (Actors.Count - noAgeTotal);
        }
    }
}

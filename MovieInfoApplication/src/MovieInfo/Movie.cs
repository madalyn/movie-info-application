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
        public string Title { get; set; }
        public List<Actor> Actors { get; set; }
        public int RottenTomatoesID { get; set; }

        public Movie(string title, List<Actor> actors, int rottenTomatoesID)
        {
            this.Title = title;
            this.Actors = actors;
            this.RottenTomatoesID = rottenTomatoesID;
        }

        /// <summary>
        /// Method that gives back the average age of the cast
        /// Note: this will this class's function got get the cast list
        /// </summary>
        /// <returns></returns>
        public double getAverageAgeOfCast()
        {
            double ageTotal = 0.0;
            int noAgeTotal = 0;

            //need to sum up actors who's ages weren't included and subtract that from the count
            foreach (var actor in Actors)
            {
                if (actor.Age < 0)
                {
                    Console.WriteLine(actor.Name + " was not included in the total.");
                    noAgeTotal++;
                }
                else
                {
                    ageTotal += actor.Age;
                }
                
            }

            return ageTotal / (Actors.Count - noAgeTotal);
        }
    }
}

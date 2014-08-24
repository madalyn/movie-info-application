using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using MovieInfoApplication.MovieInfo;
using System.Runtime;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace MovieInfoApplication
{
    class Program
    {
        static void Main(string[] args)
        {       
            Console.WriteLine("How many of the top movies would you like to know about?");
            Console.Write("Number of Movies: ");
            string input = Console.ReadLine();
            int numMovies;
                
            //deal with the user's input from the console
            if (int.TryParse(input, out numMovies))
            {
                if ((int)numMovies == 1)
                {
                    Console.WriteLine("\nThe top movie currently in theaters is:\n");
                }
                else
                {
                    Console.WriteLine("\nThe top " + numMovies + " movies currently in theaters are:\n");
                }
            }
            else
            {
                Console.WriteLine("Plese enter a valid number. For example: 1, 5, or 10.");
            }
            
            //get the top movies based on the user's input
            MoviesImpl impl = new MoviesImpl(); 
            List<IMovie> movies = impl.getMovies(numMovies); 

            int i = 1;
            //print out the movies and their info
            foreach (var movie in movies)
            {
                Console.WriteLine(i + ".)" + movie.Title);
                Console.WriteLine("Average Age of Cast: " + movie.getAverageAgeOfCast());
                Console.WriteLine("");
                i++;
            }
        }
    }
}

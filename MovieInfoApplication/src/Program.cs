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
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;

            Console.WriteLine("How many movies would you like to know about?");
            Console.Write("Number of Movies: ");
            string input = Console.ReadLine();
            int numMovies;

            if (int.TryParse(input, out numMovies))
            {
                Console.WriteLine("\nThe top " + numMovies + " movies currently in theaters are:\n");
            }
            else
            {
                Console.WriteLine("Plese enter a valid number. For example: 1, 5, or 10.");
            }
            
            MoviesImpl impl = new MoviesImpl();
            //get # movies currently in theaters, give back the movies
            //need a catch if no movies, or less than input number  
        
            //change back to numMovies, currently going over Rotten Tomatoes rate limit of 5 calls/second
            List<Movie> movies = impl.getMovies(numMovies); //improve speed

            int i = 1;
            foreach(var movie in movies){
                Console.WriteLine(i + ".)" + movie.Title);
                Console.WriteLine("Average Age of Cast: " + movie.getAverageAgeOfCast());
                Console.WriteLine("");
                i++;              
            }

        
        }

        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e) {
            Console.WriteLine(e.ExceptionObject.ToString());
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
            Environment.Exit(1);
        }
    }
}

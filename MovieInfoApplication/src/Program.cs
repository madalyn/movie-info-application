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
            int numMovies = -1;

            do
            {
                Console.WriteLine("How many of the top movies would you like to know about?");
                Console.Write("Number of Movies: ");
                string input = Console.ReadLine();
                
                if (int.TryParse(input, out numMovies))
                {
                    Console.WriteLine("\nThe top " + numMovies + " movie currently in theaters are:\n");
                }
                else
                {
                    Console.WriteLine("Plese enter a valid number. For example: 1, 5, or 10.");
                }
            
                MoviesImpl impl = new MoviesImpl(); 
                List<IMovie> movies = impl.getMovies(numMovies); 

                int i = 1;
                foreach(var movie in movies){
                    Console.WriteLine(i + ".)" + movie.Title);
                    Console.WriteLine("Average Age of Cast: " + movie.getAverageAgeOfCast());
                    Console.WriteLine("");
                    i++;              
                }

            } while (true);
        }

        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e) {
            Console.WriteLine(e.ExceptionObject.ToString());
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
            Environment.Exit(1);
        }
    }
}
